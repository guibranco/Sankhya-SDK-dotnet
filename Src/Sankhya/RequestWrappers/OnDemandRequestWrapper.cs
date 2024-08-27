using System.Collections.Concurrent;
using System.Globalization;
using CrispyWaffle.Composition;
using CrispyWaffle.Events;
using CrispyWaffle.Log;
using Sankhya.Enums;
using Sankhya.Events;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Properties;
using Sankhya.Service;
using Sankhya.Transport;

namespace Sankhya.RequestWrappers;

/// <summary>
/// Class OnDemandRequestWrapper. This class cannot be inherited.
/// </summary>
/// <typeparam name="T">The type parameter.</typeparam>
/// <seealso cref="IOnDemandRequestWrapper" />
/// <seealso cref="IDisposable" />
internal sealed class OnDemandRequestWrapper<T> : IOnDemandRequestWrapper
    where T : class, IEntity, new()
{
    /// <summary>
    /// The context.
    /// </summary>
    private readonly SankhyaContext _context;

    /// <summary>
    /// The throughput.
    /// </summary>
    private readonly int _throughput;

    /// <summary>
    /// The allow above throughput.
    /// </summary>
    private readonly bool _allowAboveThroughput;

    /// <summary>
    /// The queue.
    /// </summary>
    private readonly ConcurrentQueue<T> _queue;

    /// <summary>
    /// The worker.
    /// </summary>
    private readonly Thread _worker;

    /// <summary>
    /// The service.
    /// </summary>
    private readonly ServiceName _service;

    /// <summary>
    /// The token.
    /// </summary>
    private CancellationToken _token;

    /// <summary>
    /// The request count.
    /// </summary>
    private int _requestCount;

    /// <summary>
    /// The entities sent.
    /// </summary>
    private int _entitiesSent;

    /// <summary>
    /// The entities sent successfully.
    /// </summary>
    private int _entitiesSentSuccessfully;

    /// <summary>
    /// The dispose requested.
    /// </summary>
    private bool _disposeRequested;

    /// <summary>
    /// The flush requested.
    /// </summary>
    private bool _flushRequested;

    /// <summary>
    /// The entity name.
    /// </summary>
    private readonly string _entityName;

    /// <summary>
    /// The event.
    /// </summary>
    private readonly ManualResetEvent _event;

    /// <summary>
    /// The flush event.
    /// </summary>
    private readonly ManualResetEvent _flushEvent;

    /// <summary>
    /// Initializes a new instance of the <see cref="OnDemandRequestWrapper{T}" /> class.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="token">The token.</param>
    /// <param name="throughput">The throughput.</param>
    /// <param name="allowAboveThroughput">The allow above throughput.</param>
    /// <exception cref="InvalidServiceRequestOperationException"></exception>
    public OnDemandRequestWrapper(
        ServiceName service,
        CancellationToken token,
        int throughput = 10,
        bool allowAboveThroughput = true
    )
    {
        if (service != ServiceName.CrudServiceRemove && service != ServiceName.CrudServiceSave)
        {
            throw new InvalidServiceRequestOperationException(service);
        }

        _entityName = typeof(T).GetEntityName();
        LogConsumer.Info(
            Resources.OnDemandRequestWrapper_OnDemandRequestWrapper_Starting,
            _entityName,
            throughput,
            throughput == 1 ? @"m" : Resources.ItemPluralSufix
        );
        _context = ServiceLocator.Resolve<SankhyaContext>();
        _service = service;
        _throughput = throughput;
        _allowAboveThroughput = allowAboveThroughput;

        _queue = new();

        _token = token;

        _worker = new(Process)
        {
            Name = $@"OnDemandRequest<{_entityName}_{throughput}_{_service}>",
            Priority = ThreadPriority.Lowest,
        };
        _event = new(false);
        _flushEvent = new(false);
        _worker.Start();
    }

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <exception cref="ObjectDisposedException">Object disposed.</exception>
    /// <exception cref="CanceledOnDemandRequestWrapperException">On demand request wrapper canceled.</exception>
    public void Add(IEntity entity)
    {
        if (_disposeRequested)
        {
            throw new ObjectDisposedException(Resources.AlreadyDisposed);
        }

        LogConsumer.Debug(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.OnDemandRequestWrapper_Add,
                _entityName
            )
        );
        if (_token.IsCancellationRequested)
        {
            throw new CanceledOnDemandRequestWrapperException();
        }

        _queue.Enqueue((T)entity);
        _event.Set();
    }

    /// <summary>
    /// Flushes this instance.
    /// </summary>
    /// <exception cref="ObjectDisposedException">Object disposed.</exception>
    public void Flush()
    {
        if (_disposeRequested)
        {
            throw new ObjectDisposedException(Resources.AlreadyDisposed);
        }

        LogConsumer.Info(Resources.OnDemandRequestWrapper_Flush, _entityName);

        var any = false;

        if (_queue.Any())
        {
            _flushEvent.Set();
            any = true;
        }

        _flushRequested = true;

        if (!_event.WaitOne(0))
        {
            _event.Set();
        }

        if (any)
        {
            _flushEvent.WaitOne();
        }
    }

    /// <summary>
    /// Processes this instance.
    /// </summary>
    private void Process()
    {
        var sessionToken = _context.AcquireNewSession(ServiceRequestType.OnDemandCrud);

        _token.Register(
            () =>
                LogConsumer.Warning(
                    Resources.OnDemandRequestWrapper_OnDemandRequestWrapper_Cancelling,
                    sessionToken,
                    _entityName
                )
        );

        while (true)
        {
            if (ProcessInternal(sessionToken))
            {
                break;
            }
        }

        _context.DetachOnDemandRequestWrapper(sessionToken);
    }

    /// <summary>
    /// Processes the internal.
    /// </summary>
    /// <param name="sessionToken">The session token.</param>
    /// <returns><c>true</c> if processed, <c>false</c> otherwise.</returns>
    private bool ProcessInternal(Guid sessionToken)
    {
        WaitHandle.WaitAny(new[] { _event, _token.WaitHandle }, new TimeSpan(0, 1, 0));

        if (_queue.IsEmpty && (_token.IsCancellationRequested || _disposeRequested))
        {
            return true;
        }

        var forceRequest = _token.IsCancellationRequested || _disposeRequested || _flushRequested;

        if (_queue.Count < _throughput && !forceRequest)
        {
            _event.Reset();

            return false;
        }

        var items = new List<T>(_throughput);

        while (
            (items.Count < _throughput || forceRequest || _allowAboveThroughput) && !_queue.IsEmpty
        )
        {
            _flushRequested = false;

            if (forceRequest && _queue.IsEmpty)
            {
                break;
            }

            if (_queue.TryDequeue(out var item))
            {
                items.Add(item);
            }
        }

        if (items.Count == 0)
        {
            _event.Reset();
            return false;
        }

        var argument =
            _service == ServiceName.CrudServiceRemove
                ? Resources.Deleting
                : Resources.CreatingOrUpdating;
        LogConsumer.Info(
            Resources.OnDemandRequestWrapper_Process,
            argument,
            items.Count,
            items.Count == 1 ? @"m" : Resources.ItemPluralSufix,
            _entityName
        );

        var request = new ServiceRequest(_service);

        request.Resolve(items);

        _entitiesSent += items.Count;

        var result = ProcessRequest(request, sessionToken, out _);

        if (result)
        {
            _entitiesSentSuccessfully += items.Count;
        }
        else
        {
            ProcessItemsSeparately(items, sessionToken);
        }

        return false;
    }

    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="token">The token.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="isSecondAttempt">if set to <c>true</c> [is second attempt].</param>
    /// <returns><c>true</c> if processed, <c>false</c> otherwise.</returns>
    private bool ProcessRequest(
        ServiceRequest request,
        Guid token,
        out Exception exception,
        bool isSecondAttempt = false
    )
    {
        exception = null;

        try
        {
            _requestCount++;

            SankhyaContext.ServiceInvoker(request, token);

            return true;
        }
        catch (ServiceRequestTimeoutException e)
        {
            if (!isSecondAttempt)
            {
                return ProcessRequest(request, token, out exception, true);
            }

            exception = e;

            LogConsumer.Handle(e);
        }
        catch (ServiceRequestDeadlockException e)
        {
            if (!isSecondAttempt)
            {
                return ProcessRequest(request, token, out exception, true);
            }

            exception = e;

            LogConsumer.Handle(e);
        }
        catch (Exception e)
        {
            exception = e;

            LogConsumer.Handle(e);
        }

        return false;
    }

    /// <summary>
    /// Processes the items separately.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <param name="sessionToken">The session token.</param>
    private void ProcessItemsSeparately(IEnumerable<T> items, Guid sessionToken)
    {
        foreach (var item in items)
        {
            var request = new ServiceRequest(_service);

            request.Resolve(item);

            _requestCount++;

            var result = ProcessRequest(request, sessionToken, out var exception);

            if (result)
            {
                _entitiesSentSuccessfully++;
            }
            else
            {
                EventsConsumer.Raise(
                    new OnDemandRequestFailureEvent(
                        item,
                        _service == ServiceName.CrudServiceSave,
                        exception
                    )
                );
            }
        }
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    //TODO remove TimeSpan from Thread.Join! (why ???)
    public void Dispose()
    {
        _disposeRequested = true;

        _event.Set();

        _worker.Join(new TimeSpan(0, 1, 0));

        LogConsumer.Trace(
            Resources.OnDemandRequestWrapper_Dispose,
            _requestCount,
            _requestCount == 1 ? string.Empty : @"s",
            _entitiesSent,
            _entitiesSent == 1 ? Resources.YSingularSuffix : Resources.YPluralSuffix,
            _entityName,
            _entitiesSentSuccessfully
        );

        _event.Dispose();
        _flushEvent.Dispose();
    }
}
