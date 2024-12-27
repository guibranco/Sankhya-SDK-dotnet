using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Enums;

namespace Sankhya.Service;

[XmlType("notas")]
[Serializer]
public sealed class Invoices
{
    private int[] _singleNumbers;

    private bool _singleNumbersSet;

    private int _codeOperationType;

    private bool _codeOperationTypeSet;

    private int _codeOperationTypeDuplication;

    private bool _codeOperationTypeDuplicationSet;

    private int _series;

    private bool _seriesSet;

    private bool _returnDisapprovedInvoices;

    private bool _returnDisapprovedInvoicesSet;

    private bool _shouldUpdatePrice;

    private bool _shouldUpdatePriceSet;

    private bool _shouldDuplicateAllItems;

    private bool _shouldDuplicateAllItemsSet;

    private bool _isDateValidated;

    private bool _isDateValidatedSet;

    private bool _oneInvoiceForEach;

    private bool _oneInvoiceForEachSet;

    private DateTime? _dateExitDuplicationNullable;

    private bool _dateExitDuplicationNullableSet;

    private DateTime? _dateBillingNullable;

    private bool _dateBillingNullableSet;

    private DateTime? _dateExitNullable;

    private bool _dateExitNullableSet;

    private TimeSpan? _timeExitNullable;

    private bool _timeExitNullableSet;

    private BillingType _billingType;

    private bool _billingTypeSet;

    private InvoicesWithCurrency _invoicesWithCurrency;

    private bool _invoicesWithCurrencySet;

    private Invoice _invoice;

    private bool _invoiceSet;

    [XmlElement("nunota")]
    public int[] SingleNumbers
    {
        get => _singleNumbers;
        set
        {
            _singleNumbers = value;
            _singleNumbersSet = true;
        }
    }

    [XmlAttribute("codTipOper")]
    public int CodeOperationType
    {
        get => _codeOperationType;
        set
        {
            _codeOperationType = value;
            _codeOperationTypeSet = true;
        }
    }

    [XmlAttribute("top")]
    public int CodeOperationTypeDuplication
    {
        get => _codeOperationTypeDuplication;
        set
        {
            _codeOperationTypeDuplication = value;
            _codeOperationTypeDuplicationSet = true;
        }
    }

    [XmlAttribute("serie")]
    public int Series
    {
        get => _series;
        set
        {
            _series = value;
            _seriesSet = true;
        }
    }

    [XmlIgnore]
    public bool ReturnDisapprovedInvoices
    {
        get => _returnDisapprovedInvoices;
        set
        {
            _returnDisapprovedInvoices = value;
            _returnDisapprovedInvoicesSet = true;
        }
    }

    [XmlAttribute("retNotasReprovadas")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ReturnDisapprovedInvoicesInternal
    {
        get => _returnDisapprovedInvoices.ToString(@"S", @"N");
        set
        {
            _returnDisapprovedInvoices = value.ToBoolean();
            _returnDisapprovedInvoicesSet = true;
        }
    }

    [XmlIgnore]
    public bool ShouldUpdatePrice
    {
        get => _shouldUpdatePrice;
        set
        {
            _shouldUpdatePrice = value;
            _shouldUpdatePriceSet = true;
        }
    }

    [XmlAttribute("atualizaPreco")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ShouldUpdatePriceInternal
    {
        get => _shouldUpdatePrice.ToString(@"true", @"false");
        set
        {
            _shouldUpdatePrice = value.ToBoolean();
            _shouldUpdatePriceSet = true;
        }
    }

    [XmlIgnore]
    public bool ShouldDuplicateAllItems
    {
        get => _shouldDuplicateAllItems;
        set
        {
            _shouldDuplicateAllItems = value;
            _shouldDuplicateAllItemsSet = true;
        }
    }

    [XmlAttribute("duplicarTodosItens")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ShouldDuplicateAllItemsInternal
    {
        get => _shouldDuplicateAllItems.ToString(@"true", @"false");
        set
        {
            _shouldDuplicateAllItems = value.ToBoolean();
            _shouldDuplicateAllItemsSet = true;
        }
    }

    [XmlIgnore]
    public bool IsDateValidated
    {
        get => _isDateValidated;
        set
        {
            _isDateValidated = value;
            _isDateValidatedSet = true;
        }
    }

    [XmlAttribute("dataValidada")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsDateValidatedInternal
    {
        get => _isDateValidated.ToString(@"S", @"N");
        set
        {
            _isDateValidated = value.ToBoolean();
            _isDateValidatedSet = true;
        }
    }

    [XmlIgnore]
    public bool OneInvoiceForEach
    {
        get => _oneInvoiceForEach;
        set
        {
            _oneInvoiceForEach = value;
            _oneInvoiceForEachSet = true;
        }
    }

    [XmlAttribute("umaNotaParaCada")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string OneInvoiceForEachInternal
    {
        get => _oneInvoiceForEach.ToString(@"S", @"N");
        set
        {
            _oneInvoiceForEach = value.ToBoolean();
            _oneInvoiceForEachSet = true;
        }
    }

    [XmlIgnore]
    public DateTime? DateExitDuplicationNullable
    {
        get => _dateExitDuplicationNullable;
        set
        {
            _dateExitDuplicationNullable = value;
            _dateExitDuplicationNullableSet = true;
        }
    }

    [XmlAttribute("dataSaida")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DateExitDuplicationNullableInternal
    {
        get => _dateExitDuplicationNullable?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _dateExitDuplicationNullable = null;
            }
            else
            {
                _dateExitDuplicationNullable = value.ToDateTime();
            }

            _dateExitDuplicationNullableSet = true;
        }
    }

    [XmlIgnore]
    public DateTime? DateBillingNullable
    {
        get => _dateBillingNullable;
        set
        {
            _dateBillingNullable = value;
            _dateBillingNullableSet = true;
        }
    }

    [XmlAttribute("dtFaturamento")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DateBillingNullableInternal
    {
        get => _dateBillingNullable?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _dateBillingNullable = null;
            }
            else
            {
                _dateBillingNullable = value.ToDateTime();
            }

            _dateBillingNullableSet = true;
        }
    }

    [XmlIgnore]
    public DateTime? DateExitNullable
    {
        get => _dateExitNullable;
        set
        {
            _dateExitNullable = value;
            _dateExitNullableSet = true;
        }
    }

    [XmlAttribute("dtSaida")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DateExitNullableInternal
    {
        get => _dateExitNullable?.ToString() ?? string.Empty;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _dateExitNullable = null;
            }
            else
            {
                _dateExitNullable = value.ToDateTime();
            }

            _dateExitNullableSet = true;
        }
    }

    [XmlIgnore]
    public TimeSpan? TimeExitNullable
    {
        get => _timeExitNullable;
        set
        {
            _timeExitNullable = value;
            _timeExitNullableSet = true;
        }
    }

    [XmlAttribute("hrSaida")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TimeExitNullableInternal
    {
        get => _timeExitNullable?.ToString() ?? string.Empty;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _timeExitNullable = null;
            }
            else
            {
                _timeExitNullable = TimeSpan.Parse(value);
            }

            _timeExitNullableSet = true;
        }
    }

    [XmlIgnore]
    public BillingType BillingType
    {
        get => _billingType;
        set
        {
            _billingType = value;
            _billingTypeSet = true;
        }
    }

    [XmlAttribute("tipoFaturamento")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string BillingTypeInternal
    {
        get => _billingType.GetInternalValue();
        set
        {
            _billingType = EnumExtensions.GetEnumByInternalValueAttribute<BillingType>(value);
            _billingTypeSet = true;
        }
    }

    [XmlElement("notasComMoeda")]
    public InvoicesWithCurrency InvoicesWithCurrency
    {
        get => _invoicesWithCurrency;
        set
        {
            _invoicesWithCurrency = value;
            _invoicesWithCurrencySet = true;
        }
    }

    [XmlElement("nota")]
    public Invoice Invoice
    {
        get => _invoice;
        set
        {
            _invoice = value;
            _invoiceSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumbers() => _singleNumbersSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeOperationType() => _codeOperationTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeOperationTypeDuplication() => _codeOperationTypeDuplicationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeries() => _seriesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReturnDisapprovedInvoicesInternal() => _returnDisapprovedInvoicesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeShouldUpdatePriceInternal() => _shouldUpdatePriceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeShouldDuplicateAllItemsInternal() => _shouldDuplicateAllItemsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsDateValidatedInternal() => _isDateValidatedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOneInvoiceForEachInternal() => _oneInvoiceForEachSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExitDuplicationNullableInternal() =>
        _dateExitDuplicationNullableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateBillingNullableInternal() => _dateBillingNullableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExitNullableInternal() => _dateExitNullableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeExitNullableInternal() => _timeExitNullableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBillingTypeInternal() => _billingTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceWithCurrency() => _invoicesWithCurrencySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoice() => _invoiceSet;
}
