using System;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class PagedRequestException(ServiceRequest request, Exception innerException)
    : ServiceRequestGeneralException(Resources.PagedRequestException, request, innerException);
