using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

public sealed class SystemWarning
{
    private SankhyaWarningLevel _importance;

    private bool _importanceSet;

    private string _title;

    private bool _titleSet;

    private string _description;

    private bool _descriptionSet;

    private string _tip;

    private bool _tipSet;

    private SystemWarningRecipient[] _recipients;

    private bool _recipientsSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeImportanceInternal() => _importanceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTitle() => _titleSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTip() => _tipSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecipients() => _recipientsSet;
}
