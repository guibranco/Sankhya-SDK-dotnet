using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request returns too many results.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the request.</param>
/// <param name="resultLength">The number of results returned by the service request.</param>
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
