using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceResponseUnexpectedElementException : ServiceRequestGeneralException
{
    public ServiceResponseUnexpectedElementException(
        string elementName,
        string serviceName,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceResponseUnexpectedElementException,
                elementName,
                serviceName
            ),
            null,
            response
        ) { }
}
