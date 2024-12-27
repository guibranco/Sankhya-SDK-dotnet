using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerFiscalClassificationException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerFiscalClassificationException,
        request
    );
