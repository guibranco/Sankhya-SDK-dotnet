using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestUnavailableException(
    ServiceName service,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestUnavailableException,
            service.GetHumanReadableValue()
        ),
        request,
        response
    );
