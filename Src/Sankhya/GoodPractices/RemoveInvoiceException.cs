using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class RemoveInvoiceException(
    int singleNumber,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(CultureInfo.CurrentCulture, Resources.RemoveInvoiceException, singleNumber),
        request,
        innerException
    );
