using System;
using Sankhya.Enums;
using Sankhya.RequestWrappers;
using Sankhya.Transport;
using Sankhya.ValueObjects;
using Xunit;

namespace Sankhya.Tests.ValueObjects;

public class OnDemandRequestInstanceTests
{
    [Fact]
    public void Properties_ShouldSetAndGetValues()
    {
        // Arrange
        var expectedKey = Guid.NewGuid();
        var expectedService = ServiceName.CrudFind;
        var expectedType = typeof(string);
        var expectedInstance = new MockOnDemandRequestWrapper();

        // Act
        var requestInstance = new OnDemandRequestInstance
        {
            Key = expectedKey,
            Service = expectedService,
            Type = expectedType,
            Instance = expectedInstance,
        };

        // Assert
        Assert.Equal(expectedKey, requestInstance.Key);
        Assert.Equal(expectedService, requestInstance.Service);
        Assert.Equal(expectedType, requestInstance.Type);
        Assert.Equal(expectedInstance, requestInstance.Instance);
    }
}

// Mock implementation of IOnDemandRequestWrapper for testing purposes
public class MockOnDemandRequestWrapper : IOnDemandRequestWrapper
{
    public void Add(IEntity entity) { }

    public void Flush() { }

    public void Dispose() { }
}
