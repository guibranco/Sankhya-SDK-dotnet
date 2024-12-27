using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class SystemMessage
{
    private string _content;

    private bool _contentSet;

    private SystemWarningRecipient[] _recipients;

    private bool _recipientsSet;

    [XmlElement("conteudo")]
    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            _contentSet = true;
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
    public bool ShouldSerializeContent() => _contentSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecipients() => _recipientsSet;
}
