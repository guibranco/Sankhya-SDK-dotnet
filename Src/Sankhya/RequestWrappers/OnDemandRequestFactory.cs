using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Sankhya.Enums;
using Sankhya.Transport;
using Sankhya.ValueObjects;

namespace Sankhya.RequestWrappers;

/// <summary>
/// Class OnDemandRequestFactory.
/// </summary>
public static class OnDemandRequestFactory
{
    /// <summary>
    /// The synchronize root
    /// </summary>
    private static readonly object _syncRoot = new();

    /// <summary>
    /// The instances
    /// </summary>

    private static readonly ConcurrentBag<OnDemandRequestInstance> _instances = new();

    /// <summary>
    /// Creates the instance internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guid">The unique identifier.</param>
    /// <param name="service">The service.</param>
    /// <param name="throughput">The throughput.</param>
    /// <param name="allowAboveThroughput">if set to <c>true</c> [allow above throughput].</param>
    /// <param name="token">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>OnDemandRequestInstance.</returns>
    private static OnDemandRequestInstance CreateInstanceInternal<T>(
        Guid guid,
        ServiceName service,
        int throughput,
        bool allowAboveThroughput,
        CancellationToken token
    )
        where T : class, IEntity, new()
    {
        var instance = new OnDemandRequestInstance
        {
            Instance = new OnDemandRequestWrapper<T>(
                service,
                token,
                throughput,
                allowAboveThroughput
            ),
            Key = guid,
            Service = service,
            Type = typeof(T)
        };
        _instances.Add(instance);
        return instance;
    }

    /// <summary>
    /// Creates a new instance of OnDemandRequestWrapper and assign a key for it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="service"></param>
    /// <param name="token"></param>
    /// <param name="throughput"></param>
    /// <param name="allowAboveThroughput"></param>
    /// <returns>The key of the instance created</returns>

    public static Guid CreateInstance<T>(
        ServiceName service,
        CancellationToken token,
        int throughput = 10,
        bool allowAboveThroughput = true
    )
        where T : class, IEntity, new()
    {
        var guid = Guid.NewGuid();
        CreateInstanceInternal<T>(guid, service, throughput, allowAboveThroughput, token);
        return guid;
    }

    /// <summary>
    /// Gets the instance for service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="service">The service.</param>
    /// <returns>IOnDemandRequestWrapper.</returns>
    public static IOnDemandRequestWrapper GetInstanceForService<T>(ServiceName service)
        where T : class, IEntity, new()
    {
        var type = typeof(T);

        var result = _instances.SingleOrDefault(i => i.Service == service && i.Type == type);

        if (result != null)
        {
            return result.Instance;
        }

        lock (_syncRoot)
        {
            result = _instances.SingleOrDefault(i => i.Service == service && i.Type == type);

            if (result != null)
            {
                return result.Instance;
            }

            var guid = Guid.NewGuid();

            var cancellationTokenSource = new CancellationTokenSource();

            return CreateInstanceInternal<T>(
                guid,
                service,
                10,
                true,
                cancellationTokenSource.Token
            ).Instance;
        }
    }

    /// <summary>
    /// Gets the instance by key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>IOnDemandRequestWrapper.</returns>


    public static IOnDemandRequestWrapper GetInstanceByKey(Guid key) =>
        _instances.SingleOrDefault(i => i.Key == key)?.Instance;

    /// <summary>
    /// Flushes the by key.
    /// </summary>
    /// <param name="key">The key.</param>

    public static void FlushByKey(Guid key) => GetInstanceByKey(key)?.Flush();

    /// <summary>
    /// Flushes all.
    /// </summary>

    public static void FlushAll()
    {
        foreach (var instance in _instances)
        {
            instance.Instance.Flush();
        }
    }

    /// <summary>
    /// Finalizes all instances.
    /// </summary>

    public static void FinalizeAll()
    {
        try
        {
            while (_instances.TryTake(out var instance))
            {
                instance.Instance.Dispose();
            }
        }
        catch (ObjectDisposedException) { }
    }
}
