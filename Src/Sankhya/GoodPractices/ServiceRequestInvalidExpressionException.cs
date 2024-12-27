using System.Globalization;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an invalid expression is encountered in a service request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the request.</param>
public class ServiceRequestInvalidExpressionException(
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestInvalidExpressionException,
            request?.Service == ServiceName.CrudServiceFind
                ? request.RequestBody.DataSet.LiteralCriteria.Expression
                : request?.RequestBody.Entity.LiteralCriteria.Expression
        ),
        request,
        response
    );
