using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// The message unlink shipping class.
/// </summary>
[Serializer]
[XmlRoot("msgDesvincularRemessa")]
public sealed class MessageUnlinkShipping
{
    /// <summary>
    /// The value
    /// </summary>
    private string _value;

    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    [XmlText]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    /// <summary>
    /// Should the serialize value.
    /// </summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValue() => _valueSet;
}
