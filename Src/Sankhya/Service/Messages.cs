using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot("mensagens")]
public sealed class Messages
{
    private Message[] _message;

    private bool _messageSet;

    [XmlElement("msg")]
    public Message[] Message
    {
        get => _message;
        set
        {
            _message = value;
            _messageSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessage() => _messageSet;
}
