using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class UnlinkShippingException : ServiceRequestGeneralException
{
    public UnlinkShippingException(
        int financialNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.UnlinkShippingException,
                financialNumber
            ),
            request,
            innerException
        ) { }

    protected UnlinkShippingException(SerializationInfo info, StreamingContext context) { }
}
