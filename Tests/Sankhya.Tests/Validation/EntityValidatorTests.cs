using System;
using System.Reflection;
using Xunit;
using Sankhya.Validation;

namespace Sankhya.Tests.Validation
{
    public class EntityValidatorTests
    {
        [Fact]
        public void ValidateEntities_ShouldThrowException_ForNonCompliantEntity()
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                EntityValidator.ValidateEntities(assembly));

            Assert.Contains("must have a parameterless constructor", exception.Message);
        }

        [Fact]
        public void ValidateEntities_ShouldNotThrowException_ForCompliantEntity()
        {
            // Arrange
            var assembly = Assembly.GetExecutingAssembly();

            // Act & Assert
            var exception = Record.Exception(() =>
                EntityValidator.ValidateEntities(assembly));

            Assert.Null(exception);
        }

        // Mock entity classes for testing
        [Entity("CompliantEntity")]
        private class CompliantEntity : IEntity
        {
            public CompliantEntity() { }
        }

        [Entity("NonCompliantEntity")]
        private class NonCompliantEntity : IEntity
        {
            public NonCompliantEntity(string param) { }
        }
    }
}

