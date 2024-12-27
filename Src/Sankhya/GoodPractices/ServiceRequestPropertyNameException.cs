using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when there is an issue with a property name in a service request.
/// </summary>
public class ServiceRequestPropertyNameException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestPropertyNameException"/> class with the specified property name and service request.
    /// </summary>
    /// <param name="propertyName">The name of the property that caused the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    public ServiceRequestPropertyNameException(string propertyName, ServiceRequest request)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyNameException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                string.Empty,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity
            ),
            request
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestPropertyNameException"/> class with the specified property name, entity name, and service request.
    /// </summary>
    /// <param name="propertyName">The name of the property that caused the exception.</param>
    /// <param name="entityName">The name of the entity that caused the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    public ServiceRequestPropertyNameException(
        string propertyName,
        string entityName,
        ServiceRequest request
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyNameException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                entityName,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity
            ),
            request
        ) { }
}
