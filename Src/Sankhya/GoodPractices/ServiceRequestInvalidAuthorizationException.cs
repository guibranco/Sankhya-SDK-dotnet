namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;

[Serializable]
public class ServiceRequestInvalidAuthorizationException : Exception
{
    public ServiceRequestInvalidAuthorizationException()
        : base(Resources.ServiceRequestInvalidAuthorizationException) { }

    public ServiceRequestInvalidAuthorizationException(Exception innerException)
        : base(Resources.ServiceRequestInvalidAuthorizationException, innerException) { }

    protected ServiceRequestInvalidAuthorizationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
