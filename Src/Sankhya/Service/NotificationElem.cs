using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class NotificationElem
{
    private DateTime _lastNotification;

    private bool _lastNotificationSet;

    [XmlIgnore]
    public DateTime LastNotification
    {
        get => _lastNotification;
        set
        {
            _lastNotification = value;
            _lastNotificationSet = true;
        }
    }

    [XmlAttribute("lastNotification")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int LastNotificationInternal
    {
        get => _lastNotification > DateTime.MinValue ? _lastNotification.ToUnixTimeStamp() : 0;
        set
        {
            _lastNotification = value.FromUnixTimeStamp();
            _lastNotificationSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLastNotification() => _lastNotificationSet;
}
