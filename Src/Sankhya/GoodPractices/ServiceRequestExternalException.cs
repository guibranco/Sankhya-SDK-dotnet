using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs during an external service request.
/// </summary>
/// <param name="service">The service name associated with the request.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response received when the exception occurred.</param>
public class ServiceRequestExternalException(
    ServiceName service,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestExternalException,
            service.GetHumanReadableValue()
        ),
        request,
        response
    );
