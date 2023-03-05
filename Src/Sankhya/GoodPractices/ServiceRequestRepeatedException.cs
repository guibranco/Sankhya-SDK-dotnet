namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestRepeatedException : ServiceRequestGeneralException
{
    public ServiceRequestRepeatedException(ServiceRequest request)
        : base(Resources.ServiceRequestRepeatedException, request)
    { }

    protected ServiceRequestRepeatedException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}