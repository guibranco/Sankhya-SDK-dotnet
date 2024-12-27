using System.Globalization;
using System.Xml;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class ServiceRequestAttributeExceptionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var attributeName = "TestAttribute";
            var service = ServiceName.InvoiceInclude;
            var request = new ServiceRequest(service);
            XmlDocument xmlDocument = request.GetSerializer();

            // Act
            var exception = new ServiceRequestAttributeException(attributeName, service, request);

            // Assert
            Assert.Equal(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ServiceRequestAttributeException,
                    service.GetHumanReadableValue(),
                    attributeName
                ),
                exception.Message
            );
            Assert.Equal(xmlDocument, exception.Request);
        }

        [Fact]
        public void Constructor_ShouldNotThrowException_WhenRequestIsNull()
        {
            // Arrange
            var attributeName = "TestAttribute";
            var service = ServiceName.InvoiceInclude;

            // Act
            var exception = new ServiceRequestAttributeException(attributeName, service, null);

            // Assert
            Assert.Equal(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ServiceRequestAttributeException,
                    service.GetHumanReadableValue(),
                    attributeName
                ),
                exception.Message
            );
            Assert.Empty(exception.Request.InnerXml);
        }
    }
}
