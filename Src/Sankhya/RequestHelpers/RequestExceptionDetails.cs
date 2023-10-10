using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Service;

namespace Sankhya.RequestHelpers;

public class RequestExceptionDetails
{
    public Exception Exception { get; set; }

    public ServiceName ServiceName { get; set; }

    public ServiceAttribute ServiceDetails { get; set; }

    public ServiceRequest Request { get; set; }
}
