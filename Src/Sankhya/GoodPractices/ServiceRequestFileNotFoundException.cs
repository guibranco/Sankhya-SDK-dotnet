using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request file is not found.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestFileNotFoundException(ServiceRequest request)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestFileNotFoundException,
            request?.RequestBody.Config.Path
        ),
        request
    );
