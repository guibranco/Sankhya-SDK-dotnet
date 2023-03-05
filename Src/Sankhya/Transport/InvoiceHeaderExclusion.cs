namespace Sankhya.Transport;

using System;
using System.ComponentModel;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Properties;

/// <summary>
/// Class InvoiceHeaderExclusion. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
/// <seealso cref="IEquatable{InvoiceHeaderExclusion}" />
[Entity("CabecalhoNotaExcluida")]
public class InvoiceHeaderExclusion : IEntity, IEquatable<InvoiceHeaderExclusion>
{
    #region Equality Members 

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    // ReSharper disable once FunctionComplexityOverflow
    public bool Equals(InvoiceHeaderExclusion other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other) || _singleNumber == other._singleNumber && _singleNumberSet == other._singleNumberSet &&
            _invoiceNumber == other._invoiceNumber && _invoiceNumberSet == other._invoiceNumberSet &&
            _dateTraded.Equals(other._dateTraded) && _dateTradedSet == other._dateTradedSet &&
            _invoiceValue == other._invoiceValue && _invoiceValueSet == other._invoiceValueSet &&
            _movementType == other._movementType && _movementTypeSet == other._movementTypeSet &&
            _dateExclusion.Equals(other._dateExclusion) && _dateExclusionSet == other._dateExclusionSet &&
            _codePartner == other._codePartner && _codePartnerSet == other._codePartnerSet &&
            _codeSeller == other._codeSeller && _codeSellerSet == other._codeSellerSet &&
            _codeCompany == other._codeCompany && _codeCompanySet == other._codeCompanySet &&
            _codeResultCenter == other._codeResultCenter &&
            _codeResultCenterSet == other._codeResultCenterSet && _codeTradeType == other._codeTradeType &&
            _codeTradeTypeSet == other._codeTradeTypeSet &&
            _codeOperationType == other._codeOperationType &&
            _codeOperationTypeSet == other._codeOperationTypeSet &&
            _dateChanged.Equals(other._dateChanged) && _dateChangedSet == other._dateChangedSet &&
            _dateEntryExit.Equals(other._dateEntryExit) && _dateEntryExitSet == other._dateEntryExitSet &&
            _dateMovement.Equals(other._dateMovement) && _dateMovementSet == other._dateMovementSet &&
            _timeMovement.Equals(other._timeMovement) && _timeMovementSet == other._timeMovementSet &&
            string.Equals(_invoiceSeries, other._invoiceSeries, StringComparison.InvariantCultureIgnoreCase) &&
            _invoiceSeriesSet == other._invoiceSeriesSet &&
            string.Equals(_hostName, other._hostName, StringComparison.InvariantCultureIgnoreCase) &&
            _hostNameSet == other._hostNameSet && Equals(_tradingType, other._tradingType) &&
            _tradingTypeSet == other._tradingTypeSet && Equals(_user, other._user) &&
            _userSet == other._userSet && Equals(_seller, other._seller) &&
            _sellerSet == other._sellerSet;
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

        return ReferenceEquals(this, obj) || obj is InvoiceHeaderExclusion exclusion && Equals(exclusion);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    // ReSharper disable once MethodTooLong
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
            hashCode = (hashCode * 397) ^ (_invoiceSeries != null
                ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_invoiceSeries)
                : 0);
            hashCode = (hashCode * 397) ^ _invoiceSeriesSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_hostName != null
                ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_hostName)
                : 0);
            hashCode = (hashCode * 397) ^ _hostNameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_tradingType != null
                ? _tradingType.GetHashCode()
                : 0);
            hashCode = (hashCode * 397) ^ _tradingTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_user != null
                ? _user.GetHashCode()
                : 0);
            hashCode = (hashCode * 397) ^ _userSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null
                ? _seller.GetHashCode()
                : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="InvoiceHeaderExclusion" /> objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
    public static bool operator ==(InvoiceHeaderExclusion left, InvoiceHeaderExclusion right) => Equals(left, right);

    /// <summary>
    /// Returns a value that indicates whether two <see cref="InvoiceHeaderExclusion" /> objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
    public static bool operator !=(InvoiceHeaderExclusion left, InvoiceHeaderExclusion right) => !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The single number
    /// </summary>
    private int _singleNumber;
    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The invoice number
    /// </summary>
    private int _invoiceNumber;
    /// <summary>
    /// The invoice number set
    /// </summary>
    private bool _invoiceNumberSet;

    /// <summary>
    /// The date traded
    /// </summary>
    private DateTime _dateTraded;
    /// <summary>
    /// The date traded set
    /// </summary>
    private bool _dateTradedSet;

    /// <summary>
    /// The invoice value
    /// </summary>
    private decimal _invoiceValue;
    /// <summary>
    /// The invoice value set
    /// </summary>
    private bool _invoiceValueSet;

    /// <summary>
    /// The movement type
    /// </summary>
    private MovementType _movementType;
    /// <summary>
    /// The movement type set
    /// </summary>
    private bool _movementTypeSet;

    /// <summary>
    /// The date exclusion
    /// </summary>
    private DateTime _dateExclusion;
    /// <summary>
    /// The date exclusion set
    /// </summary>
    private bool _dateExclusionSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;
    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;
    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// The code company
    /// </summary>
    private int _codeCompany;
    /// <summary>
    /// The code company set
    /// </summary>
    private bool _codeCompanySet;

    /// <summary>
    /// The code result center
    /// </summary>
    private int _codeResultCenter;
    /// <summary>
    /// The code result center set
    /// </summary>
    private bool _codeResultCenterSet;

    /// <summary>
    /// The code trade type
    /// </summary>
    private int _codeTradeType;
    /// <summary>
    /// The code trade type set
    /// </summary>
    private bool _codeTradeTypeSet;

    /// <summary>
    /// The code operation type
    /// </summary>
    private int _codeOperationType;
    /// <summary>
    /// The code operation type set
    /// </summary>
    private bool _codeOperationTypeSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;
    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The date entry exit
    /// </summary>
    private DateTime _dateEntryExit;
    /// <summary>
    /// The date entry exit set
    /// </summary>
    private bool _dateEntryExitSet;

    /// <summary>
    /// The date movement
    /// </summary>
    private DateTime _dateMovement;
    /// <summary>
    /// The date movement set
    /// </summary>
    private bool _dateMovementSet;

    /// <summary>
    /// The time movement
    /// </summary>
    private TimeSpan _timeMovement;
    /// <summary>
    /// The time movement set
    /// </summary>
    private bool _timeMovementSet;

    /// <summary>
    /// The invoice series
    /// </summary>
    private string _invoiceSeries;
    /// <summary>
    /// The invoice series set
    /// </summary>
    private bool _invoiceSeriesSet;

    /// <summary>
    /// The host name
    /// </summary>
    private string _hostName;
    /// <summary>
    /// The host name set
    /// </summary>
    private bool _hostNameSet;

    /// <summary>
    /// The trading type
    /// </summary>
    private TradingType _tradingType;
    /// <summary>
    /// The trading type set
    /// </summary>
    private bool _tradingTypeSet;

    /// <summary>
    /// The user
    /// </summary>
    private User _user;
    /// <summary>
    /// The user set
    /// </summary>
    private bool _userSet;

    /// <summary>
    /// The seller
    /// </summary>
    private Seller _seller;
    /// <summary>
    /// The seller set
    /// </summary>
    private bool _sellerSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
    [EntityElement("NUNOTA")]
    public int SingleNumber
    {
        get => _singleNumber; set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }


    /// <summary>
    /// Gets or sets the invoice number.
    /// </summary>
    /// <value>The invoice number.</value>
    [EntityElement("NUMNOTA")]
    public int InvoiceNumber
    {
        get => _invoiceNumber; set
        {

            _invoiceNumber = value;
            _invoiceNumberSet = true;
        }

    }

    /// <summary>
    /// Gets or sets the date traded.
    /// </summary>
    /// <value>The date traded.</value>
    [EntityElement("DTNEG")]
    public DateTime DateTraded
    {
        get => _dateTraded; set
        {
            _dateTraded = value;
            _dateTradedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice value.
    /// </summary>
    /// <value>The invoice value.</value>
    [EntityElement("VLRNOTA")]
    public decimal InvoiceValue
    {
        get => _invoiceValue; set
        {
            _invoiceValue = value;
            _invoiceValueSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the movement.
    /// </summary>
    /// <value>The type of the movement.</value>
    [EntityIgnore]
    public MovementType MovementType
    {
        get => _movementType; set
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
        get => _movementType.GetInternalValue(); set
        {
            _movementType = EnumExtensions.GetEnumByInternalValueAttribute<MovementType>(value);
            _movementTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date exclusion.
    /// </summary>
    /// <value>The date exclusion.</value>
    [EntityElement("DHEXCLUSAO")]
    public DateTime DateExclusion
    {
        get => _dateExclusion; set
        {
            _dateExclusion = value;
            _dateExclusionSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [EntityElement("CODPARC")]
    public int CodePartner
    {
        get => _codePartner; set
        {
            _codePartner = value;
            _codePartnerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code seller.
    /// </summary>
    /// <value>The code seller.</value>
    [EntityElement("CODVEND")]
    public int CodeSeller
    {
        get => _codeSeller; set
        {
            _codeSeller = value;
            _codeSellerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code company.
    /// </summary>
    /// <value>The code company.</value>
    [EntityElement("CODEMP")]
    public int CodeCompany
    {
        get => _codeCompany; set
        {
            _codeCompany = value;
            _codeCompanySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code result center.
    /// </summary>
    /// <value>The code result center.</value>
    [EntityElement("CODCENCUS")]
    public int CodeResultCenter
    {
        get => _codeResultCenter; set
        {
            _codeResultCenter = value;
            _codeResultCenterSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the code trade.
    /// </summary>
    /// <value>The type of the code trade.</value>
    [EntityElement("CODTIPVENDA")]
    public int CodeTradeType
    {
        get => _codeTradeType; set
        {
            _codeTradeType = value;
            _codeTradeTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the code operation.
    /// </summary>
    /// <value>The type of the code operation.</value>
    [EntityElement("CODTIPOPER")]
    public int CodeOperationType
    {
        get => _codeOperationType; set
        {
            _codeOperationType = value;
            _codeOperationTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
    [EntityElement("DTALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged; set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date entry exit.
    /// </summary>
    /// <value>The date entry exit.</value>
    [EntityElement("DTENTSAI")]
    public DateTime DateEntryExit
    {
        get => _dateEntryExit; set
        {
            _dateEntryExit = value;
            _dateEntryExitSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date movement.
    /// </summary>
    /// <value>The date movement.</value>
    [EntityElement("DTMOV")]
    public DateTime DateMovement
    {
        get => _dateMovement; set
        {
            _dateMovement = value;
            _dateMovementSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the time movement.
    /// </summary>
    /// <value>The time movement.</value>
    [EntityIgnore]
    public TimeSpan TimeMovement
    {
        get => _timeMovement; set
        {
            _timeMovement = value;
            _timeMovementSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the time movement internal.
    /// </summary>
    /// <value>The time movement internal.</value>
    /// <exception cref="ArgumentOutOfRangeException">value - TimeMovement</exception>
    [EntityElement("HRMOV")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TimeMovementInternal
    {
        get => string.Concat(_timeMovement.Hours, _timeMovement.Minutes, _timeMovement.Seconds); set
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
                    _timeMovement = new(value.Substring(0, 1).ToInt32(), value.Substring(1, 1).ToInt32(), 0);
                    break;
                case 3:
                    _timeMovement = new(value.Substring(0, 2).ToInt32(), value.Substring(2, 1).ToInt32(), 0);
                    break;
                case 4:
                    _timeMovement = new(value.Substring(0, 2).ToInt32(), value.Substring(2, 2).ToInt32(), 0);
                    break;
                case 5:
                    _timeMovement = new(value.Substring(0, 2).ToInt32(), value.Substring(2, 2).ToInt32(), value.Substring(4, 1).ToInt32());
                    break;
                case 6:
                    _timeMovement = new(value.Substring(0, 2).ToInt32(), value.Substring(2, 2).ToInt32(), value.Substring(4, 2).ToInt32());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, string.Format(CultureInfo.CurrentCulture, Resources.TheValueMustHaveBetween1and6digits, nameof(TimeMovement)));
            }
            _timeMovementSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the invoice series.
    /// </summary>
    /// <value>The invoice series.</value>
    [EntityElement("SERIENOTA")]
    public string InvoiceSeries
    {
        get => _invoiceSeries; set
        {
            _invoiceSeries = value;
            _invoiceSeriesSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the name of the host.
    /// </summary>
    /// <value>The name of the host.</value>
    [EntityElement("HOSTNAME")]
    public string HostName
    {
        get => _hostName; set
        {
            _hostName = value;
            _hostNameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the trading.
    /// </summary>
    /// <value>
    /// The type of the trading.
    /// </value>
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

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
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

    /// <summary>
    /// Gets or sets the seller.
    /// </summary>
    /// <value>
    /// The seller.
    /// </value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize invoice number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    /// <summary>
    /// Should the serialize date traded.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateTraded() => _dateTradedSet;

    /// <summary>
    /// Should the serialize invoice value.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeInvoiceValue() => _invoiceValueSet;

    /// <summary>
    /// Should the type of the serialize movement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeMovementType() => _movementTypeSet;

    /// <summary>
    /// Should the serialize date exclusion.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateExclusion() => _dateExclusionSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize code seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    /// <summary>
    /// Should the serialize code company.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    /// <summary>
    /// Should the serialize code result center.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;

    /// <summary>
    /// Should the type of the serialize code trade.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodeTradeType() => _codeTradeTypeSet;

    /// <summary>
    /// Should the type of the serialize code operation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeCodeOperationType() => _codeOperationTypeSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Should the serialize date entry exit.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateEntryExit() => _dateEntryExitSet;

    /// <summary>
    /// Should the serialize date movement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeDateMovement() => _dateMovementSet;

    /// <summary>
    /// Should the serialize time movement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeMovement() => _timeMovementSet;

    /// <summary>
    /// Should the serialize invoice serie.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceSeries() => _invoiceSeriesSet;

    /// <summary>
    /// Should the name of the serialize host.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHostName() => _hostNameSet;

    /// <summary>
    /// The should serialize trading type serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeTradingType() => _tradingTypeSet;

    /// <summary>
    /// The should serialize user serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeUser() => _userSet;

    /// <summary>
    /// The should serialize seller serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]

    public bool ShouldSerializeSeller() => _sellerSet;

    #endregion
}