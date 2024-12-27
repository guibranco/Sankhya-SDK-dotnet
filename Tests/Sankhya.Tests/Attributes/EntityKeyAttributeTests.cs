using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityKeyAttributeTests
{
    [Fact]
    public void AttributeUsage_ShouldAllowPropertyAndNotAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(
                typeof(EntityKeyAttribute),
                typeof(AttributeUsageAttribute)
            );

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.False(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Property));
    }
}
