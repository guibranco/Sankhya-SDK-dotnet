using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidCredentialsException : Exception
{
    public ServiceRequestInvalidCredentialsException()
        : base(Resources.ServiceRequestInvalidCredentialsException) { }
}
