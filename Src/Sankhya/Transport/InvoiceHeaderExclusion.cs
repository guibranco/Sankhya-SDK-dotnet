using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.Transport;

[Entity("CabecalhoNotaExcluida")]
public class InvoiceHeaderExclusion : IEntity, IEquatable<InvoiceHeaderExclusion>
{
    public bool Equals(InvoiceHeaderExclusion other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _invoiceNumber == other._invoiceNumber
                && _invoiceNumberSet == other._invoiceNumberSet
                && _dateTraded.Equals(other._dateTraded)
                && _dateTradedSet == other._dateTradedSet
                && _invoiceValue == other._invoiceValue
                && _invoiceValueSet == other._invoiceValueSet
                && _movementType == other._movementType
                && _movementTypeSet == other._movementTypeSet
                && _dateExclusion.Equals(other._dateExclusion)
                && _dateExclusionSet == other._dateExclusionSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _codeCompany == other._codeCompany
                && _codeCompanySet == other._codeCompanySet
                && _codeResultCenter == other._codeResultCenter
                && _codeResultCenterSet == other._codeResultCenterSet
                && _codeTradeType == other._codeTradeType
                && _codeTradeTypeSet == other._codeTradeTypeSet
                && _codeOperationType == other._codeOperationType
                && _codeOperationTypeSet == other._codeOperationTypeSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
                && _dateEntryExit.Equals(other._dateEntryExit)
                && _dateEntryExitSet == other._dateEntryExitSet
                && _dateMovement.Equals(other._dateMovement)
                && _dateMovementSet == other._dateMovementSet
                && _timeMovement.Equals(other._timeMovement)
                && _timeMovementSet == other._timeMovementSet
                && string.Equals(
                    _invoiceSeries,
                    other._invoiceSeries,
                    StringComparison.OrdinalIgnoreCase
                )
                && _invoiceSeriesSet == other._invoiceSeriesSet
                && string.Equals(_hostName, other._hostName, StringComparison.OrdinalIgnoreCase)
                && _hostNameSet == other._hostNameSet
                && Equals(_tradingType, other._tradingType)
                && _tradingTypeSet == other._tradingTypeSet
                && Equals(_user, other._user)
                && _userSet == other._userSet
                && Equals(_seller, other._seller)
                && _sellerSet == other._sellerSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj)
            || (obj is InvoiceHeaderExclusion exclusion && Equals(exclusion));
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
            var hashCode = _singleNumber;
            hashCode = (hashCode * 397) ^ _singleNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceNumber;
            hashCode = (hashCode * 397) ^ _invoiceNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateTraded.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateTradedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceValue.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceValueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_movementType;
            hashCode = (hashCode * 397) ^ _movementTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateExclusion.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateExclusionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCompany;
            hashCode = (hashCode * 397) ^ _codeCompanySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeResultCenter;
            hashCode = (hashCode * 397) ^ _codeResultCenterSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeTradeType;
            hashCode = (hashCode * 397) ^ _codeTradeTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeOperationType;
            hashCode = (hashCode * 397) ^ _codeOperationTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateEntryExit.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateEntryExitSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateMovement.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateMovementSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _timeMovement.GetHashCode();
            hashCode = (hashCode * 397) ^ _timeMovementSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _invoiceSeries != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_invoiceSeries)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _invoiceSeriesSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _hostName != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_hostName)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _hostNameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_tradingType != null ? _tradingType.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _tradingTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _userSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null ? _seller.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(InvoiceHeaderExclusion left, InvoiceHeaderExclusion right) =>
        Equals(left, right);

    public static bool operator !=(InvoiceHeaderExclusion left, InvoiceHeaderExclusion right) =>
        !Equals(left, right);

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private DateTime _dateTraded;

    private bool _dateTradedSet;

    private decimal _invoiceValue;

    private bool _invoiceValueSet;

    private MovementType _movementType;

    private bool _movementTypeSet;

    private DateTime _dateExclusion;

    private bool _dateExclusionSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private int _codeSeller;

    private bool _codeSellerSet;

    private int _codeCompany;

    private bool _codeCompanySet;

    private int _codeResultCenter;

    private bool _codeResultCenterSet;

    private int _codeTradeType;

    private bool _codeTradeTypeSet;

    private int _codeOperationType;

    private bool _codeOperationTypeSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    private DateTime _dateEntryExit;

    private bool _dateEntryExitSet;

    private DateTime _dateMovement;

    private bool _dateMovementSet;

    private TimeSpan _timeMovement;

    private bool _timeMovementSet;

    private string _invoiceSeries;

    private bool _invoiceSeriesSet;

    private string _hostName;

    private bool _hostNameSet;

    private TradingType _tradingType;

    private bool _tradingTypeSet;

    private User _user;

    private bool _userSet;

    private Seller _seller;

    private bool _sellerSet;

    [EntityElement("NUNOTA")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
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

    [EntityElement("DTNEG")]
    public DateTime DateTraded
    {
        get => _dateTraded;
        set
        {
            _dateTraded = value;
            _dateTradedSet = true;
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

    [EntityElement("DHEXCLUSAO")]
    public DateTime DateExclusion
    {
        get => _dateExclusion;
        set
        {
            _dateExclusion = value;
            _dateExclusionSet = true;
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

    [EntityElement("CODTIPOPER")]
    public int CodeOperationType
    {
        get => _codeOperationType;
        set
        {
            _codeOperationType = value;
            _codeOperationTypeSet = true;
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

    [EntityElement("DTENTSAI")]
    public DateTime DateEntryExit
    {
        get => _dateEntryExit;
        set
        {
            _dateEntryExit = value;
            _dateEntryExitSet = true;
        }
    }

    [EntityElement("DTMOV")]
    public DateTime DateMovement
    {
        get => _dateMovement;
        set
        {
            _dateMovement = value;
            _dateMovementSet = true;
        }
    }

    [EntityIgnore]
    public TimeSpan TimeMovement
    {
        get => _timeMovement;
        set
        {
            _timeMovement = value;
            _timeMovementSet = true;
        }
    }

    [EntityElement("HRMOV")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TimeMovementInternal
    {
        get => string.Concat(_timeMovement.Hours, _timeMovement.Minutes, _timeMovement.Seconds);
        set
        {
            if (value == null)
            {
                return;
            }

            switch (value.Length)
            {
                case 1:
                    _timeMovement = new(value.ToInt32(), 0, 0);
                    break;
                case 2:
                    _timeMovement = new(
                        value.Substring(0, 1).ToInt32(),
                        value.Substring(1, 1).ToInt32(),
                        0
                    );
                    break;
                case 3:
                    _timeMovement = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 1).ToInt32(),
                        0
                    );
                    break;
                case 4:
                    _timeMovement = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        0
                    );
                    break;
                case 5:
                    _timeMovement = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        value.Substring(4, 1).ToInt32()
                    );
                    break;
                case 6:
                    _timeMovement = new(
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
                            nameof(TimeMovement)
                        )
                    );
            }

            _timeMovementSet = true;
        }
    }

    [EntityElement("SERIENOTA")]
    public string InvoiceSeries
    {
        get => _invoiceSeries;
        set
        {
            _invoiceSeries = value;
            _invoiceSeriesSet = true;
        }
    }

    [EntityElement("HOSTNAME")]
    public string HostName
    {
        get => _hostName;
        set
        {
            _hostName = value;
            _hostNameSet = true;
        }
    }

    [EntityReference]
    public TradingType TradingType
    {
        get => _tradingType;
        set
        {
            _tradingType = value;
            _tradingTypeSet = true;
        }
    }

    [EntityReference]
    public User User
    {
        get => _user;
        set
        {
            _user = value;
            _userSet = true;
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
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateTraded() => _dateTradedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceValue() => _invoiceValueSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementType() => _movementTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateExclusion() => _dateExclusionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeTradeType() => _codeTradeTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeOperationType() => _codeOperationTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateEntryExit() => _dateEntryExitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateMovement() => _dateMovementSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeMovement() => _timeMovementSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceSeries() => _invoiceSeriesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHostName() => _hostNameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTradingType() => _tradingTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;
}
