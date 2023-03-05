namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

/// <summary>
/// The message unlink shipping class.
/// </summary>
[Serializer]
[XmlRoot("msgDesvincularRemessa")]
public sealed class MessageUnlinkShipping
{
    #region Private fields 

    /// <summary>
    /// The value
    /// </summary>
    private string _value;

    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    #endregion

    #region Public properties

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

    #endregion

    #region Serializer helpers

    /// <summary>
    /// Should the serialize value.
    /// </summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValue() => _valueSet;

    #endregion

}