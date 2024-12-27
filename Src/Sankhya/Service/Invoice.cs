using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Transport;

namespace Sankhya.Service;

[XmlType("nota")]
public sealed class Invoice
{
    private int _value;

    private bool _valueSet;

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _singleNumberConfirmation;

    private bool _singleNumberConfirmationSet;

    private int _singleNumberDuplication;

    private bool _singleNumberDuplicationSet;

    private int _singleNumberDuplicationDestiny;

    private bool _singleNumberDuplicationDestinySet;

    private int _singleNumberDuplicationSource;

    private bool _singleNumberDuplicationSourceSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private bool _confirmationCentralInvoices;

    private bool _confirmationCentralInvoicesSet;

    private bool _isWebOrder;

    private bool _isWebOrderSet;

    private bool _updatePriceItemPurchaseOrder;

    private bool _updatePriceItemPurchaseOrderSet;

    private FiscalInvoiceStatus _statusInvoiceService;

    private bool _statusInvoiceServiceSet;

    private FiscalInvoiceStatus _statusInvoice;

    private bool _statusInvoiceSet;

    private string _lotNumberInvoiceService;

    private bool _lotNumberInvoiceServiceSet;

    private string _lotNumberInvoice;

    private bool _lotNumberInvoiceSet;

    private string _observationInvoiceService;

    private bool _observationInvoiceServiceSet;

    private string _observationInvoice;

    private bool _observationInvoiceSet;

    private Accompaniment[] _accompaniments;

    private bool _accompanimentsSet;

    private Prop[] _props;

    private bool _propsSet;

    private InvoiceHeader _header;

    private bool _headerSet;

    private InvoiceItems _items;

    private bool _itemsSet;

    [XmlIgnore]
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    [XmlText]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ValueInternal
    {
        get => _value.ToString();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _value = value.ToInt32();
            _valueSet = true;
        }
    }

    [XmlAttribute("numeroUnico")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    [XmlElement("NUNOTA")]
    public int SingleNumberConfirmation
    {
        get => _singleNumberConfirmation;
        set
        {
            _singleNumberConfirmation = value;
            _singleNumberConfirmationSet = true;
        }
    }

    [XmlAttribute("NUNOTA")]
    public int SingleNumberDuplication
    {
        get => _singleNumberDuplication;
        set
        {
            _singleNumberDuplication = value;
            _singleNumberDuplicationSet = true;
        }
    }

    [XmlAttribute("nuNota")]
    public int SingleNumberDuplicationDestiny
    {
        get => _singleNumberDuplicationDestiny;
        set
        {
            _singleNumberDuplicationDestiny = value;
            _singleNumberDuplicationDestinySet = true;
        }
    }

    [XmlAttribute("nuNotaOrig")]
    public int SingleNumberDuplicationSource
    {
        get => _singleNumberDuplicationSource;
        set
        {
            _singleNumberDuplicationSource = value;
            _singleNumberDuplicationSourceSet = true;
        }
    }

    [XmlAttribute("numeroNota")]
    public int InvoiceNumber
    {
        get => _invoiceNumber;
        set
        {
            _invoiceNumber = value;
            _invoiceNumberSet = true;
        }
    }

    [XmlIgnore]
    public bool ConfirmationCentralInvoices
    {
        get => _confirmationCentralInvoices;
        set
        {
            _confirmationCentralInvoices = value;
            _confirmationCentralInvoicesSet = true;
        }
    }

    [XmlAttribute("confirmacaoCentralNota")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ConfirmationCentralInvoicesInternal
    {
        get => _confirmationCentralInvoices.ToString(@"true", @"false");
        set
        {
            _confirmationCentralInvoices = value.ToBoolean(@"true|false");
            _confirmationCentralInvoicesSet = true;
        }
    }

    [XmlIgnore]
    public bool IsWebOrder
    {
        get => _isWebOrder;
        set
        {
            _isWebOrder = value;
            _isWebOrderSet = true;
        }
    }

    [XmlAttribute("ehpedidoweb")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsWebOrderInternal
    {
        get => _isWebOrder.ToString(@"true", @"false");
        set
        {
            _isWebOrder = value.ToBoolean(@"true|false");
            _isWebOrderSet = true;
        }
    }

    [XmlIgnore]
    public bool UpdatePriceItemPurchaseOrder
    {
        get => _updatePriceItemPurchaseOrder;
        set
        {
            _updatePriceItemPurchaseOrder = value;
            _updatePriceItemPurchaseOrderSet = true;
        }
    }

    [XmlAttribute("atualizaPrecoItemPedCompra")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string UpdatePriceItemPurchaseOrderInternal
    {
        get => _updatePriceItemPurchaseOrder.ToString(@"true", @"false");
        set
        {
            _updatePriceItemPurchaseOrder = value.ToBoolean(@"true|false");
            _updatePriceItemPurchaseOrderSet = true;
        }
    }

    [XmlIgnore]
    public FiscalInvoiceStatus StatusInvoiceService
    {
        get => _statusInvoiceService;
        set
        {
            _statusInvoiceService = value;
            _statusInvoiceServiceSet = true;
        }
    }

    [XmlAttribute("statusnfse")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string StatusInvoiceServiceInternal
    {
        get => _statusInvoiceService.GetHumanReadableValue();
        set
        {
            _statusInvoiceService =
                EnumExtensions.GetEnumByHumanReadableAttribute<FiscalInvoiceStatus>(value);
            _statusInvoiceServiceSet = true;
        }
    }

    [XmlIgnore]
    public FiscalInvoiceStatus StatusInvoice
    {
        get => _statusInvoice;
        set
        {
            _statusInvoice = value;
            _statusInvoiceSet = true;
        }
    }

    [XmlAttribute("statusnfe")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string StatusInvoiceInternal
    {
        get => _statusInvoice.GetHumanReadableValue();
        set
        {
            _statusInvoice = EnumExtensions.GetEnumByHumanReadableAttribute<FiscalInvoiceStatus>(
                value
            );
            _statusInvoiceSet = true;
        }
    }

    [XmlAttribute("numeroLoteNfse")]
    public string LotNumberInvoiceService
    {
        get => _lotNumberInvoiceService;
        set
        {
            _lotNumberInvoiceService = value;
            _lotNumberInvoiceServiceSet = true;
        }
    }

    [XmlAttribute("numeroLoteNfe")]
    public string LotNumberInvoice
    {
        get => _lotNumberInvoice;
        set
        {
            _lotNumberInvoice = value;
            _lotNumberInvoiceSet = true;
        }
    }

    [XmlAttribute("observacaoNfse")]
    public string ObservationInvoiceService
    {
        get => _observationInvoiceService;
        set
        {
            _observationInvoiceService = value;
            _observationInvoiceServiceSet = true;
        }
    }

    [XmlAttribute("observacaoNfe")]
    public string ObservationInvoice
    {
        get => _observationInvoice;
        set
        {
            _observationInvoice = value;
            _observationInvoiceSet = true;
        }
    }

    [XmlElement("acompanhamento")]
    public Accompaniment[] Accompaniments
    {
        get => _accompaniments;
        set
        {
            _accompaniments = value;
            _accompanimentsSet = true;
        }
    }

    [XmlArray("txProperties")]
    [XmlArrayItem("prop")]
    public Prop[] Props
    {
        get => _props;
        set
        {
            _props = value;
            _propsSet = true;
        }
    }

    [XmlElement("cabecalho")]
    public InvoiceHeader Header
    {
        get => _header;
        set
        {
            _header = value;
            _headerSet = true;
        }
    }

    [XmlElement("itens")]
    public InvoiceItems Items
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
    public bool ShouldSerializeValueInternal() => _valueSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberConfirmation() => _singleNumberConfirmationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplication() => _singleNumberDuplicationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplicationDestiny() =>
        _singleNumberDuplicationDestinySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplicationSource() => _singleNumberDuplicationSourceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfirmationCentralInvoicesInternal() =>
        _confirmationCentralInvoicesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsWebOrderInternal() => _isWebOrderSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUpdatePriceItemPurchaseOrderInternal() =>
        _updatePriceItemPurchaseOrderSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusInvoiceServiceInternal() => _statusInvoiceServiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusInvoiceInternal() => _statusInvoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLotNumberInvoiceService() => _lotNumberInvoiceServiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLotNumberInvoice() => _lotNumberInvoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeObservationInvoiceService() => _observationInvoiceServiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeObservationInvoice() => _observationInvoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccompaniments() => _accompanimentsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProps() => _propsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHeader() => _headerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeItems() => _itemsSet;
}
