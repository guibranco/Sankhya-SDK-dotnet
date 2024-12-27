using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs when removing an invoice.
/// </summary>
/// <param name="singleNumber">The single number associated with the invoice.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="innerException">The inner exception that is the cause of this exception.</param>
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
