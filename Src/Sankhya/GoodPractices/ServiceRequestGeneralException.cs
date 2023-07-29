namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using System.Xml;
using CrispyWaffle.GoodPractices;
using CrispyWaffle.Serialization;
using Sankhya.Service;

[Serializable]
public class ServiceRequestGeneralException : Exception, IXmlServiceException
{
    private readonly ServiceRequest _request;

    private readonly ServiceResponse _response;

    public ServiceRequestGeneralException() { }

    protected ServiceRequestGeneralException(string message, ServiceRequest request)
        : base(message)
    {
        _request = request;
        _response = null;
    }

    protected ServiceRequestGeneralException(
        string message,
        ServiceRequest request,
        Exception innerException
    )
        : base(message, innerException)
    {
        _request = request;
        _response = null;
    }

    protected ServiceRequestGeneralException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(message)
    {
        _request = request;
        _response = response;
    }

    protected ServiceRequestGeneralException(
        string message,
        ServiceRequest request,
        ServiceResponse response,
        Exception innerException
    )
        : base(message, innerException)
    {
        _request = request;
        _response = response;
    }

    protected ServiceRequestGeneralException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public XmlDocument Request => _request != null ? _request.GetSerializer() : new XmlDocument();

    public XmlDocument Response =>
        _response != null ? _response.GetSerializer() : new XmlDocument();
}
