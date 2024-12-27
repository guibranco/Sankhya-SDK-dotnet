using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
public sealed class ClientEvent
{
    private string _id;

    private bool _idSet;

    private Event _event;

    private bool _eventSet;

    private ClientEventInvoiceItem[] _invoiceItems;

    private bool _invoiceItemsSet;

    private string _text;

    private bool _textSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeId() => _idSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEvent() => _eventSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceItems() => _invoiceItemsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;
}
