using System;
using System.Runtime.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestDeadlockException : ServiceRequestTemporarilyException
{
    public ServiceRequestDeadlockException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message, request, response) { }

    protected ServiceRequestDeadlockException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
