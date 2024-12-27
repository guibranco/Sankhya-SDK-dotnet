using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when there is an issue with a specific attribute
/// in a service request.
/// </summary>
/// <param name="attributeName">The name of the attribute that caused the exception.</param>
/// <param name="service">The service associated with the request.</param>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestAttributeException(
    string attributeName,
    ServiceName service,
    ServiceRequest request
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestAttributeException,
            service.GetHumanReadableValue(),
            attributeName
        ),
        request
    );
