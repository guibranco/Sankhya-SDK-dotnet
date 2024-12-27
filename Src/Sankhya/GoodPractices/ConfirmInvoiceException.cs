using System;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
