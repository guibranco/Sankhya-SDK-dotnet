using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Helpers;
using Sankhya.Properties;

namespace Sankhya.Transport;

/// <summary>
/// Class InvoiceHeader. This class cannot be inherited.
/// </summary>
/// <seealso cref="GenericServiceEntity" />
/// <seealso cref="GenericServiceEntity" />
[Entity("CabecalhoNota")]
public class InvoiceHeader : GenericServiceEntity, IEquatable<InvoiceHeader>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(InvoiceHeader other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _codeCompany == other._codeCompany
            && _codeCompanySet == other._codeCompanySet
            && _codeContact == other._codeContact
            && _codeContactSet == other._codeContactSet
            && _codeNature == other._codeNature
            && _codeNatureSet == other._codeNatureSet
            && _codePartner == other._codePartner
            && _codePartnerCarrier == other._codePartnerCarrier
            && _codePartnerCarrierSet == other._codePartnerCarrierSet
            && _codePartnerDestination == other._codePartnerDestination
            && _codePartnerDestinationSet == other._codePartnerDestinationSet
            && _codePartnerSet == other._codePartnerSet
            && _codeResultCenter == other._codeResultCenter
            && _codeResultCenterSet == other._codeResultCenterSet
            && _codeSeller == other._codeSeller
            && _codeSellerSet == other._codeSellerSet
            && _codeTradeType == other._codeTradeType
            && _codeTradeTypeSet == other._codeTradeTypeSet
            && _confirmed == other._confirmed
            && _confirmedSet == other._confirmedSet
            && _dateBilled.Equals(other._dateBilled)
            && _dateBilledSet == other._dateBilledSet
            && _dateChanged.Equals(other._dateChanged)
            && _dateChangedSet == other._dateChangedSet
            && _dateExpectedDelivery.Equals(other._dateExpectedDelivery)
            && _dateExpectedDeliverySet == other._dateExpectedDeliverySet
            && _dateImported.Equals(other._dateImported)
            && _dateImportedSet == other._dateImportedSet
            && _dateTraded.Equals(other._dateTraded)
            && _dateTradedSet == other._dateTradedSet
            && string.Equals(
                _fiscalInvoiceKey,
                other._fiscalInvoiceKey,
                StringComparison.OrdinalIgnoreCase
            )
            && _fiscalInvoiceKeySet == other._fiscalInvoiceKeySet
            && _fiscalInvoiceStatus == other._fiscalInvoiceStatus
            && _fiscalInvoiceStatusSet == other._fiscalInvoiceStatusSet
            && _freightType == other._freightType
            && _freightTypeSet == other._freightTypeSet
            && _freightValue == other._freightValue
            && _freightValueSet == other._freightValueSet
            && _invoiceFreightType == other._invoiceFreightType
            && _invoiceFreightTypeSet == other._invoiceFreightTypeSet
            && _invoiceNumber == other._invoiceNumber
            && _invoiceNumberSet == other._invoiceNumberSet
            && _invoiceStatus == other._invoiceStatus
            && _invoiceStatusSet == other._invoiceStatusSet
            && _invoiceValue == other._invoiceValue
            && _invoiceValueSet == other._invoiceValueSet
            && _movementTime.Equals(other._movementTime)
            && _movementTimeSet == other._movementTimeSet
            && _movementType == other._movementType
            && _movementTypeSet == other._movementTypeSet
            && string.Equals(_note, other._note, StringComparison.OrdinalIgnoreCase)
            && _noteSet == other._noteSet
            && _operationType == other._operationType
            && _operationTypeSet == other._operationTypeSet
            && Equals(_partner, other._partner)
            && Equals(_partnerCarrier, other._partnerCarrier)
            && _partnerCarrierSet == other._partnerCarrierSet
            && Equals(_partnerDestination, other._partnerDestination)
            && _partnerDestinationSet == other._partnerDestinationSet
            && Equals(_partnerRoyalties, other._partnerRoyalties)
            && _partnerRoyaltiesSet == other._partnerRoyaltiesSet
            && _partnerSet == other._partnerSet
            && _pending == other._pending
            && _pendingSet == other._pendingSet
            && Equals(_seller, other._seller)
            && _sellerSet == other._sellerSet
            && _singleNumber == other._singleNumber
            && _singleNumberSet == other._singleNumberSet;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((InvoiceHeader)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once MethodTooLong
    [SuppressMessage(
        "ReSharper",
        "NonReadonlyMemberInGetHashCode",
        Justification = "Used to compute hash internally"
    )]
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _codeCompany;
            hashCode = (hashCode * 397) ^ _codeCompanySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeContact;
            hashCode = (hashCode * 397) ^ _codeContactSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeNature;
            hashCode = (hashCode * 397) ^ _codeNatureSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerCarrier;
            hashCode = (hashCode * 397) ^ _codePartnerCarrierSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartnerDestination;
            hashCode = (hashCode * 397) ^ _codePartnerDestinationSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeResultCenter;
            hashCode = (hashCode * 397) ^ _codeResultCenterSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeTradeType;
            hashCode = (hashCode * 397) ^ _codeTradeTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _confirmed.GetHashCode();
            hashCode = (hashCode * 397) ^ _confirmedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateBilled.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateBilledSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateExpectedDelivery.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateExpectedDeliverySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateImported.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateImportedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateTraded.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateTradedSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _fiscalInvoiceKey != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_fiscalInvoiceKey)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _fiscalInvoiceKeySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_fiscalInvoiceStatus;
            hashCode = (hashCode * 397) ^ _fiscalInvoiceStatusSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_freightType;
            hashCode = (hashCode * 397) ^ _freightTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _freightValue.GetHashCode();
            hashCode = (hashCode * 397) ^ _freightValueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_invoiceFreightType;
            hashCode = (hashCode * 397) ^ _invoiceFreightTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceNumber;
            hashCode = (hashCode * 397) ^ _invoiceNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_invoiceStatus;
            hashCode = (hashCode * 397) ^ _invoiceStatusSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceValue.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceValueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _movementTime.GetHashCode();
            hashCode = (hashCode * 397) ^ _movementTimeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_movementType;
            hashCode = (hashCode * 397) ^ _movementTypeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _note != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_note) : 0
                );
            hashCode = (hashCode * 397) ^ _noteSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _operationType;
            hashCode = (hashCode * 397) ^ _operationTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_partner != null ? _partner.GetHashCode() : 0);
            hashCode =
                (hashCode * 397) ^ (_partnerCarrier != null ? _partnerCarrier.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerCarrierSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_partnerDestination != null ? _partnerDestination.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerDestinationSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_partnerRoyalties != null ? _partnerRoyalties.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerRoyaltiesSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _partnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _pending.GetHashCode();
            hashCode = (hashCode * 397) ^ _pendingSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null ? _seller.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _singleNumber.GetHashCode();
            hashCode = (hashCode * 397) ^ _singleNumberSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(InvoiceHeader left, InvoiceHeader right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(InvoiceHeader left, InvoiceHeader right) => !Equals(left, right);

    /// <summary>
    /// The single number
    /// </summary>
    private int? _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The code company
    /// </summary>
    private int _codeCompany;

    /// <summary>
    /// The code company set
    /// </summary>
    private bool _codeCompanySet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The code partner destination
    /// </summary>
    private int _codePartnerDestination;

    /// <summary>
    /// The code partner destination set
    /// </summary>
    private bool _codePartnerDestinationSet;

    /// <summary>
    /// The code contact
    /// </summary>
    private int _codeContact;

    /// <summary>
    /// The code contact set
    /// </summary>
    private bool _codeContactSet;

    /// <summary>
    /// The operation type
    /// </summary>
    private int _operationType;

    /// <summary>
    /// The operation type set
    /// </summary>
    private bool _operationTypeSet;

    /// <summary>
    /// The code trade type
    /// </summary>
    private int _codeTradeType;

    /// <summary>
    /// The code trade type set
    /// </summary>
    private bool _codeTradeTypeSet;

    /// <summary>
    /// The invoice number
    /// </summary>
    private int _invoiceNumber;

    /// <summary>
    /// The invoice number set
    /// </summary>
    private bool _invoiceNumberSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;

    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// The date traded
    /// </summary>
    private DateTime _dateTraded;

    /// <summary>
    /// The date traded set
    /// </summary>
    private bool _dateTradedSet;

    /// <summary>
    /// The date imported
    /// </summary>
    private DateTime _dateImported;

    /// <summary>
    /// The date imported set
    /// </summary>
    private bool _dateImportedSet;

    /// <summary>
    /// The date billed
    /// </summary>
    private DateTime _dateBilled;

    /// <summary>
    /// The date billed set
    /// </summary>
    private bool _dateBilledSet;

    /// <summary>
    /// The date expected delivery
    /// </summary>
    private DateTime _dateExpectedDelivery;

    /// <summary>
    /// The date expected delivery set
    /// </summary>
    private bool _dateExpectedDeliverySet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The code result center
    /// </summary>
    private int _codeResultCenter;

    /// <summary>
    /// The code result center set
    /// </summary>
    private bool _codeResultCenterSet;

    /// <summary>
    /// The code nature
    /// </summary>
    private int _codeNature;

    /// <summary>
    /// The code nature set
    /// </summary>
    private bool _codeNatureSet;

    /// <summary>
    /// The movement type
    /// </summary>
    private MovementType _movementType;

    /// <summary>
    /// The movement type set
    /// </summary>
    private bool _movementTypeSet;

    /// <summary>
    /// The freight value
    /// </summary>
    private decimal _freightValue;

    /// <summary>
    /// The freight value set
    /// </summary>
    private bool _freightValueSet;

    /// <summary>
    /// The note
    /// </summary>
    private string _note;

    /// <summary>
    /// The note set
    /// </summary>
    private bool _noteSet;

    /// <summary>
    /// The freight type
    /// </summary>
    private FreightType _freightType;

    /// <summary>
    /// The freight type set
    /// </summary>
    private bool _freightTypeSet;

    /// <summary>
    /// The invoice status
    /// </summary>
    private InvoiceStatus _invoiceStatus;

    /// <summary>
    /// The invoice status set
    /// </summary>
    private bool _invoiceStatusSet;

    /// <summary>
    /// The invoice freight type
    /// </summary>
    private InvoiceFreightType _invoiceFreightType;

    /// <summary>
    /// The invoice freight type set
    /// </summary>
    private bool _invoiceFreightTypeSet;

    /// <summary>
    /// The code partner carrier
    /// </summary>
    private int _codePartnerCarrier;

    /// <summary>
    /// The code partner carrier set
    /// </summary>
    private bool _codePartnerCarrierSet;

    /// <summary>
    /// The fiscal invoice status
    /// </summary>
    private FiscalInvoiceStatus _fiscalInvoiceStatus;

    /// <summary>
    /// The fiscal invoice status set
    /// </summary>
    private bool _fiscalInvoiceStatusSet;

    /// <summary>
    /// The confirmed
    /// </summary>
    private bool _confirmed;

    /// <summary>
    /// The confirmed set
    /// </summary>
    private bool _confirmedSet;

    /// <summary>
    /// The pending
    /// </summary>
    private bool _pending;

    /// <summary>
    /// The pending set
    /// </summary>
    private bool _pendingSet;

    /// <summary>
    /// The fiscal invoice key
    /// </summary>
    private string _fiscalInvoiceKey;

    /// <summary>
    /// The fiscal invoice key set
    /// </summary>
    private bool _fiscalInvoiceKeySet;

    /// <summary>
    /// The movement time
    /// </summary>
    private TimeSpan _movementTime;

    /// <summary>
    /// The movement time set
    /// </summary>
    private bool _movementTimeSet;

    /// <summary>
    /// The invoice value
    /// </summary>
    private decimal _invoiceValue;

    /// <summary>
    /// The invoice value set
    /// </summary>
    private bool _invoiceValueSet;

    /// <summary>
    /// The partner
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// The partner set
    /// </summary>
    private bool _partnerSet;

    /// <summary>
    /// The partner destination
    /// </summary>
    private Partner _partnerDestination;

    /// <summary>
    /// The partner destination set
    /// </summary>
    private bool _partnerDestinationSet;

    /// <summary>
    /// The partner carrier
    /// </summary>
    private Partner _partnerCarrier;

    /// <summary>
    /// The partner carrier set
    /// </summary>
    private bool _partnerCarrierSet;

    /// <summary>
    /// The partner royalties
    /// </summary>
    private Partner _partnerRoyalties;

    /// <summary>
    /// The partner royalties set
    /// </summary>
    private bool _partnerRoyaltiesSet;

    /// <summary>
    /// The seller
    /// </summary>
    private Seller _seller;

    /// <summary>
    /// The seller set
    /// </summary>
    private bool _sellerSet;

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
    [EntityElement("NUNOTA")]
    [EntityKey]
    public int? SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code company.
    /// </summary>
    /// <value>The code company.</value>
    [EntityElement("CODEMP")]
    public int CodeCompany
    {
        get => _codeCompany;
        set
        {
            _codeCompany = value;
            _codeCompanySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [EntityElement("CODPARC")]
    public int CodePartner
    {
        get => _codePartner;
        set
        {
            _codePartner = value;
            _codePartnerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner destination.
    /// </summary>
    /// <value>
    /// The code partner destination.
    /// </value>
    [EntityElement("CODPARCDEST")]
    public int CodePartnerDestination
    {
        get => _codePartnerDestination;
        set
        {
            _codePartnerDestination = value;
            _codePartnerDestinationSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code contact.
    /// </summary>
    /// <value>The code contact.</value>
    [EntityElement("CODCONTATO")]
    public int CodeContact
    {
        get => _codeContact;
        set
        {
            _codeContact = value;
            _codeContactSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the operation.
    /// </summary>
    /// <value>The type of the operation.</value>
    [EntityElement("CODTIPOPER")]
    public int OperationType
    {
        get => _operationType;
        set
        {
            _operationType = value;
            _operationTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the code trade.
    /// </summary>
    /// <value>The type of the code trade.</value>
    [EntityElement("CODTIPVENDA")]
    public int CodeTradeType
    {
        get => _codeTradeType;
        set
        {
            _codeTradeType = value;
            _codeTradeTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice number.
    /// </summary>
    /// <value>The invoice number.</value>
    [EntityElement("NUMNOTA")]
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
    /// Gets or sets the code seller.
    /// </summary>
    /// <value>The code seller.</value>
    [EntityElement("CODVEND")]
    public int CodeSeller
    {
        get => _codeSeller;
        set
        {
            _codeSeller = value;
            _codeSellerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date traded.
    /// </summary>
    /// <value>The date traded.</value>
    [EntityIgnore]
    public DateTime DateTraded
    {
        get => _dateTraded;
        set
        {
            _dateTraded = value;
            _dateTradedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date traded internal.
    /// </summary>
    /// <value>The date traded internal.</value>
    [EntityElement("DTNEG")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DateTradedInternal
    {
        get => _dateTraded.ToShortDateString();
        set
        {
            _dateTraded = value.ToDateTime();
            _dateTradedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date imported.
    /// </summary>
    /// <value>The date imported.</value>
    [EntityIgnore]
    public DateTime DateImported
    {
        get => _dateImported;
        set
        {
            _dateImported = value;
            _dateImportedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date imported internal.
    /// </summary>
    /// <value>The date imported internal.</value>
    [EntityElement("DTENTSAI")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DateImportedInternal
    {
        get => _dateImported.ToString(@"dd/MM/yyyy HH:mm:ss");
        set
        {
            _dateImported = value.ToDateTime();
            _dateImportedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date billed.
    /// </summary>
    /// <value>The date billed.</value>
    [EntityElement("DTFATUR")]
    public DateTime DateBilled
    {
        get => _dateBilled;
        set
        {
            _dateBilled = value;
            _dateBilledSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date expected delivery.
    /// </summary>
    /// <value>The date expected delivery.</value>
    [EntityIgnore]
    public DateTime DateExpectedDelivery
    {
        get => _dateExpectedDelivery;
        set
        {
            _dateExpectedDelivery = value;
            _dateExpectedDeliverySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date expected delivery internal.
    /// </summary>
    /// <value>The date expected delivery internal.</value>
    [EntityElement("DTPREVENT")]
    public string DateExpectedDeliveryInternal
    {
        get => _dateExpectedDelivery.ToString(@"dd/MM/yyyy HH:mm:ss");
        set
        {
            if (value != null)
            {
                _dateExpectedDelivery = value.ToDateTime();
            }

            _dateExpectedDeliverySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
    [EntityElement("DTALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged;
        set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code result center.
    /// </summary>
    /// <value>The code result center.</value>
    [EntityElement("CODCENCUS")]
    public int CodeResultCenter
    {
        get => _codeResultCenter;
        set
        {
            _codeResultCenter = value;
            _codeResultCenterSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code nature.
    /// </summary>
    /// <value>The code nature.</value>
    [EntityElement("CODNAT")]
    public int CodeNature
    {
        get => _codeNature;
        set
        {
            _codeNature = value;
            _codeNatureSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the movement.
    /// </summary>
    /// <value>The type of the movement.</value>
    [EntityIgnore]
    public MovementType MovementType
    {
        get => _movementType;
        set
        {
            _movementType = value;
            _movementTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the movement type internal.
    /// </summary>
    /// <value>The movement type internal.</value>
    [EntityElement("TIPMOV")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string MovementTypeInternal
    {
        get => _movementType.GetInternalValue();
        set
        {
            _movementType = EnumExtensions.GetEnumByInternalValueAttribute<MovementType>(value);
            _movementTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the freight value.
    /// </summary>
    /// <value>The freight value.</value>
    [EntityElement("VLRFRETE")]
    public decimal FreightValue
    {
        get => _freightValue;
        set
        {
            _freightValue = value;
            _freightValueSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the note.
    /// </summary>
    /// <value>The note.</value>
    [EntityElement("OBSERVACAO")]
    public string Note
    {
        get => _note;
        set
        {
            _note = value;
            _noteSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the freight.
    /// </summary>
    /// <value>The type of the freight.</value>
    [EntityIgnore]
    public FreightType FreightType
    {
        get => _freightType;
        set
        {
            _freightType = value;
            _freightTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the freight type internal.
    /// </summary>
    /// <value>The freight type internal.</value>
    [EntityElement("CIF_FOB", true)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string FreightTypeInternal
    {
        get => _freightType.GetInternalValue();
        set
        {
            _freightType = EnumExtensions.GetEnumByInternalValueAttribute<FreightType>(value);
            _freightTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice status.
    /// </summary>
    /// <value>The invoice status.</value>
    [EntityIgnore]
    public InvoiceStatus InvoiceStatus
    {
        get => _invoiceStatus;
        set
        {
            _invoiceStatus = value;
            _invoiceStatusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice status internal.
    /// </summary>
    /// <value>The invoice status internal.</value>
    [EntityElement("STATUSNOTA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string InvoiceStatusInternal
    {
        get => _invoiceStatus.GetInternalValue();
        set
        {
            _invoiceStatus = EnumExtensions.GetEnumByInternalValueAttribute<InvoiceStatus>(value);
            _invoiceStatusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the invoice freight.
    /// </summary>
    /// <value>The type of the invoice freight.</value>
    [EntityIgnore]
    public InvoiceFreightType InvoiceFreightType
    {
        get => _invoiceFreightType;
        set
        {
            _invoiceFreightType = value;
            _invoiceFreightTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice freight type internal.
    /// </summary>
    /// <value>The invoice freight type internal.</value>
    [EntityElement("TIPFRETE")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string InvoiceFreightTypeInternal
    {
        get => _invoiceFreightType.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _invoiceFreightType =
                EnumExtensions.GetEnumByInternalValueAttribute<InvoiceFreightType>(value);
            _invoiceFreightTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner carrier.
    /// </summary>
    /// <value>The code partner carrier.</value>
    [EntityElement("CODPARCTRANSP")]
    public int CodePartnerCarrier
    {
        get => _codePartnerCarrier;
        set
        {
            _codePartnerCarrier = value;
            _codePartnerCarrierSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the fiscal invoice status.
    /// </summary>
    /// <value>The fiscal invoice status.</value>
    [EntityIgnore]
    public FiscalInvoiceStatus FiscalInvoiceStatus
    {
        get => _fiscalInvoiceStatus;
        set
        {
            _fiscalInvoiceStatus = value;
            _fiscalInvoiceStatusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the fiscal invoice status internal.
    /// </summary>
    /// <value>The fiscal invoice status internal.</value>
    [EntityElement("STATUSNFE")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string FiscalInvoiceStatusInternal
    {
        get => _fiscalInvoiceStatus.GetInternalValue();
        set
        {
            _fiscalInvoiceStatus =
                value == null
                    ? FiscalInvoiceStatus.NotNfe
                    : EnumExtensions.GetEnumByInternalValueAttribute<FiscalInvoiceStatus>(value);
            _fiscalInvoiceStatusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the confirmed.
    /// </summary>
    /// <value>The confirmed.</value>
    [EntityIgnore]
    public bool Confirmed
    {
        get => _confirmed;
        set
        {
            _confirmed = value;
            _confirmedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the confirmed internal.
    /// </summary>
    /// <value>The confirmed internal.</value>
    [EntityElement("CONFIRMADA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ConfirmedInternal
    {
        get => _confirmed.ToString(@"Sim", @"Não");
        set
        {
            _confirmed = value.ToBoolean(@"Sim");
            _confirmedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the pending.
    /// </summary>
    /// <value>The pending.</value>
    [EntityIgnore]
    public bool Pending
    {
        get => _pending;
        set
        {
            _pending = value;
            _pendingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the pending internal.
    /// </summary>
    /// <value>The pending internal.</value>
    [EntityElement("PENDENTE")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string PendingInternal
    {
        get => _pending.ToString(@"S", @"N");
        set
        {
            _pending = value.ToBoolean();
            _pendingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the fiscal invoice key.
    /// </summary>
    /// <value>The fiscal invoice key.</value>
    [EntityElement("CHAVENFE")]
    public string FiscalInvoiceKey
    {
        get => _fiscalInvoiceKey;
        set
        {
            _fiscalInvoiceKey = value;
            _fiscalInvoiceKeySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the movement time.
    /// </summary>
    /// <value>The movement time.</value>
    [EntityIgnore]
    public TimeSpan MovementTime
    {
        get => _movementTime;
        set
        {
            _movementTime = value;
            _movementTimeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the movement time internal.
    /// </summary>
    /// <value>The movement time internal.</value>
    /// <exception cref="ArgumentOutOfRangeException">value - MovementTime</exception>
    /// <exception cref="ArgumentOutOfRangeException">The {nameof(MovementTime)}</exception>
    [EntityElement("HRMOV")]
    public string MovementTimeInternal
    {
        get => string.Concat(_movementTime.Hours, _movementTime.Minutes, _movementTime.Seconds);
        set
        {
            if (value == null)
            {
                return;
            }

            switch (value.Length)
            {
                case 1:
                    _movementTime = new(value.ToInt32(), 0, 0);
                    break;
                case 2:
                    _movementTime = new(
                        value.Substring(0, 1).ToInt32(),
                        value.Substring(1, 1).ToInt32(),
                        0
                    );
                    break;
                case 3:
                    _movementTime = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 1).ToInt32(),
                        0
                    );
                    break;
                case 4:
                    _movementTime = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        0
                    );
                    break;
                case 5:
                    _movementTime = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        value.Substring(4, 1).ToInt32()
                    );
                    break;
                case 6:
                    _movementTime = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        value.Substring(4, 2).ToInt32()
                    );
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.TheValueMustHaveBetween1and6digits,
                            nameof(MovementTime)
                        )
                    );
            }

            _movementTimeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice value.
    /// </summary>
    /// <value>The invoice value.</value>
    [EntityElement("VLRNOTA")]
    public decimal InvoiceValue
    {
        get => _invoiceValue;
        set
        {
            _invoiceValue = value;
            _invoiceValueSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the partner.
    /// </summary>
    /// <value>The partner.</value>
    [EntityReference]
    public Partner Partner
    {
        get => _partner;
        set
        {
            _partner = value;
            _partnerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the partner destination.
    /// </summary>
    /// <value>
    /// The partner destination.
    /// </value>
    [EntityReference]
    public Partner PartnerDestination
    {
        get => _partnerDestination;
        set
        {
            _partnerDestination = value;
            _partnerDestinationSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the partner carrier.
    /// </summary>
    /// <value>The partner carrier.</value>
    [EntityReference("Transportadora")]
    public Partner PartnerCarrier
    {
        get => _partnerCarrier;
        set
        {
            _partnerCarrier = value;
            _partnerCarrierSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the partner royalties.
    /// </summary>
    /// <value>The partner royalties.</value>
    [EntityReference("Parceiro_AD001")]
    public Partner PartnerRoyalties
    {
        get => _partnerRoyalties;
        set
        {
            _partnerRoyalties = value;
            _partnerRoyaltiesSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the seller.
    /// </summary>
    /// <value>The seller.</value>
    [EntityReference]
    public Seller Seller
    {
        get => _seller;
        set
        {
            _seller = value;
            _sellerSet = true;
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
    /// Should the serialize code company.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// The should serialize code partner destination serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartnerDestination() => _codePartnerDestinationSet;

    /// <summary>
    /// Should the serialize code contact.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeContact() => _codeContactSet;

    /// <summary>
    /// Should the type of the serialize operation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationType() => _operationTypeSet;

    /// <summary>
    /// Should the type of the serialize code trade.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeTradeType() => _codeTradeTypeSet;

    /// <summary>
    /// Should the serialize invoice number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    /// <summary>
    /// Should the serialize code seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    /// <summary>
    /// Should the serialize date traded.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateTraded() => _dateTradedSet;

    /// <summary>
    /// Should the serialize date imported.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateImported() => _dateImportedSet;

    /// <summary>
    /// Should the serialize date billed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateBilled() => _dateBilledSet;

    /// <summary>
    /// Should the serialize date expected delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExpectedDelivery() => _dateExpectedDeliverySet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Should the serialize code result center.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;

    /// <summary>
    /// Should the serialize code nature.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeNature() => _codeNatureSet;

    /// <summary>
    /// Should the type of the serialize movement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementType() => _movementTypeSet;

    /// <summary>
    /// Should the serialize freight value.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFreightValue() => _freightValueSet;

    /// <summary>
    /// Should the serialize note.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNote() => _noteSet;

    /// <summary>
    /// Should the type of the serialize freight.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFreightType() => _freightTypeSet;

    /// <summary>
    /// Should the serialize invoice status.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceStatus() => _invoiceStatusSet;

    /// <summary>
    /// Should the type of the serialize invoice freight.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceFreightType() => _invoiceFreightTypeSet;

    /// <summary>
    /// Should the serialize code partner carrier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartnerCarrier() => _codePartnerCarrierSet;

    /// <summary>
    /// Should the serialize fiscal invoice status.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalInvoiceStatus() => _fiscalInvoiceStatusSet;

    /// <summary>
    /// Should the serialize confirmed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfirmed() => _confirmedSet;

    /// <summary>
    /// Should the serialize pending.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePending() => _pendingSet;

    /// <summary>
    /// Should the serialize fiscal invoice key.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalInvoiceKey() => _fiscalInvoiceKeySet;

    /// <summary>
    /// Should the serialize movement time.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementTime() => _movementTimeSet;

    /// <summary>
    /// Should the serialize invoice value.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceValue() => _invoiceValueSet;

    /// <summary>
    /// Should the serialize partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    /// <summary>
    /// The should serialize partner destination serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerDestination() => _partnerDestinationSet;

    /// <summary>
    /// Should the serialize partner carrier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerCarrier() => _partnerCarrierSet;

    /// <summary>
    /// Should the serialize partner royalties.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerRoyalties() => _partnerRoyaltiesSet;

    /// <summary>
    /// Should the serialize seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;
}
