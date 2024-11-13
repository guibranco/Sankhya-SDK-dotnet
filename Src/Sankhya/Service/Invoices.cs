using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Enums;

namespace Sankhya.Service;

/// <summary>
/// Class Invoices. This class cannot be inherited.
/// </summary>
[XmlType("notas")]
[Serializer]
public sealed class Invoices
{
    /// <summary>
    /// The single numbers.
    /// </summary>
    private int[] _singleNumbers;

    /// <summary>
    /// The single numbers set.
    /// </summary>
    private bool _singleNumbersSet;

    /// <summary>
    /// The code operation type.
    /// </summary>
    private int _codeOperationType;

    /// <summary>
    /// The code operation type set.
    /// </summary>
    private bool _codeOperationTypeSet;

    /// <summary>
    /// The code operation type duplication.
    /// </summary>
    private int _codeOperationTypeDuplication;

    /// <summary>
    /// The code operation type duplication set.
    /// </summary>
    private bool _codeOperationTypeDuplicationSet;

    /// <summary>
    /// The series.
    /// </summary>
    private int _series;

    /// <summary>
    /// The series set.
    /// </summary>
    private bool _seriesSet;

    /// <summary>
    /// The return disapproved invoices.
    /// </summary>
    private bool _returnDisapprovedInvoices;

    /// <summary>
    /// The return disapproved invoices set.
    /// </summary>
    private bool _returnDisapprovedInvoicesSet;

    /// <summary>
    /// The should update price.
    /// </summary>
    private bool _shouldUpdatePrice;

    /// <summary>
    /// The should update price set.
    /// </summary>
    private bool _shouldUpdatePriceSet;

    /// <summary>
    /// The should duplicate all items.
    /// </summary>
    private bool _shouldDuplicateAllItems;

    /// <summary>
    /// The should duplicate all items set.
    /// </summary>
    private bool _shouldDuplicateAllItemsSet;

    /// <summary>
    /// The is date validated.
    /// </summary>
    private bool _isDateValidated;

    /// <summary>
    /// The is date validated set.
    /// </summary>
    private bool _isDateValidatedSet;

    /// <summary>
    /// The one invoice for each.
    /// </summary>
    private bool _oneInvoiceForEach;

    /// <summary>
    /// The one invoice for each set.
    /// </summary>
    private bool _oneInvoiceForEachSet;

    /// <summary>
    /// The date exit duplication nullable.
    /// </summary>
    private DateTime? _dateExitDuplicationNullable;

    /// <summary>
    /// The date exit duplication nullable set.
    /// </summary>
    private bool _dateExitDuplicationNullableSet;

    /// <summary>
    /// The date billing nullable.
    /// </summary>
    private DateTime? _dateBillingNullable;

    /// <summary>
    /// The date billing nullable set.
    /// </summary>
    private bool _dateBillingNullableSet;

    /// <summary>
    /// The date exit nullable.
    /// </summary>
    private DateTime? _dateExitNullable;

    /// <summary>
    /// The date exit nullable set.
    /// </summary>
    private bool _dateExitNullableSet;

    /// <summary>
    /// The time exit nullable.
    /// </summary>
    private TimeSpan? _timeExitNullable;

    /// <summary>
    /// The time exit nullable set.
    /// </summary>
    private bool _timeExitNullableSet;

    /// <summary>
    /// The billing type.
    /// </summary>
    private BillingType _billingType;

    /// <summary>
    /// The billing type set.
    /// </summary>
    private bool _billingTypeSet;

    /// <summary>
    /// The invoices with currency.
    /// </summary>
    private InvoicesWithCurrency _invoicesWithCurrency;

    /// <summary>
    /// The invoices with currency set.
    /// </summary>
    private bool _invoicesWithCurrencySet;

    /// <summary>
    /// The invoice.
    /// </summary>
    private Invoice _invoice;

    /// <summary>
    /// The invoice set.
    /// </summary>
    private bool _invoiceSet;

    /// <summary>
    /// Gets or sets the single numbers.
    /// </summary>
    /// <value>The single numbers.</value>
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

    /// <summary>
    /// Gets or sets the type of the code operation.
    /// </summary>
    /// <value>The type of the code operation.</value>
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

    /// <summary>
    /// Gets or sets the code operation type duplication.
    /// </summary>
    /// <value>The code operation type duplication.</value>
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

    /// <summary>
    /// Gets or sets the series.
    /// </summary>
    /// <value>The series.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [return disapproved invoices].
    /// </summary>
    /// <value><c>true</c> if [return disapproved invoices]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the return disapproved invoices internal.
    /// </summary>
    /// <value>The return disapproved invoices internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [should update price].
    /// </summary>
    /// <value><c>true</c> if [should update price]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the should update price internal.
    /// </summary>
    /// <value>The should update price internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [should duplicate all items].
    /// </summary>
    /// <value><c>true</c> if [should duplicate all items]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the should duplicate all items internal.
    /// </summary>
    /// <value>The should duplicate all items internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether this instance is date validated.
    /// </summary>
    /// <value><c>true</c> if this instance is date validated; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the is date validated internal.
    /// </summary>
    /// <value>The is date validated internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether [one invoice for each].
    /// </summary>
    /// <value><c>true</c> if [one invoice for each]; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the one invoice for each internal.
    /// </summary>
    /// <value>The one invoice for each internal.</value>
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

    /// <summary>
    /// Gets or sets the date exit duplication nullable.
    /// </summary>
    /// <value>The date exit duplication nullable.</value>
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

    /// <summary>
    /// Gets or sets the date exit duplication nullable internal.
    /// </summary>
    /// <value>The date exit duplication nullable internal.</value>
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

    /// <summary>
    /// Gets or sets the date billing nullable.
    /// </summary>
    /// <value>The date billing nullable.</value>
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

    /// <summary>
    /// Gets or sets the date billing nullable internal.
    /// </summary>
    /// <value>The date billing nullable internal.</value>
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

    /// <summary>
    /// Gets or sets the date exit nullable.
    /// </summary>
    /// <value>The date exit nullable.</value>
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

    /// <summary>
    /// Gets or sets the date exit nullable internal.
    /// </summary>
    /// <value>The date exit nullable internal.</value>
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

    /// <summary>
    /// Gets or sets the time exit nullable.
    /// </summary>
    /// <value>The time exit nullable.</value>
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

    /// <summary>
    /// Gets or sets the time exit nullable internal.
    /// </summary>
    /// <value>The time exit nullable internal.</value>
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

    /// <summary>
    /// Gets or sets the type of the billing.
    /// </summary>
    /// <value>The type of the billing.</value>
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

    /// <summary>
    /// Gets or sets the billing type internal.
    /// </summary>
    /// <value>The billing type internal.</value>
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

    /// <summary>
    /// Gets or sets the invoices with currency.
    /// </summary>
    /// <value>The invoices with currency.</value>
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

    /// <summary>
    /// Gets or sets the invoice.
    /// </summary>
    /// <value>The invoice.</value>
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

    /// <summary>
    /// Should the serialize single numbers.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumbers() => _singleNumbersSet;

    /// <summary>
    /// Should the type of the serialize code operation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeOperationType() => _codeOperationTypeSet;

    /// <summary>
    /// Should the serialize code operation type duplication.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeOperationTypeDuplication() => _codeOperationTypeDuplicationSet;

    /// <summary>
    /// Should the serialize series.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeries() => _seriesSet;

    /// <summary>
    /// Should the serialize return disapproved invoices internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReturnDisapprovedInvoicesInternal() => _returnDisapprovedInvoicesSet;

    /// <summary>
    /// Should the serialize should update price internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeShouldUpdatePriceInternal() => _shouldUpdatePriceSet;

    /// <summary>
    /// Should the serialize should duplicate all items internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeShouldDuplicateAllItemsInternal() => _shouldDuplicateAllItemsSet;

    /// <summary>
    /// Should the serialize is date validated internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsDateValidatedInternal() => _isDateValidatedSet;

    /// <summary>
    /// Should the serialize one invoice for each internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOneInvoiceForEachInternal() => _oneInvoiceForEachSet;

    /// <summary>
    /// Should the serialize date exit duplication nullable internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExitDuplicationNullableInternal() =>
        _dateExitDuplicationNullableSet;

    /// <summary>
    /// Should the serialize date billing nullable internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateBillingNullableInternal() => _dateBillingNullableSet;

    /// <summary>
    /// Should the serialize date exit nullable internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExitNullableInternal() => _dateExitNullableSet;

    /// <summary>
    /// Should the serialize time exit nullable internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeExitNullableInternal() => _timeExitNullableSet;

    /// <summary>
    /// Should the serialize billing type internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBillingTypeInternal() => _billingTypeSet;

    /// <summary>
    /// Should the serialize invoice with currency.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceWithCurrency() => _invoicesWithCurrencySet;

    /// <summary>
    /// Should the serialize invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoice() => _invoiceSet;
}
