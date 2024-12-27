using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerStateInscriptionException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerStateInscriptionException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerStateInscriptionException, request) { }
}
