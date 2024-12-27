using System.Globalization;
using System.Xml;
using CrispyWaffle.Serialization;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.Service;
using Xunit;

namespace Sankhya.Tests.GoodPractices;

public class ServiceRequestBusinessRuleRestrictionExceptionTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        const string businessRuleName = "TestRule";
        const string errorMessage = "Test error message";
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocumentRequest = request.GetSerializer();
        var response = new ServiceResponse();
        XmlDocument xmlDocumentResponse = response.GetSerializer();

        // Act
        var exception = new ServiceRequestBusinessRuleRestrictionException(
            businessRuleName,
            errorMessage,
            request,
            response
        );

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestBusinessRuleRestrictionException,
                businessRuleName,
                errorMessage
            ),
            exception.Message
        );
        Assert.Equal(xmlDocumentRequest, exception.Request);
        Assert.Equal(xmlDocumentResponse, exception.Response);
        Assert.Equal(businessRuleName, exception.BusinessRuleName);
        Assert.Equal(errorMessage, exception.ErrorMessage);
    }

    [Fact]
    public void Constructor_ShouldNotThrowException_WhenRequestIsNull()
    {
        // Arrange
        const string businessRuleName = "TestRule";
        const string errorMessage = "Test error message";
        var response = new ServiceResponse();
        XmlDocument xmlDocument = response.GetSerializer();

        // Act
        var exception = new ServiceRequestBusinessRuleRestrictionException(
            businessRuleName,
            errorMessage,
            null,
            response
        );

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestBusinessRuleRestrictionException,
                businessRuleName,
                errorMessage
            ),
            exception.Message
        );
        Assert.Empty(exception.Request.InnerXml);
        Assert.Equal(xmlDocument, exception.Response);
        Assert.Equal(businessRuleName, exception.BusinessRuleName);
        Assert.Equal(errorMessage, exception.ErrorMessage);
    }

    [Fact]
    public void Constructor_ShouldNotThrowException_WhenResponseIsNull()
    {
        // Arrange
        const string businessRuleName = "TestRule";
        const string errorMessage = "Test error message";
        var request = new ServiceRequest(ServiceName.InvoiceInclude);
        XmlDocument xmlDocument = request.GetSerializer();
        ServiceResponse response = null;

        // Act
        var exception = new ServiceRequestBusinessRuleRestrictionException(
            businessRuleName,
            errorMessage,
            request,
            response
        );

        // Assert
        Assert.Equal(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestBusinessRuleRestrictionException,
                businessRuleName,
                errorMessage
            ),
            exception.Message
        );
        Assert.Equal(xmlDocument, exception.Request);
        Assert.Empty(exception.Response.InnerXml);
        Assert.Equal(businessRuleName, exception.BusinessRuleName);
        Assert.Equal(errorMessage, exception.ErrorMessage);
    }
}
