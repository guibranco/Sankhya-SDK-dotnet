using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when there is an issue with the fiscal classification
/// of a partner in a service request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestPartnerFiscalClassificationException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerFiscalClassificationException,
        request
    );
