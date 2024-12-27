using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPaginationException(ServiceRequest request)
    : ServiceRequestGeneralException(Resources.ServiceRequestPaginationException, request);
