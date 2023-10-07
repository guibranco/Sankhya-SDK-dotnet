using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

/// <summary>
/// Class SystemWarning. This class cannot be inherited.
/// </summary>
public sealed class SystemWarning
{
    #region Private Members

    /// <summary>
    /// The importance
    /// </summary>
    private SankhyaWarningLevel _importance;

    /// <summary>
    /// The importance set
    /// </summary>
    private bool _importanceSet;

    /// <summary>
    /// The title
    /// </summary>
    private string _title;

    /// <summary>
    /// The title set
    /// </summary>
    private bool _titleSet;

    /// <summary>
    /// The description
    /// </summary>
    private string _description;

    /// <summary>
    /// The description set
    /// </summary>
    private bool _descriptionSet;

    /// <summary>
    /// The tip
    /// </summary>
    private string _tip;

    /// <summary>
    /// The tip set
    /// </summary>
    private bool _tipSet;

    /// <summary>
    /// The recipients
    /// </summary>
    private SystemWarningRecipient[] _recipients;

    /// <summary>
    /// The recipients set
    /// </summary>
    private bool _recipientsSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the importance.
    /// </summary>
    /// <value>The importance.</value>
    [XmlIgnore]
    public SankhyaWarningLevel Importance
    {
        get => _importance;
        set
        {
            _importance = value;
            _importanceSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the importance internal.
    /// </summary>
    /// <value>The importance internal.</value>
    [XmlAttribute("importancia")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ImportanceInternal
    {
        get => _importance.GetInternalValue();
        set =>
            _importance = EnumExtensions.GetEnumByInternalValueAttribute<SankhyaWarningLevel>(
                value
            );
    }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    [XmlElement(ElementName = "titulo")]
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            _titleSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [XmlElement(ElementName = "descricao")]
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            _descriptionSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the tip.
    /// </summary>
    /// <value>The tip.</value>
    [XmlElement(ElementName = "Dica")]
    public string Tip
    {
        get => _tip;
        set
        {
            _tip = value;
            _tipSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the recipients.
    /// </summary>
    /// <value>The recipients.</value>
    [XmlElement("destinatario")]
    public SystemWarningRecipient[] Recipients
    {
        get => _recipients;
        set
        {
            _recipients = value;
            _recipientsSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize importance internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeImportanceInternal() => _importanceSet;

    /// <summary>
    /// Should the serialize title.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTitle() => _titleSet;

    /// <summary>
    /// Should the serialize description.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    /// <summary>
    /// Should the serialize tip.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTip() => _tipSet;

    /// <summary>
    /// Should the serialize recipients.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecipients() => _recipientsSet;

    #endregion
}
