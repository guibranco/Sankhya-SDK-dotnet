using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class SystemMessage. This class cannot be inherited.
/// </summary>
public sealed class SystemMessage
{
    #region Private Members

    /// <summary>
    /// The content
    /// </summary>
    private string _content;

    /// <summary>
    /// The content set
    /// </summary>
    private bool _contentSet;

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
    /// Gets or sets the content.
    /// </summary>
    /// <value>The content.</value>
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
    /// Should the content of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeContent() => _contentSet;

    /// <summary>
    /// Should the serialize recipients.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecipients() => _recipientsSet;

    #endregion
}
