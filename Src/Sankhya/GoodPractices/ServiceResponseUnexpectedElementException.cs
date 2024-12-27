using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an unexpected element is encountered in a service response.
/// </summary>
/// <param name="elementName">The name of the unexpected element.</param>
/// <param name="serviceName">The name of the service where the unexpected element was found.</param>
/// <param name="response">The service response containing the unexpected element.</param>
public class ServiceResponseUnexpectedElementException(
    string elementName,
    string serviceName,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceResponseUnexpectedElementException,
            elementName,
            serviceName
        ),
        null,
        response
    );
