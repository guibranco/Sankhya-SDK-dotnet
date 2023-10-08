using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestPropertyNameException : ServiceRequestGeneralException
{
    public ServiceRequestPropertyNameException(string propertyName, ServiceRequest request)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyNameException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                string.Empty,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity
            ),
            request
        ) { }

    public ServiceRequestPropertyNameException(
        string propertyName,
        string entityName,
        ServiceRequest request
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyNameException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                entityName,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity
            ),
            request
        ) { }

    protected ServiceRequestPropertyNameException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
