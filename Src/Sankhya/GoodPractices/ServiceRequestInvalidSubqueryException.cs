using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request contains an invalid subquery.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestInvalidSubQueryException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestInvalidSubQueryException, request);
