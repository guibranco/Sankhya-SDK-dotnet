using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidSubQueryException : ServiceRequestGeneralException
{
    public ServiceRequestInvalidSubQueryException(ServiceRequest request)
        : base(Resources.ServiceRequestInvalidSubQueryException, request) { }
}
