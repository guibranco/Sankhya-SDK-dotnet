using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request times out.
/// </summary>
/// <param name="service">The service that timed out.</param>
/// <param name="request">The service request that caused the timeout.</param>
public class ServiceRequestTimeoutException(ServiceName service, ServiceRequest request)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestTimeoutException,
            service.GetHumanReadableValue()
        ),
        request
    );
