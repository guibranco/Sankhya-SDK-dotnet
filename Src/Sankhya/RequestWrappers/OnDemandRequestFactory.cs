using System.Collections.Concurrent;
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
    /// The synchronize root.
    /// </summary>
    private static readonly object SyncRoot = new();

    /// <summary>
    /// The instances
    /// </summary>
    private static readonly ConcurrentBag<OnDemandRequestInstance> Instances = new();

    /// <summary>
    /// Creates an internal instance of an OnDemandRequestInstance for a specified entity type.
    /// </summary>
    /// <typeparam name="T">The type of the entity, which must implement IEntity and have a parameterless constructor.</typeparam>
    /// <param name="guid">A unique identifier for the instance being created.</param>
    /// <param name="service">The service name associated with the instance.</param>
    /// <param name="throughput">The throughput value for the instance.</param>
    /// <param name="allowAboveThroughput">A flag indicating whether to allow throughput above the specified limit.</param>
    /// <param name="token">A cancellation token to monitor for cancellation requests.</param>
    /// <returns>A newly created instance of <see cref="OnDemandRequestInstance"/>.</returns>
    /// <remarks>
    /// This method initializes a new instance of <see cref="OnDemandRequestInstance"/> by creating a wrapper for the specified entity type <typeparamref name="T"/>.
    /// The created instance is configured with the provided service name, throughput, and cancellation token.
    /// It also adds the newly created instance to a collection of instances for management and tracking purposes.
    /// The method ensures that the entity type meets the requirements of implementing the IEntity interface and having a default constructor.
    /// </remarks>
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

    /// <summary>
    /// Creates a new instance of OnDemandRequestWrapper and assign a key for it.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
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
    /// <typeparam name="T">The type parameter.</typeparam>
    /// <param name="service">The service.</param>
    /// <returns>IOnDemandRequestWrapper.</returns>
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

    /// <summary>
    /// Gets the instance by key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>IOnDemandRequestWrapper.</returns>
    public static IOnDemandRequestWrapper GetInstanceByKey(Guid key) =>
        Instances.SingleOrDefault(i => i.Key == key)?.Instance;

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
        foreach (var instance in Instances)
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
            while (Instances.TryTake(out var instance))
            {
                instance.Instance.Dispose();
            }
        }
        catch (ObjectDisposedException) { }
    }
}
