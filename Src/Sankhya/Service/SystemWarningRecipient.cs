namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

/// <summary>
/// Class SystemWarningRecipient. This class cannot be inherited.
/// </summary>
public sealed class SystemWarningRecipient
{
    #region Private Members

    /// <summary>
    /// The identifier
    /// </summary>
    private int _id;

    /// <summary>
    /// The identifier set
    /// </summary>
    private bool _idSet;

    /// <summary>
    /// The type
    /// </summary>
    private SankhyaWarningType _type;

    /// <summary>
    /// The type set
    /// </summary>
    private bool _typeSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [XmlAttribute("id")]
    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            _idSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [XmlIgnore]
    public SankhyaWarningType Type
    {
        get => _type;
        set
        {
            _type = value;
            _typeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type internal.
    /// </summary>
    /// <value>The type internal.</value>
    [XmlAttribute("tipo")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue();
        set
        {
            _type = EnumExtensions.GetEnumByInternalValueAttribute<SankhyaWarningType>(value);
            _typeSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeId() => _idSet;

    /// <summary>
    /// Should the serialize type internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTypeInternal() => _typeSet;

    #endregion
}
