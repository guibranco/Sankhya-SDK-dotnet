using System;
using System.Collections.Generic;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an attempt to mark payments as paid fails.
/// </summary>
/// <param name="financialNumbers">The collection of financial numbers for which the payments could not be marked as paid.</param>
/// <param name="request">The service request that was being processed when the exception occurred.</param>
/// <param name="innerException">The exception that caused the current exception.</param>
public class MarkAsPaymentPaidException(
    IEnumerable<int> financialNumbers,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            "Unable to low payments for financial numbers {0}",
            string.Join(@",", financialNumbers)
        ),
        request,
        innerException
    );
