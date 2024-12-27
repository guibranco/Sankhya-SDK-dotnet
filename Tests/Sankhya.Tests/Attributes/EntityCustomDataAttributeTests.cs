using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityCustomDataAttributeTests
{
    [Fact]
    public void MaxLength_ShouldBeSetAndRetrievedCorrectly()
    {
        // Arrange
        var attribute = new EntityCustomDataAttribute();
        var expectedMaxLength = 100;

        // Act
        attribute.MaxLength = expectedMaxLength;

        // Assert
        Assert.Equal(expectedMaxLength, attribute.MaxLength);
    }

    [Fact]
    public void AttributeUsage_ShouldAllowClassAndPropertyAndAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(
                typeof(EntityCustomDataAttribute),
                typeof(AttributeUsageAttribute)
            );

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.True(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Class));
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Property));
    }
}
