using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Transport;

namespace Sankhya.Service;

/// <summary>
/// Class InvoiceItems. This class cannot be inherited.
/// </summary>
[XmlRoot("items")]
public sealed class InvoiceItems
{
    /// <summary>
    /// The single number
    /// </summary>
    private int _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The online update
    /// </summary>
    private bool _onlineUpdate;

    /// <summary>
    /// The online update set
    /// </summary>
    private bool _onlineUpdateSet;

    /// <summary>
    /// The inform price
    /// </summary>
    private bool _informPrice;

    /// <summary>
    /// The inform price set
    /// </summary>
    private bool _informPriceSet;

    /// <summary>
    /// The items
    /// </summary>
    private InvoiceItem[] _items;

    /// <summary>
    /// The items set
    /// </summary>
    private bool _itemsSet;

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
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

    /// <summary>
    /// Gets or sets the online update.
    /// </summary>
    /// <value>The online update.</value>
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

    /// <summary>
    /// Gets or sets the online update internal.
    /// </summary>
    /// <value>The online update internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [inform price].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [inform price]; otherwise, <c>false</c>.
    /// </value>
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

    /// <summary>
    /// Gets or sets the inform price internal.
    /// </summary>
    /// <value>
    /// The inform price internal.
    /// </value>
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

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    /// <value>The items.</value>
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

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize online update.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOnlineUpdate() => _onlineUpdateSet;

    /// <summary>
    /// Should the serialize inform price.
    /// </summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInformPrice() => _informPriceSet;

    /// <summary>
    /// Should the serialize items.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeItems() => _itemsSet;
}
