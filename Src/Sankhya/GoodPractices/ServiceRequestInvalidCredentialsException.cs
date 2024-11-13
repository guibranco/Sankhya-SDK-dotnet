using System;
using System.Runtime.Serialization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestInvalidCredentialsException : Exception
{
    public ServiceRequestInvalidCredentialsException()
        : base(Resources.ServiceRequestInvalidCredentialsException) { }

    protected ServiceRequestInvalidCredentialsException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
