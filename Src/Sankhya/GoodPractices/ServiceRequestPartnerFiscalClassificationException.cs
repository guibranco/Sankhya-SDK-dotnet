using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerFiscalClassificationException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerFiscalClassificationException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerFiscalClassificationException, request) { }
}
