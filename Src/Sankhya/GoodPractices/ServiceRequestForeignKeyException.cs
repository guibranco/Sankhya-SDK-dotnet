using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
