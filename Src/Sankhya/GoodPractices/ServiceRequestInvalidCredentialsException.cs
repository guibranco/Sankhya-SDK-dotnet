namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;

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
