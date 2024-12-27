using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
    public string Database { get; } = database;
}
