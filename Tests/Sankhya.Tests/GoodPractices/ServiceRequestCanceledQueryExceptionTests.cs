using System;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices
{
    public class ServiceRequestCanceledQueryExceptionTests
    {
        [Fact]
        public void Constructor_WithMessageAndRequest_ShouldInitializeProperties()
        {
            // Arrange
            var message = "Test message";
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocument = request.GetSerializer();

            // Act
            var exception = new ServiceRequestCanceledQueryException(message, request);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(xmlDocument, exception.Request);
        }

        [Fact]
        public void Constructor_WithMessageRequestAndInnerException_ShouldInitializeProperties()
        {
            // Arrange
            var message = "Test message";
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocument = request.GetSerializer();
            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new ServiceRequestCanceledQueryException(
                message,
                request,
                innerException
            );

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(xmlDocument, exception.Request);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void Constructor_WithMessageRequestAndResponse_ShouldInitializeProperties()
        {
            // Arrange
            var message = "Test message";
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocumentRequest = request.GetSerializer();
            var response = new ServiceResponse();
            XmlDocument xmlDocumentResponse = response.GetSerializer();

            // Act
            var exception = new ServiceRequestCanceledQueryException(message, request, response);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(xmlDocumentRequest, exception.Request);
            Assert.Equal(xmlDocumentResponse, exception.Response);
        }

        [Fact]
        public void Constructor_WithMessageRequestResponseAndInnerException_ShouldInitializeProperties()
        {
            // Arrange
            var message = "Test message";
            var request = new ServiceRequest(ServiceName.InvoiceInclude);
            XmlDocument xmlDocumentRequest = request.GetSerializer();
            var response = new ServiceResponse();
            XmlDocument xmlDocumentResponse = response.GetSerializer();

            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new ServiceRequestCanceledQueryException(
                message,
                request,
                response,
                innerException
            );

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Equal(xmlDocumentRequest, exception.Request);
            Assert.Equal(xmlDocumentResponse, exception.Response);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}
