using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when there is an issue with a property value in a service request.
/// </summary>
/// <param name="propertyName">The name of the property that caused the exception.</param>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestPropertyValueException(string propertyName, ServiceRequest request)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestPropertyValueException,
            request?.Service.GetHumanReadableValue(),
            propertyName,
            request?.RequestBody.Entity?.Name
                ?? request?.RequestBody.Entity?.RootEntity
                ?? request?.RequestBody.DataSet.RootEntity
        ),
        request
    )
{
    /// <summary>
    /// The name of the property that caused the exception.
    /// </summary>
    public string PropertyName { get; private set; } = propertyName;
}
