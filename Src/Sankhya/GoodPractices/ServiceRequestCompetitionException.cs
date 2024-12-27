using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestCompetitionException(ServiceRequest request, ServiceResponse response)
    : ServiceRequestTemporarilyException(
        Resources.ServiceRequestCompetitionException,
        request,
        response
    );
