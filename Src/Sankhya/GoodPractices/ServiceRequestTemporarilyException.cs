using System;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when a service request fails temporarily.
/// </summary>
public class ServiceRequestTemporarilyException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestTemporarilyException"/> class.
    /// </summary>
    public ServiceRequestTemporarilyException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestTemporarilyException"/> class with a specified error message and service request.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    public ServiceRequestTemporarilyException(string message, ServiceRequest request)
        : base(message, request) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestTemporarilyException"/> class with a specified error message, service request, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        Exception innerException
    )
        : base(message, request, innerException) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestTemporarilyException"/> class with a specified error message, service request, and service response.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response associated with the exception.</param>
    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message, request, response) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestTemporarilyException"/> class with a specified error message, service request, service response, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response associated with the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ServiceRequestTemporarilyException(
        string message,
        ServiceRequest request,
        ServiceResponse response,
        Exception innerException
    )
        : base(message, request, response, innerException) { }
}
