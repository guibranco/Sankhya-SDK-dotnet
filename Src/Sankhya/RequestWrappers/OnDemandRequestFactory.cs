using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Sankhya.Enums;
using Sankhya.Transport;
using Sankhya.ValueObjects;

namespace Sankhya.RequestWrappers;

public static class OnDemandRequestFactory
{
    private static readonly object SyncRoot = new();

    private static readonly ConcurrentBag<OnDemandRequestInstance> Instances = new();

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
            Type = typeof(T),
        };
        Instances.Add(instance);
        return instance;
    }

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

    public static IOnDemandRequestWrapper GetInstanceForService<T>(ServiceName service)
        where T : class, IEntity, new()
    {
        var type = typeof(T);

        var result = Instances.SingleOrDefault(i => i.Service == service && i.Type == type);

        if (result != null)
        {
            return result.Instance;
        }

        lock (SyncRoot)
        {
            result = Instances.SingleOrDefault(i => i.Service == service && i.Type == type);

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

    public static IOnDemandRequestWrapper GetInstanceByKey(Guid key) =>
        Instances.SingleOrDefault(i => i.Key == key)?.Instance;

    public static void FlushByKey(Guid key) => GetInstanceByKey(key)?.Flush();

    public static void FlushAll()
    {
        foreach (var instance in Instances)
        {
            instance.Instance.Flush();
        }
    }

    public static void FinalizeAll()
    {
        try
        {
            while (Instances.TryTake(out var instance))
            {
                instance.Instance.Dispose();
            }
        }
        catch (ObjectDisposedException) { }
    }
}
