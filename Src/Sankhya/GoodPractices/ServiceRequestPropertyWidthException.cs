using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a property width exceeds the allowed limit in a service request.
/// </summary>
/// <param name="propertyName">The name of the property that exceeded the width limit.</param>
/// <param name="request">The service request that contains the property.</param>
/// <param name="widthAllowed">The maximum allowed width for the property.</param>
/// <param name="currentWidth">The current width of the property that caused the exception.</param>
public class ServiceRequestPropertyWidthException(
    string propertyName,
    ServiceRequest request,
    int widthAllowed,
    int currentWidth
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestPropertyWidthException,
            request?.Service.GetHumanReadableValue(),
            propertyName,
            request?.RequestBody.Entity?.Name
                ?? request?.RequestBody.Entity?.RootEntity
                ?? request?.RequestBody.DataSet.RootEntity,
            currentWidth,
            widthAllowed
        ),
        request
    )
{
    /// <summary>
    /// The name of the property that exceeded the width limit.
    /// </summary>
    public string PropertyName { get; } = propertyName;

    /// <summary>
    /// The maximum allowed width for the property.
    /// </summary>
    public int AllowedWidth { get; } = widthAllowed;
}
