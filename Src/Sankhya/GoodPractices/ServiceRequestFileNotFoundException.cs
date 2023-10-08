using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestFileNotFoundException : ServiceRequestGeneralException
{
    public ServiceRequestFileNotFoundException(ServiceRequest request)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestFileNotFoundException,
                request?.RequestBody.Config.Path
            ),
            request
        ) { }

    protected ServiceRequestFileNotFoundException(SerializationInfo info, StreamingContext context)
    { }
}
