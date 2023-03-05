namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestInvalidSubQueryException : ServiceRequestGeneralException
{
    public ServiceRequestInvalidSubQueryException(ServiceRequest request)
        : base(Resources.ServiceRequestInvalidSubQueryException, request)
    { }

    protected ServiceRequestInvalidSubQueryException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}