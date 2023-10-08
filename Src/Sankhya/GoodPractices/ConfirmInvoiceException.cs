using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ConfirmInvoiceException : ServiceRequestGeneralException
{
    public ConfirmInvoiceException(
        int singleNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                "Unable to confirm invoice with single number: {0}",
                singleNumber
            ),
            request,
            innerException
        ) { }

    protected ConfirmInvoiceException(SerializationInfo info, StreamingContext context) { }
}
