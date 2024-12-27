using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityElementAttributeTests
{
    [Fact]
    public void Constructor_ShouldSetElementNameAndIgnoreInlineReference()
    {
        // Arrange
        var expectedElementName = "TestElement";
        var expectedIgnoreInlineReference = true;

        // Act
        var attribute = new EntityElementAttribute(expectedElementName, true);

        // Assert
        Assert.Equal(expectedElementName, attribute.ElementName);
        Assert.Equal(expectedIgnoreInlineReference, attribute.IgnoreInlineReference);
    }

    [Fact]
    public void Constructor_ShouldSetElementNameAndDefaultIgnoreInlineReference()
    {
        // Arrange
        var expectedElementName = "TestElement";
        var expectedIgnoreInlineReference = false;

        // Act
        var attribute = new EntityElementAttribute(expectedElementName);

        // Assert
        Assert.Equal(expectedElementName, attribute.ElementName);
        Assert.Equal(expectedIgnoreInlineReference, attribute.IgnoreInlineReference);
    }

    [Fact]
    public void AttributeUsage_ShouldAllowPropertyAndAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(
                typeof(EntityElementAttribute),
                typeof(AttributeUsageAttribute)
            );

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.True(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Property));
    }
}
