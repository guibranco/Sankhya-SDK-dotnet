﻿using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class ClientEvents. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot("clientEvents")]
public sealed class ClientEvents
{
    /// <summary>
    /// The client event
    /// </summary>
    private ClientEvent[] _clientEvent;

    /// <summary>
    /// The client event set
    /// </summary>
    private bool _clientEventSet;

    /// <summary>
    /// Gets or sets the client event.
    /// </summary>
    /// <value>The client event.</value>
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

    /// <summary>
    /// Should the serialize client event.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvent() => _clientEventSet;
}
