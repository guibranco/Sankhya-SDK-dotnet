using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestPaginationException : ServiceRequestGeneralException
{
    public ServiceRequestPaginationException(ServiceRequest request)
        : base(Resources.ServiceRequestPaginationException, request) { }

    protected ServiceRequestPaginationException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
