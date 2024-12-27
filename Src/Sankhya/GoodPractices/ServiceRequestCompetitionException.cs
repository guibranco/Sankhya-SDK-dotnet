using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs when there is a competition issue with a service request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the exception.</param>
public class ServiceRequestCompetitionException(ServiceRequest request, ServiceResponse response)
    : ServiceRequestTemporarilyException(
        Resources.ServiceRequestCompetitionException,
        request,
        response
    );
