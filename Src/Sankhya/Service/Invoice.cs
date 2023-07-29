namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Transport;

/// <summary>
/// Class Invoice. This class cannot be inherited.
/// </summary>
[XmlType("nota")]
public sealed class Invoice
{
    #region Private Members

    /// <summary>
    /// The value
    /// </summary>
    private int _value;

    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    /// <summary>
    /// The single number
    /// </summary>
    private int _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The single number confirmation
    /// </summary>
    private int _singleNumberConfirmation;

    /// <summary>
    /// The single number confirmation set
    /// </summary>
    private bool _singleNumberConfirmationSet;

    /// <summary>
    /// The single number duplication
    /// </summary>
    private int _singleNumberDuplication;

    /// <summary>
    /// The single number duplication set
    /// </summary>
    private bool _singleNumberDuplicationSet;

    /// <summary>
    /// The single number duplication destiny
    /// </summary>
    private int _singleNumberDuplicationDestiny;

    /// <summary>
    /// The single number duplication destiny set
    /// </summary>
    private bool _singleNumberDuplicationDestinySet;

    /// <summary>
    /// The single number duplication source
    /// </summary>
    private int _singleNumberDuplicationSource;

    /// <summary>
    /// The single number duplication source set
    /// </summary>
    private bool _singleNumberDuplicationSourceSet;

    /// <summary>
    /// The invoice number
    /// </summary>
    private int _invoiceNumber;

    /// <summary>
    /// The invoice number set
    /// </summary>
    private bool _invoiceNumberSet;

    /// <summary>
    /// The confirmation central invoices
    /// </summary>
    private bool _confirmationCentralInvoices;

    /// <summary>
    /// The confirmation central invoices set
    /// </summary>
    private bool _confirmationCentralInvoicesSet;

    /// <summary>
    /// The is web order
    /// </summary>
    private bool _isWebOrder;

    /// <summary>
    /// The is web order set
    /// </summary>
    private bool _isWebOrderSet;

    /// <summary>
    /// The update price item purchase order
    /// </summary>
    private bool _updatePriceItemPurchaseOrder;

    /// <summary>
    /// The update price item purchase order set
    /// </summary>
    private bool _updatePriceItemPurchaseOrderSet;

    /// <summary>
    /// The status invoice service
    /// </summary>
    private FiscalInvoiceStatus _statusInvoiceService;

    /// <summary>
    /// The status invoice service set
    /// </summary>
    private bool _statusInvoiceServiceSet;

    /// <summary>
    /// The status invoice
    /// </summary>
    private FiscalInvoiceStatus _statusInvoice;

    /// <summary>
    /// The status invoice set
    /// </summary>
    private bool _statusInvoiceSet;

    /// <summary>
    /// The lot number invoice service
    /// </summary>
    private string _lotNumberInvoiceService;

    /// <summary>
    /// The lot number invoice service set
    /// </summary>
    private bool _lotNumberInvoiceServiceSet;

    /// <summary>
    /// The lot number invoice
    /// </summary>
    private string _lotNumberInvoice;

    /// <summary>
    /// The lot number invoice set
    /// </summary>
    private bool _lotNumberInvoiceSet;

    /// <summary>
    /// The observation invoice service
    /// </summary>
    private string _observationInvoiceService;

    /// <summary>
    /// The observation invoice service set
    /// </summary>
    private bool _observationInvoiceServiceSet;

    /// <summary>
    /// The observation invoice
    /// </summary>
    private string _observationInvoice;

    /// <summary>
    /// The observation invoice set
    /// </summary>
    private bool _observationInvoiceSet;

    /// <summary>
    /// The accompaniments
    /// </summary>
    private Accompaniment[] _accompaniments;

    /// <summary>
    /// The accompaniments set
    /// </summary>
    private bool _accompanimentsSet;

    /// <summary>
    /// The props
    /// </summary>
    private Prop[] _props;

    /// <summary>
    /// The props set
    /// </summary>
    private bool _propsSet;

    /// <summary>
    /// The header
    /// </summary>
    private InvoiceHeader _header;

    /// <summary>
    /// The header set
    /// </summary>
    private bool _headerSet;

    /// <summary>
    /// The items
    /// </summary>
    private InvoiceItems _items;

    /// <summary>
    /// The items set
    /// </summary>
    private bool _itemsSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
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

    /// <summary>
    /// Gets or sets the value internal.
    /// </summary>
    /// <value>The value internal.</value>
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

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
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

    /// <summary>
    /// Gets or sets the single number confirmation.
    /// </summary>
    /// <value>The single number confirmation.</value>
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

    /// <summary>
    /// Gets or sets the single number duplication.
    /// </summary>
    /// <value>The single number duplication.</value>
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

    /// <summary>
    /// Gets or sets the single number duplication destiny.
    /// </summary>
    /// <value>The single number duplication destiny.</value>
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

    /// <summary>
    /// Gets or sets the single number duplication source.
    /// </summary>
    /// <value>The single number duplication source.</value>
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

    /// <summary>
    /// Gets or sets the invoice number.
    /// </summary>
    /// <value>The invoice number.</value>
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

    /// <summary>
    /// Gets or sets the confirmation central invoices.
    /// </summary>
    /// <value>The confirmation central invoices.</value>
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

    /// <summary>
    /// Gets or sets the confirmation central invoices internal.
    /// </summary>
    /// <value>The confirmation central invoices internal.</value>
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

    /// <summary>
    /// Gets or sets the is web order.
    /// </summary>
    /// <value>The is web order.</value>
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

    /// <summary>
    /// Gets or sets the is web order internal.
    /// </summary>
    /// <value>The is web order internal.</value>
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

    /// <summary>
    /// Gets or sets the update price item purchase order.
    /// </summary>
    /// <value>The update price item purchase order.</value>
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

    /// <summary>
    /// Gets or sets the update price item purchase order internal.
    /// </summary>
    /// <value>The update price item purchase order internal.</value>
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

    /// <summary>
    /// Gets or sets the status invoice service.
    /// </summary>
    /// <value>The status invoice service.</value>
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

    /// <summary>
    /// Gets or sets the status invoice service internal.
    /// </summary>
    /// <value>The status invoice service internal.</value>
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

    /// <summary>
    /// Gets or sets the status invoice.
    /// </summary>
    /// <value>The status invoice.</value>
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

    /// <summary>
    /// Gets or sets the status invoice internal.
    /// </summary>
    /// <value>The status invoice internal.</value>
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

    /// <summary>
    /// Gets or sets the lot number invoice service.
    /// </summary>
    /// <value>The lot number invoice service.</value>
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

    /// <summary>
    /// Gets or sets the lot number invoice.
    /// </summary>
    /// <value>The lot number invoice.</value>
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

    /// <summary>
    /// Gets or sets the observation invoice service.
    /// </summary>
    /// <value>The observation invoice service.</value>
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

    /// <summary>
    /// Gets or sets the observation invoice.
    /// </summary>
    /// <value>The observation invoice.</value>
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

    /// <summary>
    /// Gets or sets the accompaniments.
    /// </summary>
    /// <value>The accompaniments.</value>
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

    /// <summary>
    /// Gets or sets the props.
    /// </summary>
    /// <value>The props.</value>
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

    /// <summary>
    /// Gets or sets the header.
    /// </summary>
    /// <value>The header.</value>
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

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    /// <value>The items.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize value internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueInternal() => _valueSet;

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize single number confirmation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberConfirmation() => _singleNumberConfirmationSet;

    /// <summary>
    /// Should the serialize single number duplication.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplication() => _singleNumberDuplicationSet;

    /// <summary>
    /// Should the serialize single number duplication destiny.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplicationDestiny() =>
        _singleNumberDuplicationDestinySet;

    /// <summary>
    /// Should the serialize single number duplication source.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberDuplicationSource() => _singleNumberDuplicationSourceSet;

    /// <summary>
    /// Should the serialize invoice number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    /// <summary>
    /// Should the serialize confirmation central invoices internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfirmationCentralInvoicesInternal() =>
        _confirmationCentralInvoicesSet;

    /// <summary>
    /// Should the serialize is web order internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsWebOrderInternal() => _isWebOrderSet;

    /// <summary>
    /// Should the serialize update price item purchase order internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUpdatePriceItemPurchaseOrderInternal() =>
        _updatePriceItemPurchaseOrderSet;

    /// <summary>
    /// Should the serialize status invoice service internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusInvoiceServiceInternal() => _statusInvoiceServiceSet;

    /// <summary>
    /// Should the serialize status invoice internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatusInvoiceInternal() => _statusInvoiceSet;

    /// <summary>
    /// Should the serialize lot number invoice service.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLotNumberInvoiceService() => _lotNumberInvoiceServiceSet;

    /// <summary>
    /// Should the serialize lot number invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLotNumberInvoice() => _lotNumberInvoiceSet;

    /// <summary>
    /// Should the serialize observation invoice service.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeObservationInvoiceService() => _observationInvoiceServiceSet;

    /// <summary>
    /// Should the serialize observation invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeObservationInvoice() => _observationInvoiceSet;

    /// <summary>
    /// Should the serialize accompaniments.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccompaniments() => _accompanimentsSet;

    /// <summary>
    /// Should the serialize props.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProps() => _propsSet;

    /// <summary>
    /// Should the serialize header.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHeader() => _headerSet;

    /// <summary>
    /// Should the serialize items.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeItems() => _itemsSet;

    #endregion
}
