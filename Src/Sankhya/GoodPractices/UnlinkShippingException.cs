using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs when unlinking a shipping request fails.
/// </summary>
/// <param name="financialNumber">The financial number associated with the request.</param>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="innerException">The exception that is the cause of the current exception.</param>
public class UnlinkShippingException(
    int financialNumber,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.UnlinkShippingException,
            financialNumber
        ),
        request,
        innerException
    );
