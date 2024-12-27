using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class MarkAsPaymentPaidExceptionTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var financialNumbers = new List<int> { 1, 2, 3 };
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocument = request.GetSerializer();
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new MarkAsPaymentPaidException(financialNumbers, request, innerException);

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                "Unable to low payments for financial numbers {0}",
                string.Join(",", financialNumbers)
            ),
            exception.Message
        );
        Assert.Equal(xmlDocument, exception.Request);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenFinancialNumbersIsNull()
    {
        // Arrange
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        var innerException = new Exception("Inner exception message");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () => new MarkAsPaymentPaidException(null, request, innerException)
        );
    }
}
