using System;
using Sankhya.Attributes;
using Sankhya.Enums;
using Xunit;

namespace Sankhya.Tests.Attributes;

public class ServiceAttributeTests
{
    [Fact]
    public void Constructor_ShouldSetModuleCategoryAndType()
    {
        // Arrange
        var expectedModule = ServiceModule.Mge;
        var expectedCategory = ServiceCategory.Crud;
        var expectedType = ServiceType.Transactional;

        // Act
        var attribute = new ServiceAttribute(expectedModule, expectedCategory, expectedType);

        // Assert
        Assert.Equal(expectedModule, attribute.Module);
        Assert.Equal(expectedCategory, attribute.Category);
        Assert.Equal(expectedType, attribute.Type);
    }

    [Fact]
    public void AttributeUsage_ShouldAllowFieldAndNotAllowMultiple()
    {
        // Arrange & Act
        var attributeUsage = (AttributeUsageAttribute)
            Attribute.GetCustomAttribute(typeof(ServiceAttribute), typeof(AttributeUsageAttribute));

        // Assert
        Assert.NotNull(attributeUsage);
        Assert.False(attributeUsage.AllowMultiple);
        Assert.True(attributeUsage.ValidOn.HasFlag(AttributeTargets.Field));
    }
}
