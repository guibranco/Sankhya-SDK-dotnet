using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot("clientEvents")]
public sealed class ClientEvents
{
    private ClientEvent[] _clientEvent;

    private bool _clientEventSet;

    [XmlElement("clientEvent")]
    public ClientEvent[] ClientEvent
    {
        get => _clientEvent;
        set
        {
            _clientEvent = value;
            _clientEventSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvent() => _clientEventSet;
}
