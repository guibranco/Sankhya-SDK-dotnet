using System;
using System.Globalization;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class UnlinkShippingExceptionTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        int financialNumber = 123;
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocument = request.GetSerializer();
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new UnlinkShippingException(financialNumber, request, innerException);

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.UnlinkShippingException,
                financialNumber
            ),
            exception.Message
        );
        Assert.Equal(xmlDocument, exception.Request);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void Constructor_ShouldNotThrowException_WhenRequestIsNull()
    {
        // Arrange
        int financialNumber = 123;
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new UnlinkShippingException(financialNumber, null, innerException);

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.UnlinkShippingException,
                financialNumber
            ),
            exception.Message
        );
        Assert.Empty(exception.Request.InnerXml);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void Constructor_ShouldNotThrowException_WhenInnerExceptionIsNull()
    {
        // Arrange
        int financialNumber = 123;
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocument = request.GetSerializer();
        Exception innerException = null;

        // Act
        var exception = new UnlinkShippingException(financialNumber, request, innerException);

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.UnlinkShippingException,
                financialNumber
            ),
            exception.Message
        );
        Assert.Equal(xmlDocument, exception.Request);
        Assert.Null(exception.InnerException);
    }
}
