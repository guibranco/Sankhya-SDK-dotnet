using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class InvalidServiceQueryOptionsExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            var service = ServiceName.CrudFind;
            var expectedMessage = string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceQueryOptionsException,
                service.GetHumanReadableValue()
            );

            // Act
            var exception = new InvalidServiceQueryOptionsException(service);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldBeOfTypeException()
        {
            // Arrange
            var service = ServiceName.CrudFind;

            // Act
            var exception = new InvalidServiceQueryOptionsException(service);

            // Assert
            Assert.IsAssignableFrom<Exception>(exception);
        }
    }
}
