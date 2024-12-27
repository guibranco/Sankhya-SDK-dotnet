using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request is unavailable.
/// </summary>
/// <param name="service">The service that is unavailable.</param>
/// <param name="request">The service request that was made.</param>
/// <param name="response">The response received from the service.</param>
public class ServiceRequestUnavailableException(
    ServiceName service,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestUnavailableException,
            service.GetHumanReadableValue()
        ),
        request,
        response
    );
