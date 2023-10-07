using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestBusinessRuleRestrictionException : ServiceRequestGeneralException
{
    public ServiceRequestBusinessRuleRestrictionException(
        string businessRuleName,
        string errorMessage,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
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
        BusinessRuleName = businessRuleName;
        ErrorMessage = errorMessage;
    }

    protected ServiceRequestBusinessRuleRestrictionException(
        SerializationInfo info,
        StreamingContext context
    ) { }

    public string BusinessRuleName { get; }

    public string ErrorMessage { get; }
}
