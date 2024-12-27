using System;
using System.Globalization;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class NoItemsConfirmInvoiceExceptionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int singleNumber = 123;
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocument = request.GetSerializer();
            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new NoItemsConfirmInvoiceException(
                singleNumber,
                request,
                innerException
            );

            // Assert
            Assert.Equal(
                string.Format(
                    CultureInfo.CurrentCulture,
                    "Invoice {0} has no items, cannot be confirmed",
                    singleNumber
                ),
                exception.Message
            );
            Assert.Equal(xmlDocument, exception.Request);
            Assert.Equal(innerException, exception.InnerException);
            Assert.Equal(singleNumber, exception.SingleNumber);
        }
    }
}
