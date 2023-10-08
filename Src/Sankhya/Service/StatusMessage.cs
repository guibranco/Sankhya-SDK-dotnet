using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

/// <summary>
/// Class StatusMessage. This class cannot be inherited.
/// </summary>
public sealed class StatusMessage
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
    /// <value>The value.</value>
    [XmlIgnore]
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
    /// Gets or sets the value internal.
    /// </summary>
    /// <value>The value internal.</value>
    [XmlText]
    public string ValueInternal
    {
        get => _value.ToBase64();
        set
        {
            _value = value.FromBase64();
            _valueSet = true;
        }
    }

    /// <summary>
    /// Should the serialize value internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueInternal() => _valueSet;
}
