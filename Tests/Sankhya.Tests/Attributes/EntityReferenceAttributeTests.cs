using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityReferenceAttributeTests
{
    [Fact]
    public void Constructor_ShouldSetCustomRelationName()
    {
        // Arrange
        var expectedCustomRelationName = "TestRelation";

        // Act
        var attribute = new EntityReferenceAttribute(expectedCustomRelationName);

        // Assert
        Assert.Equal(expectedCustomRelationName, attribute.CustomRelationName);
    }

    [Fact]
    public void Constructor_ShouldSetDefaultCustomRelationName()
    {
        // Arrange
        var expectedCustomRelationName = string.Empty;

        // Act
        var attribute = new EntityReferenceAttribute();

        // Assert
        Assert.Equal(expectedCustomRelationName, attribute.CustomRelationName);
    }

    [Fact]
    public void AttributeUsage_ShouldAllowPropertyAndNotAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(
                typeof(EntityReferenceAttribute),
                typeof(AttributeUsageAttribute)
            );

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.False(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Property));
    }
}
