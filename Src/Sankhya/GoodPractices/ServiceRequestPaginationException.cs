using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPaginationException : ServiceRequestGeneralException
{
    public ServiceRequestPaginationException(ServiceRequest request)
        : base(Resources.ServiceRequestPaginationException, request) { }
}
