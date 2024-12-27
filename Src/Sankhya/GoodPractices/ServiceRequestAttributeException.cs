using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestAttributeException(
    string attributeName,
    ServiceName service,
    ServiceRequest request
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestAttributeException,
            service.GetHumanReadableValue(),
            attributeName
        ),
        request
    );
