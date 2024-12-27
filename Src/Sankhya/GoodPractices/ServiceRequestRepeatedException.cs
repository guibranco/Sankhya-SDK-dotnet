using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestRepeatedException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestRepeatedException, request);
