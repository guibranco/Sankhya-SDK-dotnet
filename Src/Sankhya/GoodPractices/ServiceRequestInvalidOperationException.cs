using System;
using System.Xml;
using CrispyWaffle.GoodPractices;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidOperationException : Exception, IXmlServiceException
{
    public ServiceRequestInvalidOperationException(XmlDocument response, Exception innerException)
        : base(Resources.ServiceRequestInvalidOperationException, innerException)
    {
        Request = new();
        Response = response;
    }

    public XmlDocument Request { get; }

    public XmlDocument Response { get; }
}
