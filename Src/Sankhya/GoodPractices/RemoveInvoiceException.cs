namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class RemoveInvoiceException : ServiceRequestGeneralException
{
    public RemoveInvoiceException(
        int singleNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.RemoveInvoiceException,
                singleNumber
            ),
            request,
            innerException
        ) { }

    protected RemoveInvoiceException(SerializationInfo info, StreamingContext context) { }
}
