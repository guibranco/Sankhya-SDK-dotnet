namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

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
