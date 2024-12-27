using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a foreign key constraint is violated during a service request.
/// </summary>
/// <param name="table">The name of the table where the foreign key constraint was violated.</param>
/// <param name="column">The name of the column where the foreign key constraint was violated.</param>
/// <param name="request">The service request that caused the foreign key constraint violation.</param>
/// <param name="response">The service response associated with the request.</param>
public class ServiceRequestForeignKeyException(
    string table,
    string column,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestForeignKeyException,
            table,
            column
        ),
        request,
        response
    );
