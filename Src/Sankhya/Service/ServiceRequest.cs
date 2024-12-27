using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Enums;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "serviceRequest")]
public sealed class ServiceRequest
{
    private ServiceName _service;

    private bool _serviceSet;

    private RequestBody _requestBody;

    private bool _requestBodySet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeServiceInternal() => _serviceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRequestBody() => _requestBodySet;

    public ServiceRequest()
    {
        Service = ServiceName.Test;
        RequestBody = new();
    }

    public ServiceRequest(ServiceName service)
    {
        Service = service;
        RequestBody = new();
    }
}
