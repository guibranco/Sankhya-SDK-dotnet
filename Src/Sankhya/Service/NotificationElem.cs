using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

/// <summary>
/// Class NotificationElem. This class cannot be inherited.
/// </summary>
public sealed class NotificationElem
{
    /// <summary>
    /// The last notification
    /// </summary>
    private DateTime _lastNotification;

    /// <summary>
    /// The last notification set
    /// </summary>
    private bool _lastNotificationSet;

    /// <summary>
    /// Gets or sets the last notification.
    /// </summary>
    /// <value>The last notification.</value>
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

    /// <summary>
    /// Gets or sets the last notification internal.
    /// </summary>
    /// <value>The last notification internal.</value>
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

    /// <summary>
    /// Should the serialize last notification.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLastNotification() => _lastNotificationSet;
}
