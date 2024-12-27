using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request has invalid authorization.
/// </summary>
public class ServiceRequestInvalidAuthorizationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestInvalidAuthorizationException"/> class.
    /// </summary>
    public ServiceRequestInvalidAuthorizationException()
        : base(Resources.ServiceRequestInvalidAuthorizationException) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestInvalidAuthorizationException"/> class with a specified inner exception.
    /// </summary>
    /// <param name="innerException">The inner exception.</param>
    public ServiceRequestInvalidAuthorizationException(Exception innerException)
        : base(Resources.ServiceRequestInvalidAuthorizationException, innerException) { }
}
