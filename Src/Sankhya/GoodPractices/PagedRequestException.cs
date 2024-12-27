using System;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that occurs during a paged request.
/// </summary>
/// <param name="request">The service request that caused the exception.</param>
/// <param name="innerException">The exception that is the cause of the current exception.</param>
public class PagedRequestException(ServiceRequest request, Exception innerException)
    : ServiceRequestGeneralException(Resources.PagedRequestException, request, innerException);
