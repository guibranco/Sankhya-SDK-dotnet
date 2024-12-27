using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

internal sealed class PagedRequestWrapper
{
    private readonly AutoResetEvent _allPagesLoaded = new(false);

    private readonly List<Task> _onDemandTasks = new();

    private readonly SankhyaContext _context;

    private readonly Guid _token;

    private int _resultsLoaded;

    private bool _set;

    private readonly string _entityName;

    private readonly int _maxResults;

    private readonly Queue<EntityDynamicSerialization> _items;

    private readonly ServiceRequest _request;

    private readonly string _cacheKey;

    private readonly Type _type;

    public delegate void PageProcessedEventHandler(object sender, PagedRequestEventArgs e);

    public delegate void PageLoadedSuccessfullyEventHandler(object sender, PagedRequestEventArgs e);

    public delegate void PageNotLoadedEventHandler(object sender, PagedRequestEventArgs e);

    public event PageLoadedSuccessfullyEventHandler PageLoadedSuccessfully;

    public static event PageProcessedEventHandler PageProcessed;

    public event PageNotLoadedEventHandler PageLoadedError;

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

            var response = SankhyaContext.ServiceInvoker(_request, _token);

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

    private void LoadResponseInternal(CancellationToken token, ref int pageNumber)
    {
        const int lockMinutes = 3;

        WaitAnotherLoad();

        CacheManager.Set(EnvironmentHelper.ProcessId, _cacheKey, new TimeSpan(0, lockMinutes, 0));

        var firstPage = LoadPage(pageNumber++, out var quantityLoaded, out var totalPages);

        var maxResultsReached = _maxResults != -1 && _maxResults <= quantityLoaded;

        if (
            !firstPage
            || quantityLoaded != 150
            || token.IsCancellationRequested
            || maxResultsReached
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

            var shouldRequestNextPage = _maxResults != -1 && _maxResults > _resultsLoaded;

            if (
                success
                && quantityLoaded == 300
                && !token.IsCancellationRequested
                && shouldRequestNextPage
            )
            {
                continue;
            }

            Close();

            break;
        }
    }

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
        var ofTotal =
            totalPages > 0
                ? string.Format(CultureInfo.CurrentCulture, Resources.OfTotal, totalPages)
                : string.Empty;
        LogConsumer.Info(
            Resources.PagedRequestWrapper_GetManagedEnumerator_PageLoaded,
            currentPageNumber,
            ofTotal,
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

        task.Wait(cts.Token);

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

    private void Dispose() => Close();
}
