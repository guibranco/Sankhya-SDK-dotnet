using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Enums;

namespace Sankhya.Service;

/// <summary>
/// A service request.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "serviceRequest")]
public sealed class ServiceRequest
{
    /// <summary>
    /// The service
    /// </summary>
    private ServiceName _service;

    /// <summary>
    /// The service set
    /// </summary>
    private bool _serviceSet;

    /// <summary>
    /// The request body
    /// </summary>
    private RequestBody _requestBody;

    /// <summary>
    /// The request body set
    /// </summary>
    private bool _requestBodySet;

    /// <summary>
    /// The Service Name as SankhyaService enum
    /// </summary>
    /// <value>The service.</value>

    [XmlIgnore]
    public ServiceName Service
    {
        get => _service;
        set
        {
            _service = value;
            _serviceSet = true;
        }
    }

    /// <summary>
    /// The Service Name as String (SankhyaService - InternalValueAttribute)
    /// </summary>
    /// <value>The service internal.</value>

    [XmlAttribute("serviceName")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ServiceInternal
    {
        get => _service.GetInternalValue();
        set
        {
            _service = EnumExtensions.GetEnumByInternalValueAttribute<ServiceName>(value);
            _serviceSet = true;
        }
    }

    /// <summary>
    /// The Request Body element
    /// </summary>
    /// <value>The request body.</value>

    [XmlElement("requestBody")]
    public RequestBody RequestBody
    {
        get => _requestBody;
        set
        {
            _requestBody = value;
            _requestBodySet = true;
        }
    }

    /// <summary>
    /// Should the serialize service internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeServiceInternal() => _serviceSet;

    /// <summary>
    /// Should the serialize request body.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRequestBody() => _requestBodySet;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceRequest()
    {
        Service = ServiceName.Test;
        RequestBody = new();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="service">The service.</param>
    public ServiceRequest(ServiceName service)
    {
        Service = service;
        RequestBody = new();
    }
}
