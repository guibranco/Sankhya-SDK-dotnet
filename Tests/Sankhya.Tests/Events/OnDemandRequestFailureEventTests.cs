using System;
using Sankhya.Events;
using Sankhya.Transport;
using Xunit;

namespace Sankhya.Tests.Events;

public class OnDemandRequestFailureEventTests
{
    [Fact]
    public void Constructor_ShouldSetEntityExceptionAndIsUpdate()
    {
        // Arrange
        var expectedEntity = new MockEntity();
        var expectedException = new Exception("Test exception");
        var expectedIsUpdate = true;

        // Act
        var eventInstance = new OnDemandRequestFailureEvent(
            expectedEntity,
            true,
            expectedException
        );

        // Assert
        Assert.Equal(expectedEntity, eventInstance.Entity);
        Assert.Equal(expectedException, eventInstance.Exception);
        Assert.Equal(expectedIsUpdate, eventInstance.IsUpdate);
    }
}

// Mock implementation of IEntity for testing purposes
public class MockEntity : IEntity
{
    // Implement necessary members of IEntity here
}
