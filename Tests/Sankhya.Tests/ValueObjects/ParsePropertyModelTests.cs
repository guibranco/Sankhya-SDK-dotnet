using Sankhya.Attributes;
using Sankhya.ValueObjects;
using Xunit;

namespace Sankhya.Tests.ValueObjects;

public class ParsePropertyModelTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Act
        var model = new ParsePropertyModel();

        // Assert
        Assert.True(model.IsCriteria);
        Assert.NotNull(model.CustomData);
        Assert.False(model.IsIgnored);
        Assert.False(model.IsEntityKey);
        Assert.False(model.IsEntityReference);
        Assert.False(model.IsEntityReferenceInline);
        Assert.False(model.IgnoreEntityReferenceInline);
        Assert.Null(model.PropertyName);
        Assert.Null(model.CustomRelationName);
    }

    [Fact]
    public void Properties_ShouldSetAndGetValues()
    {
        // Arrange
        var model = new ParsePropertyModel();
        var expectedCustomData = new EntityCustomDataAttribute { MaxLength = 100 };
        var expectedPropertyName = "TestProperty";
        var expectedCustomRelationName = "TestRelation";

        // Act
        model.IsIgnored = true;
        model.IsCriteria = false;
        model.IsEntityKey = true;
        model.IsEntityReference = true;
        model.IsEntityReferenceInline = true;
        model.IgnoreEntityReferenceInline = true;
        model.PropertyName = expectedPropertyName;
        model.CustomRelationName = expectedCustomRelationName;
        model.CustomData = expectedCustomData;

        // Assert
        Assert.True(model.IsIgnored);
        Assert.False(model.IsCriteria);
        Assert.True(model.IsEntityKey);
        Assert.True(model.IsEntityReference);
        Assert.True(model.IsEntityReferenceInline);
        Assert.True(model.IgnoreEntityReferenceInline);
        Assert.Equal(expectedPropertyName, model.PropertyName);
        Assert.Equal(expectedCustomRelationName, model.CustomRelationName);
        Assert.Equal(expectedCustomData, model.CustomData);
    }
}
