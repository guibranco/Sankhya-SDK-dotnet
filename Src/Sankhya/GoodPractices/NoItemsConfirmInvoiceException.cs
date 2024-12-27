using System;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an attempt is made to confirm an invoice that has no items.
/// </summary>
/// <param name="singleNumber">The invoice number that has no items.</param>
/// <param name="request">The service request associated with the invoice confirmation.</param>
/// <param name="innerException">The inner exception that caused this exception to be thrown.</param>
public class NoItemsConfirmInvoiceException(
    int singleNumber,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            "Invoice {0} has no items, cannot be confirmed",
            singleNumber
        ),
        request,
        innerException
    )
{
    public int SingleNumber { get; } = singleNumber;
}
