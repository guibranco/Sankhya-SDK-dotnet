using System;
using System.Linq;
using System.Reflection;
using NSubstitute;
using Sankhya.Attributes;
using Sankhya.Transport;
using Sankhya.Validations;
using Xunit;

namespace Sankhya.Tests.Validators
{
    public class EntityValidatorTests
    {
        [Fact]
        public void ValidateEntities_InvalidEntityType_ThrowsException()
        {
            // Arrange
            var assembly = Substitute.For<Assembly>();
            var invalidEntityType = typeof(InvalidEntity);
            assembly.GetTypes().Returns(new[] { invalidEntityType });

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => EntityValidator.ValidateEntities(assembly)
            );
        }

        [Fact]
        public void ValidateEntities_ValidEntityType_DoesNotThrowException()
        {
            // Arrange
            var assembly = Substitute.For<Assembly>();
            var validEntityType = typeof(ValidEntity);
            assembly.GetTypes().Returns(new[] { validEntityType });

            // Act & Assert
            EntityValidator.ValidateEntities(assembly);
        }

        [Fact]
        public void ValidateEntityType_InvalidEntityType_ThrowsException()
        {
            // Arrange
            var type = typeof(InvalidEntity);

            // Act & Assert
            var method = typeof(EntityValidator).GetMethod(
                "ValidateEntityType",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            Assert.Throws<TargetInvocationException>(
                () => method.Invoke(null, new object[] { type })
            );
        }

        [Fact]
        public void ValidateEntityType_ValidEntityType_DoesNotThrowException()
        {
            // Arrange
            var type = typeof(ValidEntity);

            // Act & Assert
            var method = typeof(EntityValidator).GetMethod(
                "ValidateEntityType",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            method.Invoke(null, new object[] { type });
        }

        [Fact]
        public void ValidateProperty_InvalidProperty_ThrowsException()
        {
            // Arrange
            var type = typeof(InvalidEntity);
            var property = type.GetProperty("InvalidProperty");

            // Act & Assert
            var method = typeof(EntityValidator).GetMethod(
                "ValidateProperty",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            Assert.Throws<TargetInvocationException>(
                () => method.Invoke(null, new object[] { type, property })
            );
        }

        [Fact]
        public void ValidateProperty_ValidProperty_DoesNotThrowException()
        {
            // Arrange
            var type = typeof(ValidEntity);
            var property = type.GetProperty("ValidProperty");

            // Act & Assert
            var method = typeof(EntityValidator).GetMethod(
                "ValidateProperty",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            method.Invoke(null, new object[] { type, property });
        }

        [Fact]
        public void ImplementsIEquatable_TypeImplementsIEquatable_ReturnsTrue()
        {
            // Arrange
            var type = typeof(ValidEntity);

            // Act
            var result = EntityValidator.ImplementsIEquatable(type);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ImplementsIEquatable_TypeDoesNotImplementIEquatable_ReturnsFalse()
        {
            // Arrange
            var type = typeof(InvalidEntity);

            // Act
            var result = EntityValidator.ImplementsIEquatable(type);

            // Assert
            Assert.False(result);
        }
    }

    [Entity("test")]
    public class ValidEntity : IEntity, IEquatable<ValidEntity>
    {
        [EntityElement("testElement")]
        public string ValidProperty { get; set; }

        public bool ShouldSerializeValidProperty() => true;

        public bool Equals(ValidEntity other) => true;
    }

    public class InvalidEntity : IEntity
    {
        public string InvalidProperty { get; set; }
    }
}
