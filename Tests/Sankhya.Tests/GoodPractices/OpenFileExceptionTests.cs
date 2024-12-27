using Sankhya.GoodPractices;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class OpenFileExceptionTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var key = "testKey";

        // Act
        var exception = new OpenFileException(key);

        // Assert
        Assert.Equal(
            $"Unable to open the file with the key {key} in the Sankhya file manager",
            exception.Message
        );
    }
}
