using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestTimeoutException : ServiceRequestTemporarilyException
{
    public ServiceRequestTimeoutException(ServiceName service, ServiceRequest request)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestTimeoutException,
                service.GetHumanReadableValue()
            ),
            request
        ) { }

    protected ServiceRequestTimeoutException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
