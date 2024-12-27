using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestExternalException(
    ServiceName service,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestExternalException,
            service.GetHumanReadableValue()
        ),
        request,
        response
    );
