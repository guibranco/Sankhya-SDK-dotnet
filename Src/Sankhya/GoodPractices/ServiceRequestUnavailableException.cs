namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestUnavailableException : ServiceRequestTemporarilyException
{
    public ServiceRequestUnavailableException(ServiceName service, ServiceRequest request, ServiceResponse response)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.ServiceRequestUnavailableException, service.GetHumanReadableValue()), request, response)
    { }

    protected ServiceRequestUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}