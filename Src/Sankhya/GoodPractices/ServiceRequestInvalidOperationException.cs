using System;
using System.Xml;
using CrispyWaffle.GoodPractices;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request operation is invalid.
/// </summary>
/// <param name="response">The XML document containing the response.</param>
/// <param name="innerException">The exception that caused the current exception.</param>
public class ServiceRequestInvalidOperationException(XmlDocument response, Exception innerException)
    : Exception(Resources.ServiceRequestInvalidOperationException, innerException),
        IXmlServiceException
{
    /// <summary>
    /// The XML document containing the request.
    /// </summary>
    public XmlDocument Request { get; } = new();

    /// <summary>
    /// The XML document containing the response.
    /// </summary>
    public XmlDocument Response { get; } = response;
}
