namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Service;

[Serializable]
public class NoItemsConfirmInvoiceException : ServiceRequestGeneralException
{
    public int SingleNumber { get; }

    public NoItemsConfirmInvoiceException(
        int singleNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                "Invoice {0} has no items, cannot be confirmed",
                singleNumber
            ),
            request,
            innerException
        ) => SingleNumber = singleNumber;

    protected NoItemsConfirmInvoiceException(SerializationInfo info, StreamingContext context) { }
}
