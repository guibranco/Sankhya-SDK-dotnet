using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceResponseUnexpectedElementException(
    string elementName,
    string serviceName,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceResponseUnexpectedElementException,
            elementName,
            serviceName
        ),
        null,
        response
    );
