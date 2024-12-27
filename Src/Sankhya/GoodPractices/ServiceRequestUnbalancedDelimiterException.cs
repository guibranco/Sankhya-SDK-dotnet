using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request contains unbalanced delimiters.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestUnbalancedDelimiterException, request);
