using System;
using System.Runtime.Serialization;
using System.Xml;
using CrispyWaffle.GoodPractices;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestInvalidOperationException : Exception, IXmlServiceException
{
    public ServiceRequestInvalidOperationException(XmlDocument response, Exception innerException)
        : base(Resources.ServiceRequestInvalidOperationException, innerException)
    {
        Request = new();
        Response = response;
    }

    protected ServiceRequestInvalidOperationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }

    #region Implementation of IServiceException


    public XmlDocument Request { get; }

    public XmlDocument Response { get; }

    #endregion
}
