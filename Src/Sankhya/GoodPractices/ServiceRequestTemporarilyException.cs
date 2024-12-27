using System;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestTemporarilyException : ServiceRequestGeneralException
{
    public ServiceRequestTemporarilyException() { }

    public ServiceRequestTemporarilyException(string message, ServiceRequest request)
        : base(message, request) { }

    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        Exception innerException
    )
        : base(message, request, innerException) { }

    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message, request, response) { }

    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        ServiceResponse response,
        Exception innerException
    )
        : base(message, request, response, innerException) { }
}
