using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPartnerInvalidDocumentLengthException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerInvalidDocumentLengthException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerInvalidDocumentLengthException, request) { }
}
