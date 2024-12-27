using System;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class PagedRequestExceptionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocument = request.GetSerializer();
            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new PagedRequestException(request, innerException);

            // Assert
            Assert.Equal(Resources.PagedRequestException, exception.Message);
            Assert.Equal(xmlDocument, exception.Request);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}
