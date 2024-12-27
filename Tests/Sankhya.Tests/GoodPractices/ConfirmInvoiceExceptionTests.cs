using System;
using System.Globalization;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class ConfirmInvoiceExceptionTests
{
    [Fact]
    public void Constructor_ShouldSetMessage()
    {
        // Arrange
        const int singleNumber = 123;
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        var innerException = new Exception("Inner exception message");
        var expectedMessage = string.Format(
            CultureInfo.CurrentCulture,
            "Unable to confirm invoice with single number: {0}",
            singleNumber
        );

        // Act
        var exception = new ConfirmInvoiceException(singleNumber, request, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void Constructor_ShouldSetRequest()
    {
        // Arrange
        const int singleNumber = 123;
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocument = request.GetSerializer();
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new ConfirmInvoiceException(singleNumber, request, innerException);

        // Assert
        Assert.Equal(xmlDocument, exception.Request);
    }

    [Fact]
    public void Constructor_ShouldSetInnerException()
    {
        // Arrange
        const int singleNumber = 123;
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new ConfirmInvoiceException(singleNumber, request, innerException);

        // Assert
        Assert.Equal(innerException, exception.InnerException);
    }
}
