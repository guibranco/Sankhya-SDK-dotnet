using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerStateInscriptionException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerStateInscriptionException,
        request
    );
