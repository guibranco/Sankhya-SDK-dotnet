using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request fails due to invalid credentials.
/// </summary>
/// <remarks>
/// This exception is used to indicate that the credentials provided for a service request are invalid.
/// </remarks>
public class ServiceRequestInvalidCredentialsException()
    : Exception(Resources.ServiceRequestInvalidCredentialsException);
