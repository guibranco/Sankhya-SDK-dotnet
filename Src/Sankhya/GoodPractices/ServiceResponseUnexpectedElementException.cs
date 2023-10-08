using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
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

    protected ServiceResponseUnexpectedElementException(
        SerializationInfo info,
        StreamingContext context
    ) { }
}
