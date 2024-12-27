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

public class RemoveInvoiceExceptionTests
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
        var exception = new RemoveInvoiceException(singleNumber, request, innerException);

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.RemoveInvoiceException,
                singleNumber
            ),
            exception.Message
        );
        Assert.Equal(xmlDocument, exception.Request);
        Assert.Equal(innerException, exception.InnerException);
    }
}
