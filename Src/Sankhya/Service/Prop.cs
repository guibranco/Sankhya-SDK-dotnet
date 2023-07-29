namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;

/// <summary>
/// Class Prop. This class cannot be inherited.
/// </summary>
public sealed class Prop
{
    #region Private Members

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

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
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [XmlAttribute("name")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    [XmlAttribute("value")]
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

    #region Serializer Helpers

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize value.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValue() => _valueSet;

    #endregion
}
