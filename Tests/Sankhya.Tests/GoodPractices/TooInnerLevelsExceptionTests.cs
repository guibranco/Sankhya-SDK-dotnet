using Sankhya.GoodPractices;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class TooInnerLevelsExceptionTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var entityName = "TestEntity";

        // Act
        var exception = new TooInnerLevelsException(entityName);

        // Assert
        Assert.Equal(
            $"Service Request with too inner entity references on entity {entityName}",
            exception.Message
        );
    }
}
