using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestTooManyResultsException : ServiceRequestGeneralException
{
    public ServiceRequestTooManyResultsException(
        ServiceRequest request,
        ServiceResponse response,
        int resultLength
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestTooManyResultsException,
                request?.Service.GetHumanReadableValue(),
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity,
                resultLength
            ),
            request,
            response
        ) { }

    protected ServiceRequestTooManyResultsException(
        SerializationInfo info,
        StreamingContext context
    ) { }
}
