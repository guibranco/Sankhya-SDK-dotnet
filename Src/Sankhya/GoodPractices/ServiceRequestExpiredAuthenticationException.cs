namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;

[Serializable]
public class ServiceRequestExpiredAuthenticationException : Exception
{
    public ServiceRequestExpiredAuthenticationException()
        : base(Resources.ServiceRequestExpiredAuthenticationException) { }

    protected ServiceRequestExpiredAuthenticationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
