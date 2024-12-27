using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestAttributeException : ServiceRequestGeneralException
{
    public ServiceRequestAttributeException(
        string attributeName,
        ServiceName service,
        ServiceRequest request
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestAttributeException,
                service.GetHumanReadableValue(),
                attributeName
            ),
            request
        ) { }
}
