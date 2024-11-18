using System;
using System.Reflection;
using Sankhya.Validation;
using Xunit;

namespace Sankhya.Tests.Validation;

public class EntityValidatorTests
{
    [Fact]
    public void ValidateEntities_ShouldPassForValidEntities()
    {
        var assembly = Assembly.GetExecutingAssembly();
        EntityValidator.ValidateEntities(assembly);
    }

    [Fact]
    public void ValidateEntities_ShouldThrowForInvalidEntities()
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Simulate invalid entity setup
            // EntityValidator.ValidateEntities(assembly);
        });
    }
}
