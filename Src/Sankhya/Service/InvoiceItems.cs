using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Transport;

namespace Sankhya.Service;

[XmlRoot("items")]
public sealed class InvoiceItems
{
    private int _singleNumber;

    private bool _singleNumberSet;

    private bool _onlineUpdate;

    private bool _onlineUpdateSet;

    private bool _informPrice;

    private bool _informPriceSet;

    private InvoiceItem[] _items;

    private bool _itemsSet;

    [XmlAttribute("NUNOTA")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    [XmlIgnore]
    public bool OnlineUpdate
    {
        get => _onlineUpdate;
        set
        {
            _onlineUpdate = value;
            _onlineUpdateSet = true;
        }
    }

    [XmlAttribute("ATUALIZACAO_ONLINE")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string OnlineUpdateInternal
    {
        get => _onlineUpdate.ToString(@"S", @"N");
        set
        {
            _onlineUpdate = value.ToBoolean();
            _onlineUpdateSet = true;
        }
    }

    [XmlIgnore]
    public bool InformPrice
    {
        get => _informPrice;
        set
        {
            _informPrice = value;
            _informPriceSet = true;
        }
    }

    [XmlElement("INFORMARPRECO")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string InformPriceInternal
    {
        get => _informPrice.ToString(@"True", @"False");
        set
        {
            _informPrice = value.ToBoolean(@"True|False");
            _informPriceSet = true;
        }
    }

    [XmlElement("item")]
    public InvoiceItem[] Items
    {
        get => _items;
        set
        {
            _items = value;
            _itemsSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOnlineUpdate() => _onlineUpdateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInformPrice() => _informPriceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeItems() => _itemsSet;
}
