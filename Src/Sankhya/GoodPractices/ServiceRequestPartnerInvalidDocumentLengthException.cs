using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request partner's document length is invalid.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestPartnerInvalidDocumentLengthException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerInvalidDocumentLengthException,
        request
    );
