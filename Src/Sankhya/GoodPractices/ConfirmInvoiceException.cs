using System;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an invoice confirmation fails.
/// </summary>
/// <param name="singleNumber">The single number of the invoice that failed to confirm.</param>
/// <param name="request">The service request associated with the invoice confirmation.</param>
/// <param name="innerException">The exception that caused the invoice confirmation to fail.</param>
public class ConfirmInvoiceException(
    int singleNumber,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            "Unable to confirm invoice with single number: {0}",
            singleNumber
        ),
        request,
        innerException
    );
