using System;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when a service request is canceled during a query operation.
/// </summary>
public class ServiceRequestCanceledQueryException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestCanceledQueryException"/> class with a specified error message and the service request that caused the exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    public ServiceRequestCanceledQueryException(string message, ServiceRequest request)
        : base(message, request) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestCanceledQueryException"/> class with a specified error message, the service request that caused the exception, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        Exception innerException
    )
        : base(message, request, innerException) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestCanceledQueryException"/> class with a specified error message, the service request that caused the exception, and the service response associated with the request.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response associated with the request.</param>
    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message, request, response) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestCanceledQueryException"/> class with a specified error message, the service request that caused the exception, the service response associated with the request, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response associated with the request.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ServiceRequestCanceledQueryException(
        string message,
        ServiceRequest request,
        ServiceResponse response,
        Exception innerException
    )
        : base(message, request, response, innerException) { }
}
