using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestRepeatedException : ServiceRequestGeneralException
{
    public ServiceRequestRepeatedException(ServiceRequest request)
        : base(Resources.ServiceRequestRepeatedException, request) { }
}
