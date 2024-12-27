using System;
using System.Globalization;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class InvalidKeyFileExceptionTests
{
    [Fact]
    public void Constructor_ShouldSetMessage()
    {
        // Arrange
        const string key = "invalidKey";
        var expectedMessage = string.Format(
            CultureInfo.CurrentCulture,
            Resources.InvalidKeyFileException,
            key
        );

        // Act
        var exception = new InvalidKeyFileException(key);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void Constructor_ShouldBeOfTypeException()
    {
        // Arrange
        const string key = "invalidKey";

        // Act
        var exception = new InvalidKeyFileException(key);

        // Assert
        Assert.IsAssignableFrom<Exception>(exception);
    }
}
