using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestBusinessRuleRestrictionException(
    string businessRuleName,
    string errorMessage,
    ServiceRequest request,
    ServiceResponse response
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestBusinessRuleRestrictionException,
            businessRuleName,
            errorMessage
        ),
        request,
        response
    )
{
    public string BusinessRuleName { get; } = businessRuleName;

    public string ErrorMessage { get; } = errorMessage;
}
