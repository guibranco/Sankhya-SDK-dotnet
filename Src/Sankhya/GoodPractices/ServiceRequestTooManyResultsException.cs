using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestTooManyResultsException(
    ServiceRequest request,
    ServiceResponse response,
    int resultLength
)
    : ServiceRequestGeneralException(
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
    );
