using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestUnbalancedDelimiterException, request);
