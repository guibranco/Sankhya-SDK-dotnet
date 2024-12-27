using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when there is an issue with paginating a service request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestPaginationException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestPaginationException, request);
