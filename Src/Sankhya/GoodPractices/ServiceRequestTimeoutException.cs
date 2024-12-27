using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestTimeoutException(ServiceName service, ServiceRequest request)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestTimeoutException,
            service.GetHumanReadableValue()
        ),
        request
    );
