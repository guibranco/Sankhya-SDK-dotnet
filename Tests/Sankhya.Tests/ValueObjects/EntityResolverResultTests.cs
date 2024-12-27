using Sankhya.ValueObjects;
using Xunit;

namespace Sankhya.Tests.ValueObjects;

public class EntityResolverResultTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var expectedName = "TestEntity";

        // Act
        var result = new EntityResolverResult(expectedName);

        // Assert
        Assert.Equal(expectedName, result.Name);
        Assert.NotNull(result.FieldValues);
        Assert.Empty(result.FieldValues);
        Assert.NotNull(result.Keys);
        Assert.Empty(result.Keys);
        Assert.NotNull(result.Criteria);
        Assert.Empty(result.Criteria);
        Assert.NotNull(result.Fields);
        Assert.Empty(result.Fields);
        Assert.NotNull(result.References);
        Assert.Empty(result.References);
        Assert.NotNull(result.LiteralCriteria);
    }
}
