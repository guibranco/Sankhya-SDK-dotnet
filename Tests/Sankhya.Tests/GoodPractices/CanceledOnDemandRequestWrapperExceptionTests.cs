using System;
using Sankhya.GoodPractices;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class CanceledOnDemandRequestWrapperExceptionTests
{
    [Fact]
    public void Constructor_ShouldSetMessage()
    {
        // Arrange
        var expectedMessage =
            "Cannot add new items to a cancelled on demand request wrapper instance";

        // Act
        var exception = new CanceledOnDemandRequestWrapperException();

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void Constructor_ShouldBeOfTypeException()
    {
        // Act
        var exception = new CanceledOnDemandRequestWrapperException();

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }
}
