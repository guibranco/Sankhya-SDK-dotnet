using System;
using CrispyWaffle.Cache;
using CrispyWaffle.Infrastructure;

namespace Sankhya.RequestWrappers;

/// <summary>
/// A cross-process lock, stored in the <see cref="CacheManager"/>, that serializes paged
/// requests of the same entity for the same user: while one process is paging, the others
/// wait until it finishes or the lock expires.
/// </summary>
/// <remarks>
/// The <see cref="CacheManager"/> API is asynchronous. <see cref="PagedRequestWrapper"/> runs
/// on a dedicated worker thread with no synchronization context, so this class bridges the
/// cache operations synchronously, keeping the paging flow synchronous.
/// </remarks>
internal sealed class PagedRequestLock
{
    private readonly string _cacheKey;

    private readonly int _processId;

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequestLock"/> class owned by the current process.
    /// </summary>
    /// <param name="cacheKey">The cache key that identifies the lock.</param>
    public PagedRequestLock(string cacheKey)
        : this(cacheKey, EnvironmentHelper.ProcessId) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequestLock"/> class.
    /// </summary>
    /// <param name="cacheKey">The cache key that identifies the lock.</param>
    /// <param name="processId">The id of the process that owns this lock instance.</param>
    /// <exception cref="ArgumentNullException"><paramref name="cacheKey"/> is <c>null</c>.</exception>
    public PagedRequestLock(string cacheKey, int processId)
    {
        _cacheKey = cacheKey ?? throw new ArgumentNullException(nameof(cacheKey));
        _processId = processId;
    }

    /// <summary>
    /// Gets the cache key that identifies the lock.
    /// </summary>
    public string CacheKey => _cacheKey;

    /// <summary>
    /// Gets the id of the process that owns this lock instance.
    /// </summary>
    public int ProcessId => _processId;

    /// <summary>
    /// Registers (or renews) the lock for the owning process.
    /// </summary>
    /// <param name="timeToLive">How long the lock should be kept before expiring.</param>
    public void Acquire(TimeSpan timeToLive) =>
        CacheManager.SetAsync(_processId, _cacheKey, timeToLive).AsTask().GetAwaiter().GetResult();

    /// <summary>
    /// Tries to get the id of the process currently holding the lock.
    /// </summary>
    /// <param name="processId">The id of the process holding the lock, when found.</param>
    /// <returns><c>true</c> if the lock exists in the cache; otherwise, <c>false</c>.</returns>
    public bool TryGetOwner(out int processId)
    {
        var (success, value) = CacheManager
            .TryGetAsync<int>(_cacheKey)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        processId = value;

        return success;
    }

    /// <summary>
    /// Gets the remaining time to live of the lock.
    /// </summary>
    /// <returns>The remaining time to live, or <see cref="TimeSpan.Zero"/> if the lock is expired or missing.</returns>
    public TimeSpan GetTimeToLive() => CacheManager.TTLAsync(_cacheKey).GetAwaiter().GetResult();

    /// <summary>
    /// Releases the lock, removing it from all cache repositories.
    /// </summary>
    public void Release() => CacheManager.Remove(_cacheKey).AsTask().GetAwaiter().GetResult();

    /// <summary>
    /// Checks whether another process is currently holding the lock.
    /// An expired lock (no time to live left) is released and reported as not held.
    /// </summary>
    /// <param name="timeToWait">The time to wait for the lock to expire, when held by another process.</param>
    /// <returns><c>true</c> if another process holds the lock; otherwise, <c>false</c>.</returns>
    public bool IsHeldByAnotherProcess(out TimeSpan timeToWait)
    {
        timeToWait = TimeSpan.Zero;

        if (!TryGetOwner(out var owner) || owner == _processId)
        {
            return false;
        }

        timeToWait = GetTimeToLive();

        if (timeToWait.Ticks != 0)
        {
            return true;
        }

        Release();

        timeToWait = TimeSpan.Zero;

        return false;
    }
}
