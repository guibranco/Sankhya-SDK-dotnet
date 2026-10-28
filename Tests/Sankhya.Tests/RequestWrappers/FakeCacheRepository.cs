using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using CrispyWaffle.Cache;

namespace Sankhya.Tests.RequestWrappers;

/// <summary>
/// An in-memory, TTL-aware <see cref="ICacheRepository"/> that completes every operation
/// asynchronously, like a real remote cache (Redis, Couchbase) would. This exercises the
/// synchronous bridge over the async <see cref="CacheManager"/> API on a ValueTask that is
/// not already completed when it is returned.
/// </summary>
internal sealed class FakeCacheRepository : ICacheRepository
{
    private static readonly Lazy<FakeCacheRepository> _registered = new(
        () =>
        {
            var repository = new FakeCacheRepository();
            CacheManager.AddRepository(repository);
            return repository;
        },
        LazyThreadSafetyMode.ExecutionAndPublication
    );

    private readonly ConcurrentDictionary<string, CacheEntry> _entries = new(
        StringComparer.Ordinal
    );

    /// <summary>
    /// Gets the single instance registered in the (static) <see cref="CacheManager"/>.
    /// Tests share it, so each test must use its own cache key.
    /// </summary>
    public static FakeCacheRepository Registered => _registered.Value;

    public bool ShouldPropagateExceptions { get; set; }

    public bool Contains(string key) => _entries.ContainsKey(key);

    public async ValueTask SetAsync<T>(
        T value,
        string key,
        TimeSpan? ttl = null,
        CancellationToken cancellationToken = default
    )
    {
        await Task.Yield();

        var expiresAt = ttl.HasValue ? DateTime.UtcNow.Add(ttl.Value) : (DateTime?)null;

        _entries[key] = new CacheEntry(value, expiresAt);
    }

    public ValueTask SetAsync<T>(
        T value,
        string key,
        string subKey,
        CancellationToken cancellationToken = default
    ) => SetAsync(value, $"{key}-{subKey}", ttl: null, cancellationToken: cancellationToken);

    public async ValueTask<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var (success, value) = await TryGetAsync<T>(key, cancellationToken);

        if (!success)
        {
            throw new InvalidOperationException($"Unable to get the item with key {key}");
        }

        return value;
    }

    public ValueTask<T> GetAsync<T>(
        string key,
        string subKey,
        CancellationToken cancellationToken = default
    ) => GetAsync<T>($"{key}-{subKey}", cancellationToken);

    public async ValueTask<(bool Success, T Value)> TryGetAsync<T>(
        string key,
        CancellationToken cancellationToken = default
    )
    {
        await Task.Yield();

        if (!_entries.TryGetValue(key, out var entry))
        {
            return (false, default);
        }

        if (entry.IsExpired)
        {
            _entries.TryRemove(key, out _);
            return (false, default);
        }

        return entry.Value is T value ? (true, value) : (false, default);
    }

    public ValueTask<(bool Success, T Value)> TryGetAsync<T>(
        string key,
        string subKey,
        CancellationToken cancellationToken = default
    ) => TryGetAsync<T>($"{key}-{subKey}", cancellationToken);

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        _entries.TryRemove(key, out _);
    }

    public Task RemoveAsync(
        string key,
        string subKey,
        CancellationToken cancellationToken = default
    ) => RemoveAsync($"{key}-{subKey}", cancellationToken);

    public async Task<TimeSpan> TTLAsync(string key, CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return _entries.TryGetValue(key, out var entry) ? entry.TimeToLive : TimeSpan.Zero;
    }

    public Task Clear()
    {
        _entries.Clear();

        return Task.CompletedTask;
    }

    private sealed class CacheEntry
    {
        public CacheEntry(object value, DateTime? expiresAt)
        {
            Value = value;
            ExpiresAt = expiresAt;
        }

        public object Value { get; }

        public DateTime? ExpiresAt { get; }

        public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value <= DateTime.UtcNow;

        /// <summary>
        /// Gets the remaining time to live. An entry stored without a TTL reports zero even though
        /// it exists, exactly like CrispyWaffle's <see cref="MemoryCacheRepository"/> does.
        /// </summary>
        public TimeSpan TimeToLive
        {
            get
            {
                if (!ExpiresAt.HasValue)
                {
                    return TimeSpan.Zero;
                }

                var remaining = ExpiresAt.Value - DateTime.UtcNow;

                return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
            }
        }
    }
}
