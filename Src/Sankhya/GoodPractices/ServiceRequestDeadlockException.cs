using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when a service request encounters a deadlock.
/// </summary>
/// <param name="message">The message that describes the error.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the exception.</param>
public class ServiceRequestDeadlockException(
    string message,
    ServiceRequest request,
    ServiceResponse response
) : ServiceRequestTemporarilyException(message, request, response);
