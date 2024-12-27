using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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

internal sealed class OnDemandRequestWrapper<T> : IOnDemandRequestWrapper
    where T : class, IEntity, new()
{
    private readonly SankhyaContext _context;

    private readonly int _throughput;

    private readonly bool _allowAboveThroughput;

    private readonly ConcurrentQueue<T> _queue;

    private readonly Thread _worker;

    private readonly ServiceName _service;

    private CancellationToken _token;

    private int _requestCount;

    private int _entitiesSent;

    private int _entitiesSentSuccessfully;

    private bool _disposeRequested;

    private bool _flushRequested;

    private readonly string _entityName;

    private readonly ManualResetEvent _event;

    private readonly ManualResetEvent _flushEvent;

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
