using System.Runtime.Serialization;
using System.Xml;
using CrispyWaffle.GoodPractices;
using CrispyWaffle.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ServiceRequestGeneralException.
/// </summary>
[Serializable]
public class ServiceRequestGeneralException : Exception, IXmlServiceException
{
    /// <summary>
    /// The request.
    /// </summary>
    private readonly ServiceRequest _request;

    /// <summary>
    /// The response.
    /// </summary>
    private readonly ServiceResponse _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    public ServiceRequestGeneralException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="request">The request.</param>
    protected ServiceRequestGeneralException(string message, ServiceRequest request)
        : base(message)
    {
        _request = request;
        _response = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="request">The request.</param>
    /// <param name="innerException">The inner exception.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    /// <param name="innerException">The inner exception.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected ServiceRequestGeneralException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    /// <summary>
    /// Gets the request.
    /// </summary>
    /// <value>The request.</value>
    public XmlDocument Request => _request != null ? _request.GetSerializer() : new XmlDocument();

    /// <summary>
    /// Gets the response.
    /// </summary>
    /// <value>The response.</value>
    public XmlDocument Response =>
        _response != null ? _response.GetSerializer() : new XmlDocument();
}
