using System;
using Sankhya.Attributes;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class EntityIgnoreAttributeTests
{
    [Fact]
    public void AttributeUsage_ShouldAllowPropertyAndAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(
                typeof(EntityIgnoreAttribute),
                typeof(AttributeUsageAttribute)
            );

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.True(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Property));
    }
}
