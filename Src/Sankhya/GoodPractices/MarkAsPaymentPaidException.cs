using System;
using System.Collections.Generic;
using System.Globalization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class MarkAsPaymentPaidException(
    IEnumerable<int> financialNumbers,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            "Unable to low payments for financial numbers {0}",
            string.Join(@",", financialNumbers)
        ),
        request,
        innerException
    );
