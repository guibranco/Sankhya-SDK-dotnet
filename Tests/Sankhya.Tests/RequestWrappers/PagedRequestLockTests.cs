using System;
using System.Threading.Tasks;
using Sankhya.RequestWrappers;
using Xunit;

namespace Sankhya.Tests.RequestWrappers;

public class PagedRequestLockTests
{
    private const int CurrentProcessId = 1001;

    private const int AnotherProcessId = 2002;

    private static readonly TimeSpan _lockTimeToLive = TimeSpan.FromMinutes(5);

    // Registered eagerly, before the first test of this class runs: every lock operation goes
    // through the static CacheManager, which must already have the fake repository in place.
    private static readonly FakeCacheRepository _repository = FakeCacheRepository.Registered;

    private static FakeCacheRepository Repository => _repository;

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenCacheKeyIsNull()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() =>
            new PagedRequestLock(null, CurrentProcessId)
        );
        Assert.Equal("cacheKey", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldExposeCacheKeyAndProcessId()
    {
        // Arrange
        var cacheKey = NewCacheKey();

        // Act
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Assert
        Assert.Equal(cacheKey, sut.CacheKey);
        Assert.Equal(CurrentProcessId, sut.ProcessId);
    }

    [Fact]
    public void Constructor_ShouldUseCurrentProcessId_WhenProcessIdIsNotProvided()
    {
        // Act
        var sut = new PagedRequestLock(NewCacheKey());

        // Assert
        Assert.Equal(Environment.ProcessId, sut.ProcessId);
    }

    [Fact]
    public async Task Acquire_ShouldStoreOwningProcessIdWithTimeToLive()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Act
        await OnWorkerThread(() => sut.Acquire(_lockTimeToLive));

        // Assert
        Assert.True(Repository.Contains(cacheKey), "The lock must be stored before Acquire returns");
        var (found, owner) = await OnWorkerThread(() =>
        {
            var success = sut.TryGetOwner(out var processId);
            return (success, processId);
        });
        Assert.True(found);
        Assert.Equal(CurrentProcessId, owner);
        var timeToLive = await OnWorkerThread(sut.GetTimeToLive);
        Assert.InRange(timeToLive, TimeSpan.FromMinutes(4), _lockTimeToLive);
    }

    [Fact]
    public async Task Acquire_ShouldRenewTimeToLive_WhenCalledAgain()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);
        await OnWorkerThread(() => sut.Acquire(TimeSpan.FromMinutes(1)));

        // Act
        await OnWorkerThread(() => sut.Acquire(TimeSpan.FromMinutes(30)));

        // Assert
        var timeToLive = await OnWorkerThread(sut.GetTimeToLive);
        Assert.InRange(timeToLive, TimeSpan.FromMinutes(29), TimeSpan.FromMinutes(30));
    }

    [Fact]
    public async Task TryGetOwner_ShouldReturnFalse_WhenLockDoesNotExist()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);

        // Act
        var (found, owner) = await OnWorkerThread(() =>
        {
            var success = sut.TryGetOwner(out var processId);
            return (success, processId);
        });

        // Assert
        Assert.False(found);
        Assert.Equal(0, owner);
    }

    [Fact]
    public async Task TryGetOwner_ShouldReturnOwnerProcessId_WhenAnotherProcessHoldsTheLock()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var anotherProcessLock = new PagedRequestLock(cacheKey, AnotherProcessId);
        await OnWorkerThread(() => anotherProcessLock.Acquire(_lockTimeToLive));
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Act
        var (found, owner) = await OnWorkerThread(() =>
        {
            var success = sut.TryGetOwner(out var processId);
            return (success, processId);
        });

        // Assert
        Assert.True(found);
        Assert.Equal(AnotherProcessId, owner);
    }

    [Fact]
    public async Task GetTimeToLive_ShouldReturnZero_WhenLockDoesNotExist()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);

        // Act
        var timeToLive = await OnWorkerThread(sut.GetTimeToLive);

        // Assert
        Assert.Equal(TimeSpan.Zero, timeToLive);
    }

    [Fact]
    public async Task GetTimeToLive_ShouldReturnRemainingTime_WhenLockIsHeld()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);
        await OnWorkerThread(() => sut.Acquire(_lockTimeToLive));

        // Act
        var timeToLive = await OnWorkerThread(sut.GetTimeToLive);

        // Assert
        Assert.InRange(timeToLive, TimeSpan.FromMinutes(4), _lockTimeToLive);
    }

    [Fact]
    public async Task Release_ShouldRemoveLock()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);
        await OnWorkerThread(() => sut.Acquire(_lockTimeToLive));

        // Act
        await OnWorkerThread(sut.Release);

        // Assert
        Assert.False(Repository.Contains(cacheKey));
        var found = await OnWorkerThread(() => sut.TryGetOwner(out _));
        Assert.False(found);
    }

    [Fact]
    public async Task Release_ShouldNotThrow_WhenLockDoesNotExist()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);

        // Act
        var exception = await Record.ExceptionAsync(() => OnWorkerThread(sut.Release));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public async Task IsHeldByAnotherProcess_ShouldReturnFalse_WhenLockDoesNotExist()
    {
        // Arrange
        var sut = new PagedRequestLock(NewCacheKey(), CurrentProcessId);

        // Act
        var (held, timeToWait) = await OnWorkerThread(() =>
        {
            var result = sut.IsHeldByAnotherProcess(out var wait);
            return (result, wait);
        });

        // Assert
        Assert.False(held);
        Assert.Equal(TimeSpan.Zero, timeToWait);
    }

    [Fact]
    public async Task IsHeldByAnotherProcess_ShouldReturnFalse_WhenCurrentProcessHoldsTheLock()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);
        await OnWorkerThread(() => sut.Acquire(_lockTimeToLive));

        // Act
        var (held, timeToWait) = await OnWorkerThread(() =>
        {
            var result = sut.IsHeldByAnotherProcess(out var wait);
            return (result, wait);
        });

        // Assert
        Assert.False(held);
        Assert.Equal(TimeSpan.Zero, timeToWait);
        Assert.True(Repository.Contains(cacheKey), "The lock held by this process must be kept");
    }

    [Fact]
    public async Task IsHeldByAnotherProcess_ShouldReturnTrueWithTimeToWait_WhenAnotherProcessHoldsTheLock()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var anotherProcessLock = new PagedRequestLock(cacheKey, AnotherProcessId);
        await OnWorkerThread(() => anotherProcessLock.Acquire(_lockTimeToLive));
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Act
        var (held, timeToWait) = await OnWorkerThread(() =>
        {
            var result = sut.IsHeldByAnotherProcess(out var wait);
            return (result, wait);
        });

        // Assert
        Assert.True(held);
        Assert.InRange(timeToWait, TimeSpan.FromMinutes(4), _lockTimeToLive);
        Assert.True(Repository.Contains(cacheKey), "A live lock of another process must be kept");
    }

    [Fact]
    public async Task IsHeldByAnotherProcess_ShouldReleaseLockAndReturnFalse_WhenLockHasNoTimeToLiveLeft()
    {
        // Arrange: another process holds the lock, but the repository reports no TTL for it
        // (the behavior of CrispyWaffle's MemoryCacheRepository, which never expires entries).
        var cacheKey = NewCacheKey();
        await Repository.SetAsync(AnotherProcessId, cacheKey);
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Act
        var (held, timeToWait) = await OnWorkerThread(() =>
        {
            var result = sut.IsHeldByAnotherProcess(out var wait);
            return (result, wait);
        });

        // Assert
        Assert.False(held);
        Assert.Equal(TimeSpan.Zero, timeToWait);
        Assert.False(Repository.Contains(cacheKey), "A lock with no TTL left must be released");
    }

    [Fact]
    public async Task IsHeldByAnotherProcess_ShouldReturnFalse_WhenLockOfAnotherProcessHasExpired()
    {
        // Arrange
        var cacheKey = NewCacheKey();
        var anotherProcessLock = new PagedRequestLock(cacheKey, AnotherProcessId);
        await OnWorkerThread(() => anotherProcessLock.Acquire(TimeSpan.FromMilliseconds(-1)));
        var sut = new PagedRequestLock(cacheKey, CurrentProcessId);

        // Act
        var (held, timeToWait) = await OnWorkerThread(() =>
        {
            var result = sut.IsHeldByAnotherProcess(out var wait);
            return (result, wait);
        });

        // Assert
        Assert.False(held);
        Assert.Equal(TimeSpan.Zero, timeToWait);
    }

    private static string NewCacheKey() => $"PagedRequestLockTests_{Guid.NewGuid():N}";

    /// <summary>
    /// <see cref="PagedRequestWrapper"/> drives the lock from a worker thread with no
    /// synchronization context (<see cref="Task.Run(Action)"/>). The tests do the same, so the
    /// synchronous bridge over the async <c>CacheManager</c> API runs exactly as in production
    /// and never blocks xUnit's own synchronization context.
    /// </summary>
    private static Task OnWorkerThread(Action action) => Task.Run(action);

    private static Task<T> OnWorkerThread<T>(Func<T> function) => Task.Run(function);
}
