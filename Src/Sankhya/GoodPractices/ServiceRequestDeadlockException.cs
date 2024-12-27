using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestDeadlockException(
    string message,
    ServiceRequest request,
    ServiceResponse response
) : ServiceRequestTemporarilyException(message, request, response);
