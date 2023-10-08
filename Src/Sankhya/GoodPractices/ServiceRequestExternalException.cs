using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestExternalException : ServiceRequestTemporarilyException
{
    public ServiceRequestExternalException(
        ServiceName service,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestExternalException,
                service.GetHumanReadableValue()
            ),
            request,
            response
        ) { }

    protected ServiceRequestExternalException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
