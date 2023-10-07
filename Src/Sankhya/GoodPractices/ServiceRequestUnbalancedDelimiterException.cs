using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestUnbalancedDelimiterException : ServiceRequestGeneralException
{
    public ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
        : base(Resources.ServiceRequestUnbalancedDelimiterException, request) { }

    protected ServiceRequestUnbalancedDelimiterException(
        SerializationInfo info,
        StreamingContext context
    ) { }
}
