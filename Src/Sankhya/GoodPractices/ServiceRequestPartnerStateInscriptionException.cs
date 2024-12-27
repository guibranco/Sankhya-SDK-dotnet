using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when there is an issue with the partner state inscription in a service request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestPartnerStateInscriptionException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerStateInscriptionException,
        request
    );
