using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[XmlType("SESSIONS")]
[Serializer]
public sealed class SessionsResponse
{
    private Session[] _sessions;

    private bool _sessionsSet;

    [XmlElement("SESSION")]
    public Session[] Sessions
    {
        get => _sessions;
        set
        {
            _sessions = value;
            _sessionsSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializerSessions() => _sessionsSet;
}
