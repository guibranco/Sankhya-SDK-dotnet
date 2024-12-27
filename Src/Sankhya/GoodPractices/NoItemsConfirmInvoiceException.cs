using System;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
