namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestAttributeException : ServiceRequestGeneralException
{
    public ServiceRequestAttributeException(string attributeName, ServiceName service, ServiceRequest request)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.ServiceRequestAttributeException, service.GetHumanReadableValue(), attributeName), request)
    { }

    protected ServiceRequestAttributeException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}