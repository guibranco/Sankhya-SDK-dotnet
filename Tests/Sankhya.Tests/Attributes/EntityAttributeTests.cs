using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityAttributeTests
{
    [Fact]
    public void Constructor_ShouldSetNameProperty()
    {
        // Arrange
        var expectedName = "TestEntity";

        // Act
        var attribute = new EntityAttribute(expectedName);

        // Assert
        Assert.Equal(expectedName, attribute.Name);
    }

    [Fact]
    public void AttributeUsage_ShouldBeClassOnlyAndNotInherited()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(typeof(EntityAttribute), typeof(AttributeUsageAttribute));

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.Equal(AttributeTargets.Class, attributeUsage.ValidOn);
        Assert.False(attributeUsage.Inherited);
    }
}
