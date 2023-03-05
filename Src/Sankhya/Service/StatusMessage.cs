namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

/// <summary>
/// Class StatusMessage. This class cannot be inherited.
/// </summary>
public sealed class StatusMessage
{
    #region Private Members

    /// <summary>
    /// The value
    /// </summary>
    private string _value;
    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    #endregion

    #region Public Properties

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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize value internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueInternal() => _valueSet;

    #endregion

}