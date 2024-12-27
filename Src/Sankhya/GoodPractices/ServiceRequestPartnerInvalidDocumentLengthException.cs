using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerInvalidDocumentLengthException(ServiceRequest request)
    : ServiceRequestGeneralException(
        Resources.ServiceRequestPartnerInvalidDocumentLengthException,
        request
    );
