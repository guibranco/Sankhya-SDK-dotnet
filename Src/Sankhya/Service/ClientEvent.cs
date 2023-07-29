namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

/// <summary>
/// Class ClientEvent. This class cannot be inherited.
/// </summary>
[Serializer]
public sealed class ClientEvent
{
    #region Private Members

    /// <summary>
    /// The identifier
    /// </summary>
    private string _id;

    /// <summary>
    /// The identifier set
    /// </summary>
    private bool _idSet;

    /// <summary>
    /// The event
    /// </summary>
    private Event _event;

    /// <summary>
    /// The event set
    /// </summary>
    private bool _eventSet;

    /// <summary>
    /// The invoice items
    /// </summary>
    private ClientEventInvoiceItem[] _invoiceItems;

    /// <summary>
    /// The invoice items set
    /// </summary>
    private bool _invoiceItemsSet;

    /// <summary>
    /// The text
    /// </summary>
    private string _text;

    /// <summary>
    /// The text set
    /// </summary>
    private bool _textSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [XmlAttribute("id")]
    public string Id
    {
        get => _id;
        set
        {
            _id = value;
            _idSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the event.
    /// </summary>
    /// <value>The event.</value>
    [XmlElement("event")]
    public Event Event
    {
        get => _event;
        set
        {
            _event = value;
            _eventSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice items.
    /// </summary>
    /// <value>The invoice items.</value>
    [XmlElement("itemNota")]
    public ClientEventInvoiceItem[] InvoiceItems
    {
        get => _invoiceItems;
        set
        {
            _invoiceItems = value;
            _invoiceItemsSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    [XmlText]
    [Localizable(false)]
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _textSet = true;
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
    /// Should the serialize event.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEvent() => _eventSet;

    /// <summary>
    /// Should the serialize invoice items.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceItems() => _invoiceItemsSet;

    /// <summary>
    /// Should the serialize text.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;

    #endregion
}
