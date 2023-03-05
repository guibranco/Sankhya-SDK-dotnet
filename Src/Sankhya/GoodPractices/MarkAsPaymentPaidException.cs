namespace Sankhya.GoodPractices;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Service;

[Serializable]
public class MarkAsPaymentPaidException : ServiceRequestGeneralException
{
    public MarkAsPaymentPaidException(IEnumerable<int> financialNumbers, ServiceRequest request, Exception innerException)
        : base(string.Format(CultureInfo.CurrentCulture, "Unable to low payments for financial numbers {0}", string.Join(@",", financialNumbers)), request, innerException)
    { }

    protected MarkAsPaymentPaidException(SerializationInfo info, StreamingContext context)
    { }
}