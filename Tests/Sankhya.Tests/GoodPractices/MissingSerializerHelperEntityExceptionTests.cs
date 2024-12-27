using System.Globalization;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class MissingSerializerHelperEntityExceptionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var propertyName = "TestProperty";
            var entityName = "TestEntity";
            var fullyQualifiedClassName = "Namespace.TestClass";

            // Act
            var exception = new MissingSerializerHelperEntityException(
                propertyName,
                entityName,
                fullyQualifiedClassName
            );

            // Assert
            Assert.Equal(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.MissingSerializerHelperEntityException,
                    propertyName,
                    entityName,
                    fullyQualifiedClassName
                ),
                exception.Message
            );
        }
    }
}
