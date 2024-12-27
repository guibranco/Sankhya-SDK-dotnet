using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestUnbalancedDelimiterException : ServiceRequestGeneralException
{
    public ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
        : base(Resources.ServiceRequestUnbalancedDelimiterException, request) { }
}
