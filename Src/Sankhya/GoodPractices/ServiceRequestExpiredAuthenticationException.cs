using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestExpiredAuthenticationException : Exception
{
    public ServiceRequestExpiredAuthenticationException()
        : base(Resources.ServiceRequestExpiredAuthenticationException) { }
}
