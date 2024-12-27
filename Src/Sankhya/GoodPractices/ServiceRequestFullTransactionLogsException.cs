using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs when full transaction logs are requested for a service request.
/// </summary>
/// <param name="database">The name of the database where the exception occurred.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the exception.</param>
public class ServiceRequestFullTransactionLogsException(
    string database,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestFullTransactionLogsException,
            database
        ),
        request,
        response
    )
{
    /// <summary>
    /// Gets the name of the database where the exception occurred.
    /// </summary>
    public string Database { get; } = database;
}
