using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using CrispyWaffle.Cache;
using CrispyWaffle.Composition;
using CrispyWaffle.Infrastructure;
using CrispyWaffle.Log;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Properties;
using Sankhya.Service;
using Sankhya.Transport;
using Sankhya.ValueObjects;

namespace Sankhya.RequestWrappers;

/// <summary>
/// An erp managed service request.
/// </summary>
internal sealed class PagedRequestWrapper
{
    #region Private fields

    /// <summary>
    /// all pages loaded.
    /// </summary>
    private readonly AutoResetEvent _allPagesLoaded = new(false);

    /// <summary>
    /// The on demand tasks
    /// </summary>
    private readonly List<Task> _onDemandTasks = new();

    /// <summary>
    /// The Sankhya context.
    /// </summary>
    private readonly SankhyaContext _context;

    /// <summary>
    /// The token identifying the session on SankhyaContext.
    /// </summary>
    private readonly Guid _token;

    /// <summary>
    /// The results loaded.
    /// </summary>
    private int _resultsLoaded;

    /// <summary>
    /// true if set.
    /// </summary>
    private bool _set;

    /// <summary>
    /// The entity name
    /// </summary>
    private readonly string _entityName;

    /// <summary>
    /// The maximum results
    /// </summary>
    private readonly int _maxResults;

    /// <summary>
    /// Collection of responses.
    /// </summary>
    private readonly Queue<EntityDynamicSerialization> _items;

    /// <summary>
    /// The request.
    /// </summary>
    private readonly ServiceRequest _request;

    /// <summary>
    /// The cache key/
    /// </summary>
    private readonly string _cacheKey;

    /// <summary>
    /// The type
    /// </summary>
    private readonly Type _type;

    #endregion

    #region Delegates & Events

    /// <summary>
    /// The page processed handler delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PagedRequestEventArgs"/> instance containing the event data.</param>
    public delegate void PageProcessedHandler(object sender, PagedRequestEventArgs e);

    /// <summary>
    /// The page loaded successfully handler delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PagedRequestEventArgs"/> instance containing the event data.</param>
    public delegate void PageLoadedSuccessfullyHandler(object sender, PagedRequestEventArgs e);

    /// <summary>
    /// The page not loaded handler delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PagedRequestEventArgs"/> instance containing the event data.</param>
    public delegate void PageNotLoadedHandler(object sender, PagedRequestEventArgs e);

    /// <summary>
    /// Occurs when [page loaded successfully].
    /// </summary>
    public event PageLoadedSuccessfullyHandler PageLoadedSuccessfully;

    /// <summary>
    /// Occurs when [page processed].
    /// </summary>
    public static event PageProcessedHandler PageProcessed;

    /// <summary>
    /// Occurs when [page not loaded].
    /// </summary>
    public event PageNotLoadedHandler PageLoadedError;

    #endregion

    #region ~Ctors

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="request">The request.</param>
    /// <param name="maxResults">The maximum number of results that the wrapper should return, -1 for all</param>
    private PagedRequestWrapper(Type type, ServiceRequest request, int maxResults)
    {
        _context = ServiceLocator.Resolve<SankhyaContext>();
        _entityName =
            request.RequestBody.Entity?.Name
            ?? request.RequestBody.Entity?.RootEntity
            ?? request.RequestBody.DataSet.RootEntity;
        _items = new();
        _maxResults = maxResults;
        _request = request;
        _resultsLoaded = 0;
        _token = _context.AcquireNewSession(ServiceRequestType.PagedCrud);
        _cacheKey = $@"PagedRequestWrapper_{_entityName}_{_context.UserName}";
        _type = type;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Called when [load page successfully].
    /// </summary>
    /// <param name="quantityLoaded">The quantity loaded.</param>
    /// <param name="currentPageNumber">The current page number.</param>
    /// <param name="totalPages">The total pages.</param>
    private void OnLoadPageSuccessfully(int quantityLoaded, int currentPageNumber, int totalPages)
    {
        if (PageLoadedSuccessfully == null && PageProcessed == null)
        {
            return;
        }

        LogConsumer.Trace(
            Resources.PagedRequestWrapper_Signaling,
            _entityName,
            Resources.PageLoaded
        );
        var eventArgs = new PagedRequestEventArgs(
            _type,
            quantityLoaded,
            _resultsLoaded,
            currentPageNumber,
            totalPages
        );
        PageLoadedSuccessfully?.Invoke(this, eventArgs);
        PageProcessed?.Invoke(this, eventArgs);
    }

    /// <summary>
    /// Called when [load page error].
    /// </summary>
    /// <param name="currentPageNumber">The current page number.</param>
    /// <param name="exception">The exception.</param>
    private void OnLoadPageError(int currentPageNumber, ServiceRequestGeneralException exception)
    {
        var ex = new PagedRequestException(_request, exception);

        if (PageLoadedError == null && PageProcessed == null)
        {
            LogConsumer.Handle(ex);
            return;
        }

        LogConsumer.Trace(Resources.PagedRequestWrapper_Signaling, _entityName, Resources.Error);

        var eventArgs = new PagedRequestEventArgs(
            _type,
            currentPageNumber,
            _resultsLoaded,
            exception
        );

        PageLoadedError?.Invoke(this, eventArgs);

        PageProcessed?.Invoke(this, eventArgs);
    }

    /// <summary>
    /// Loads the page.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="quantityLoaded">The quantity loaded.</param>
    /// <param name="totalPages">The total pages.</param>
    /// <returns>Boolean.</returns>
    private bool LoadPage(int page, out int quantityLoaded, out int totalPages)
    {
        quantityLoaded = -1;

        totalPages = 0;

        try
        {
            if (page > 1)
            {
                _request.RequestBody.DataSet.PageNumber = page;
            }

            var response = _context.ServiceInvoker(_request, _token);

            _request.RequestBody.DataSet.PagerId = response
                .ResponseBody
                .CrudServiceProviderEntities
                .PagerId;

            quantityLoaded = response.ResponseBody.CrudServiceProviderEntities.Total;

            totalPages = response.ResponseBody.CrudServiceProviderEntities.TotalPages;

            Interlocked.Add(ref _resultsLoaded, quantityLoaded);

            foreach (
                EntityDynamicSerialization ds in response
                    .ResponseBody
                    .CrudServiceProviderEntities
                    .Entities
            )
            {
                _items.Enqueue(ds);
            }

            OnLoadPageSuccessfully(quantityLoaded, page, totalPages);

            return true;
        }
        catch (ServiceRequestGeneralException e)
        {
            OnLoadPageError(page, e);
        }

        return false;
    }

    /// <summary>
    /// Loads the response.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <exception cref="ServiceRequestRepeatedException"></exception>
    private void LoadResponse(CancellationToken token)
    {
        if (_set)
        {
            throw new ServiceRequestRepeatedException(_request);
        }

        var pageNumber = 1;

        try
        {
            LoadResponseInternal(token, ref pageNumber);
        }
        catch (ServiceRequestGeneralException e)
        {
            OnLoadPageError(pageNumber, e);
        }
    }

    /// <summary>
    /// Loads the response internal.
    /// </summary>
    /// <param name="token">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="pageNumber">The page number.</param>
    private void LoadResponseInternal(CancellationToken token, ref int pageNumber)
    {
        const int lockMinutes = 3;

        WaitAnotherLoad();

        CacheManager.Set(EnvironmentHelper.ProcessId, _cacheKey, new TimeSpan(0, lockMinutes, 0));

        var firstPage = LoadPage(pageNumber++, out var quantityLoaded, out var totalPages);

        if (
            !firstPage
            || quantityLoaded != 150
            || token.IsCancellationRequested
            || _maxResults != -1 && _maxResults <= quantityLoaded
        )
        {
            Close();
            return;
        }

        while (true)
        {
            if (totalPages <= 0)
            {
                totalPages = 1 + pageNumber;
            }

            CacheManager.Set(
                EnvironmentHelper.ProcessId,
                _cacheKey,
                TimeSpan.FromMinutes(lockMinutes * (totalPages - pageNumber + 1))
            );

            var success = LoadPage(pageNumber++, out quantityLoaded, out totalPages);

            if (
                success
                && quantityLoaded == 300
                && !token.IsCancellationRequested
                && (_maxResults == -1 || _maxResults > _resultsLoaded)
            )
            {
                continue;
            }

            Close();

            break;
        }
    }

    /// <summary>
    /// Waits another load.
    /// </summary>
    private void WaitAnotherLoad()
    {
        while (true)
        {
            if (
                !CacheManager.TryGet(_cacheKey, out int processId)
                || processId == EnvironmentHelper.ProcessId
            )
            {
                break;
            }

            var timeToWait = CacheManager.TTL(_cacheKey);

            if (timeToWait.Ticks == 0)
            {
                CacheManager.Remove(_cacheKey);
                break;
            }

            LogConsumer.Warning(
                Resources.PagedRequestWrapper_LoadResponse_Waiting,
                _entityName,
                timeToWait
            );

            Thread.Sleep(Math.Min(10000, (int)timeToWait.TotalMilliseconds));
        }
    }

    /// <summary>
    /// Closes this instance.
    /// </summary>
    private void Close()
    {
        if (_set)
        {
            return;
        }

        try
        {
            CacheManager.Remove(_cacheKey);
        }
        catch (Exception e)
        {
            LogConsumer.Handle(e);
        }

        LogConsumer.Trace(
            Resources.PagedRequestWrapper_Signaling,
            _entityName,
            Resources.AllPagesLoaded
        );
        LogConsumer.Info(
            Resources.PagedRequestWrapper_Close,
            _resultsLoaded,
            _resultsLoaded == 1 ? Resources.YSingularSuffix : Resources.YPluralSuffix,
            _entityName
        );
        _context.FinalizeSession(_token);
        _allPagesLoaded.Set();
        _set = true;
    }

    /// <summary>
    /// Gets the managed enumerator internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="processOnDemandData">The process on demand data.</param>
    /// <param name="maxResults">The maximum results.</param>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="cts">The CTS.</param>
    /// <param name="stronglyTypedCollection">The strongly typed collection.</param>
    /// <returns></returns>
    private static ServiceRequestGeneralException GetManagedEnumeratorInternal<T>(
        ServiceRequest request,
        Action<List<T>> processOnDemandData,
        int maxResults,
        string entityName,
        CancellationTokenSource cts,
        BlockingCollection<T> stronglyTypedCollection
    )
        where T : class, IEntity, new()
    {
        if (cts.IsCancellationRequested)
        {
            return null;
        }

        Thread.CurrentThread.Name = $@"PagedRequestWrapper of {entityName}";

        ServiceRequestGeneralException ex = null;

        var wrapper = new PagedRequestWrapper(typeof(T), request, maxResults);

        wrapper.PageLoadedError += (_, e) =>
            ex = HandlePageLoadedError(
                entityName,
                cts,
                stronglyTypedCollection,
                wrapper,
                e.Exception
            );
        wrapper.PageLoadedSuccessfully += (_, e) =>
            HandlePageLoaded(
                processOnDemandData,
                entityName,
                cts,
                stronglyTypedCollection,
                e.CurrentPage,
                e.TotalPages,
                e.QuantityLoaded,
                wrapper
            );

        try
        {
            wrapper.LoadResponse(cts.Token);
        }
        catch (ObjectDisposedException e)
        {
            LogConsumer.Trace(e);
        }

        wrapper._allPagesLoaded.WaitOne();

        Task.WaitAll(wrapper._onDemandTasks.ToArray());

        try
        {
            if (!cts.IsCancellationRequested)
            {
                stronglyTypedCollection.CompleteAdding();
            }

            wrapper.Dispose();
        }
        catch (ObjectDisposedException)
        {
            LogConsumer.Error(Resources.PagedRequestWrapper_GetManagedEnumeratorInternal);
        }

        return ex;
    }

    /// <summary>
    /// Handles the page loaded.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="processOnDemandData">The process on demand data.</param>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="cts">The CTS.</param>
    /// <param name="stronglyTypedCollection">The strongly typed collection.</param>
    /// <param name="currentPageNumber">The current page number.</param>
    /// <param name="totalPages">The total pages.</param>
    /// <param name="quantityLoaded">The quantity loaded.</param>
    /// <param name="wrapper">The wrapper.</param>
    private static void HandlePageLoaded<T>(
        Action<List<T>> processOnDemandData,
        string entityName,
        CancellationTokenSource cts,
        BlockingCollection<T> stronglyTypedCollection,
        int currentPageNumber,
        int totalPages,
        int quantityLoaded,
        PagedRequestWrapper wrapper
    )
        where T : class, IEntity, new()
    {
        LogConsumer.Info(
            Resources.PagedRequestWrapper_GetManagedEnumerator_PageLoaded,
            currentPageNumber,
            totalPages > 0
                ? string.Format(CultureInfo.CurrentCulture, Resources.OfTotal, totalPages)
                : string.Empty,
            entityName,
            quantityLoaded,
            quantityLoaded == 1 ? Resources.YSingularSuffix : Resources.YPluralSuffix
        );
        var temp = new List<T>();
        for (var i = 0; i < quantityLoaded; i++)
        {
            temp.Add(wrapper._items.Dequeue().ConvertToType<T>());
        }

        if (!temp.Any() || cts.IsCancellationRequested || stronglyTypedCollection.IsAddingCompleted)
        {
            return;
        }

        if (processOnDemandData == null)
        {
            temp.ForEach(stronglyTypedCollection.Add);
            return;
        }

        wrapper._onDemandTasks.Add(
            Task.Factory.StartNew(
                () => LoadOnDemandData(processOnDemandData, temp, stronglyTypedCollection, cts),
                cts.Token,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Current
            )
        );
    }

    /// <summary>
    /// Loads the on demand data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="processOnDemandData">The process on demand data.</param>
    /// <param name="temp">The temporary.</param>
    /// <param name="stronglyTypedCollection">The strongly typed collection.</param>
    /// <param name="cts">The CTS.</param>
    private static void LoadOnDemandData<T>(
        Action<List<T>> processOnDemandData,
        List<T> temp,
        BlockingCollection<T> stronglyTypedCollection,
        CancellationTokenSource cts
    )
        where T : class, IEntity, new()
    {
        try
        {
            processOnDemandData(temp);
            if (!cts.IsCancellationRequested && !stronglyTypedCollection.IsAddingCompleted)
            {
                temp.ForEach(stronglyTypedCollection.Add);
            }
        }
        catch (Exception e)
        {
            cts.Cancel();
            LogConsumer.Handle(e);
        }
    }

    /// <summary>
    /// Handles the page loaded error.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="cts">The CTS.</param>
    /// <param name="stronglyTypedCollection">The strongly typed collection.</param>
    /// <param name="wrapper">The wrapper.</param>
    /// <param name="exception">The exception.</param>
    /// <returns></returns>
    private static ServiceRequestGeneralException HandlePageLoadedError<T>(
        string entityName,
        CancellationTokenSource cts,
        BlockingCollection<T> stronglyTypedCollection,
        PagedRequestWrapper wrapper,
        Exception exception
    )
        where T : class, IEntity, new()
    {
        LogConsumer.Warning(
            Resources.PagedRequestWrapper_GetManagedEnumerator_ErrorOccured,
            entityName
        );

        wrapper.Close();

        var ex = exception;

        try
        {
            if (!cts.IsCancellationRequested)
            {
                stronglyTypedCollection.CompleteAdding();
            }
        }
        catch (Exception e)
        {
            cts.Cancel();
            LogConsumer.Handle(e);
        }

        return (ServiceRequestGeneralException)ex;
    }

    /// <summary>
    /// Handles the cancellation token cancelled.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="timeout">The timeout.</param>
    private static void HandleCancellationTokenCancelled(
        ServiceRequest request,
        string entityName,
        TimeSpan timeout
    ) =>
        LogConsumer.Error(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.PagedRequestWrapper_HandleCancellationTokenCancelled,
                entityName,
                timeout.TotalSeconds,
                request.ServiceInternal
            )
        );

    #endregion

    #region Public methods

    /// <summary>
    /// Gets the managed enumerator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="processOnDemandData">The process on demand data.</param>
    /// <param name="maxResults">The maximum results.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> GetManagedEnumerator<T>(
        ServiceRequest request,
        TimeSpan timeout,
        Action<List<T>> processOnDemandData = null,
        int maxResults = -1
    )
        where T : class, IEntity, new()
    {
        var entityName = typeof(T).GetEntityName();

        ServiceRequestGeneralException ex = null;

        using var cts = new CancellationTokenSource(timeout);

        cts.Token.Register(() => HandleCancellationTokenCancelled(request, entityName, timeout));

        using var stronglyTypedCollection = new BlockingCollection<T>();

        var timer = new Stopwatch();

        timer.Start();

        var task = Task.Run(
            () =>
                // ReSharper disable AccessToDisposedClosure
                ex = GetManagedEnumeratorInternal(
                    request,
                    processOnDemandData,
                    maxResults,
                    entityName,
                    cts,
                    stronglyTypedCollection
                ),
            cts.Token
        );

        var counter = 0;

        foreach (var item in stronglyTypedCollection.GetConsumingEnumerable(cts.Token))
        {
            counter++;

            yield return item;

            if (stronglyTypedCollection.IsCompleted)
            {
                yield break;
            }
        }

        Task.WaitAll(task);

        timer.Stop();

        LogConsumer.Trace(
            Resources.PagedRequestWrapper_GetManagedEnumerator,
            counter,
            entityName,
            timer.Elapsed
        );

        if (ex != null)
        {
            throw ex;
        }
    }

    #endregion

    #region Implementation of IDisposable

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting
    /// unmanaged resources.
    /// </summary>
    private void Dispose() => Close();

    #endregion
}
