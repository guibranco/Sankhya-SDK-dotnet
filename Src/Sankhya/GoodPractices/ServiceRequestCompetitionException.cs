namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestCompetitionException : ServiceRequestTemporarilyException
{
    public ServiceRequestCompetitionException(ServiceRequest request, ServiceResponse response)
        : base(Resources.ServiceRequestCompetitionException, request, response)
    { }

    protected ServiceRequestCompetitionException(SerializationInfo info, StreamingContext context)
    { }
}