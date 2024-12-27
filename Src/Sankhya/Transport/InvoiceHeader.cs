using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Helpers;
using Sankhya.Properties;

namespace Sankhya.Transport;

[Entity("CabecalhoNota")]
public class InvoiceHeader : GenericServiceEntity, IEquatable<InvoiceHeader>
{
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

    public static bool operator ==(InvoiceHeader left, InvoiceHeader right) => Equals(left, right);

    public static bool operator !=(InvoiceHeader left, InvoiceHeader right) => !Equals(left, right);

    private int? _singleNumber;

    private bool _singleNumberSet;

    private int _codeCompany;

    private bool _codeCompanySet;

    private int _codePartner;

    private bool _codePartnerSet;

    private int _codePartnerDestination;

    private bool _codePartnerDestinationSet;

    private int _codeContact;

    private bool _codeContactSet;

    private int _operationType;

    private bool _operationTypeSet;

    private int _codeTradeType;

    private bool _codeTradeTypeSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private int _codeSeller;

    private bool _codeSellerSet;

    private DateTime _dateTraded;

    private bool _dateTradedSet;

    private DateTime _dateImported;

    private bool _dateImportedSet;

    private DateTime _dateBilled;

    private bool _dateBilledSet;

    private DateTime _dateExpectedDelivery;

    private bool _dateExpectedDeliverySet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    private int _codeResultCenter;

    private bool _codeResultCenterSet;

    private int _codeNature;

    private bool _codeNatureSet;

    private MovementType _movementType;

    private bool _movementTypeSet;

    private decimal _freightValue;

    private bool _freightValueSet;

    private string _note;

    private bool _noteSet;

    private FreightType _freightType;

    private bool _freightTypeSet;

    private InvoiceStatus _invoiceStatus;

    private bool _invoiceStatusSet;

    private InvoiceFreightType _invoiceFreightType;

    private bool _invoiceFreightTypeSet;

    private int _codePartnerCarrier;

    private bool _codePartnerCarrierSet;

    private FiscalInvoiceStatus _fiscalInvoiceStatus;

    private bool _fiscalInvoiceStatusSet;

    private bool _confirmed;

    private bool _confirmedSet;

    private bool _pending;

    private bool _pendingSet;

    private string _fiscalInvoiceKey;

    private bool _fiscalInvoiceKeySet;

    private TimeSpan _movementTime;

    private bool _movementTimeSet;

    private decimal _invoiceValue;

    private bool _invoiceValueSet;

    private Partner _partner;

    private bool _partnerSet;

    private Partner _partnerDestination;

    private bool _partnerDestinationSet;

    private Partner _partnerCarrier;

    private bool _partnerCarrierSet;

    private Partner _partnerRoyalties;

    private bool _partnerRoyaltiesSet;

    private Seller _seller;

    private bool _sellerSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartnerDestination() => _codePartnerDestinationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeContact() => _codeContactSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationType() => _operationTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeTradeType() => _codeTradeTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateTraded() => _dateTradedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateImported() => _dateImportedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateBilled() => _dateBilledSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExpectedDelivery() => _dateExpectedDeliverySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeNature() => _codeNatureSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementType() => _movementTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFreightValue() => _freightValueSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNote() => _noteSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFreightType() => _freightTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceStatus() => _invoiceStatusSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceFreightType() => _invoiceFreightTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartnerCarrier() => _codePartnerCarrierSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalInvoiceStatus() => _fiscalInvoiceStatusSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfirmed() => _confirmedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePending() => _pendingSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalInvoiceKey() => _fiscalInvoiceKeySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementTime() => _movementTimeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceValue() => _invoiceValueSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerDestination() => _partnerDestinationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerCarrier() => _partnerCarrierSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartnerRoyalties() => _partnerRoyaltiesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;
}
