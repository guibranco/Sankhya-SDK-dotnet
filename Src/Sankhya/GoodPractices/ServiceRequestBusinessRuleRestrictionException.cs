﻿using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a business rule restriction is violated during a service request.
/// </summary>
/// <param name="businessRuleName">The name of the business rule that was violated.</param>
/// <param name="errorMessage">The error message associated with the business rule violation.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="response">The service response associated with the exception.</param>
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
