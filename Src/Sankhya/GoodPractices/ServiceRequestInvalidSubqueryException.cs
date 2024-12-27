using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidSubQueryException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestInvalidSubQueryException, request);
