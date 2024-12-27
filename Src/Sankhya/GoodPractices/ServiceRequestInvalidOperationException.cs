using System;
using System.Xml;
using CrispyWaffle.GoodPractices;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidOperationException(XmlDocument response, Exception innerException)
    : Exception(Resources.ServiceRequestInvalidOperationException, innerException),
        IXmlServiceException
{
    public XmlDocument Request { get; } = new();

    public XmlDocument Response { get; } = response;
}
