using System.Globalization;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidExpressionException : ServiceRequestGeneralException
{
    public ServiceRequestInvalidExpressionException(
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestInvalidExpressionException,
                request?.Service == ServiceName.CrudServiceFind
                    ? request.RequestBody.DataSet.LiteralCriteria.Expression
                    : request?.RequestBody.Entity.LiteralCriteria.Expression
            ),
            request,
            response
        ) { }
}
