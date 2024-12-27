using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestFileNotFoundException(ServiceRequest request)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestFileNotFoundException,
            request?.RequestBody.Config.Path
        ),
        request
    );
