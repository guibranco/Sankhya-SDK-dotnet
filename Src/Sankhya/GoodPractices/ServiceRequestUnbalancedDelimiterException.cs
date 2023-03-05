namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestUnbalancedDelimiterException : ServiceRequestGeneralException
{
    public ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
        : base(Resources.ServiceRequestUnbalancedDelimiterException, request)
    { }

    protected ServiceRequestUnbalancedDelimiterException(SerializationInfo info, StreamingContext context)
    { }
}