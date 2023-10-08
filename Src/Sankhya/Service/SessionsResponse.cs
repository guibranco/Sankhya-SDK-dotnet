using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class SessionsResponse. This class cannot be inherited.
/// </summary>
[XmlType("SESSIONS")]
[Serializer]
public sealed class SessionsResponse
{
    /// <summary>
    /// The sessions
    /// </summary>
    private Session[] _sessions;

    /// <summary>
    /// The sessions set
    /// </summary>
    private bool _sessionsSet;

    /// <summary>
    /// Gets or sets the sessions.
    /// </summary>
    /// <value>The sessions.</value>
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

    /// <summary>
    /// Should the serializer sessions.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializerSessions() => _sessionsSet;
}
