using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request results in a duplicated document.
/// </summary>
/// <param name="name">The name associated with the duplicated document.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the request.</param>
public class ServiceRequestDuplicatedDocumentException(
    string name,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestDuplicatedDocumentException,
            name
        ),
        request,
        response
    );
