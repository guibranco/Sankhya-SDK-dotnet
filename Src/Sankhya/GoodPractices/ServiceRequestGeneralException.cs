using System;
using System.Xml;
using CrispyWaffle.GoodPractices;
using CrispyWaffle.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents a general exception that occurs during a service request.
/// </summary>
public class ServiceRequestGeneralException : Exception, IXmlServiceException
{
    /// <summary>
    /// The service request associated with the exception.
    /// </summary>
    private readonly ServiceRequest _request;

    /// <summary>
    /// The service response associated with the exception.
    /// </summary>
    private readonly ServiceResponse _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class.
    /// </summary>
    public ServiceRequestGeneralException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class with a specified error message and service request.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request associated with the exception.</param>
    protected ServiceRequestGeneralException(string message, ServiceRequest request)
        : base(message)
    {
        _request = request;
        _response = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class with a specified error message, service request, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request associated with the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
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
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class with a specified error message, service request, and service response.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request associated with the exception.</param>
    /// <param name="response">The service response associated with the exception.</param>
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
    /// Initializes a new instance of the <see cref="ServiceRequestGeneralException"/> class with a specified error message, service request, service response, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request associated with the exception.</param>
    /// <param name="response">The service response associated with the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
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
    /// Gets the XML representation of the service request.
    /// </summary>
    public XmlDocument Request => _request != null ? _request.GetSerializer() : new XmlDocument();

    /// <summary>
    /// Gets the XML representation of the service response.
    /// </summary>
    public XmlDocument Response =>
        _response != null ? _response.GetSerializer() : new XmlDocument();
}
