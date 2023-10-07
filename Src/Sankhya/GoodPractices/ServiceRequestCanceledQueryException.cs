using System;
using System.Runtime.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestCanceledQueryException : ServiceRequestGeneralException
{
    public ServiceRequestCanceledQueryException(string message, ServiceRequest request)
        : base(message, request) { }

    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        Exception innerException
    )
        : base(message, request, innerException) { }

    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message, request, response) { }

    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        ServiceResponse response,
        Exception innerException
    )
        : base(message, request, response, innerException) { }

    protected ServiceRequestCanceledQueryException(SerializationInfo info, StreamingContext context)
    { }
}
