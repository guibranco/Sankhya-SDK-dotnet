using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request is repeated.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestRepeatedException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestRepeatedException, request);
