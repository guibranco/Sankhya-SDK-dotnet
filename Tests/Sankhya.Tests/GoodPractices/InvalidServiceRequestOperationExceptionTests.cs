using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class InvalidServiceRequestOperationExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            var service = ServiceName.CrudFind;
            var expectedMessage = string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceRequestOperationException,
                service.GetHumanReadableValue()
            );

            // Act
            var exception = new InvalidServiceRequestOperationException(service);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void Constructor_ShouldBeAssignableFromException()
        {
            // Arrange
            var service = ServiceName.CrudFind;

            // Act
            var exception = new InvalidServiceRequestOperationException(service);

            // Assert
            Assert.IsAssignableFrom<Exception>(exception);
        }
    }
}
