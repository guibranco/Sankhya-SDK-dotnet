using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestInaccessibleException : ServiceRequestTemporarilyException
{
    public ServiceRequestInaccessibleException(
        string host,
        int port,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestInaccessibleException,
                host,
                port
            ),
            request,
            innerException
        ) { }

    protected ServiceRequestInaccessibleException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
