using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidAuthorizationException : Exception
{
    public ServiceRequestInvalidAuthorizationException()
        : base(Resources.ServiceRequestInvalidAuthorizationException) { }

    public ServiceRequestInvalidAuthorizationException(Exception innerException)
        : base(Resources.ServiceRequestInvalidAuthorizationException, innerException) { }
}
