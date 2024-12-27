using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception that is thrown when a service request fails due to expired authentication.
/// </summary>
public class ServiceRequestExpiredAuthenticationException()
    : Exception(Resources.ServiceRequestExpiredAuthenticationException);
