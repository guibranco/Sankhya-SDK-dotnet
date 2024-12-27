using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
}
