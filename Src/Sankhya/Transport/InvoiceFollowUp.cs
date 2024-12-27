using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.Transport;

[Entity("AcompanhamentoNota")]
public class InvoiceFollowUp : IEntity, IEquatable<InvoiceFollowUp>
{
    public bool Equals(InvoiceFollowUp other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _sequence == other._sequence
                && _sequenceSet == other._sequenceSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _dateOccurrence.Equals(other._dateOccurrence)
                && _dateOccurrenceSet == other._dateOccurrenceSet
                && _timeOccurrence.Equals(other._timeOccurrence)
                && _timeOccurrenceSet == other._timeOccurrenceSet
                && string.Equals(
                    _occurrences,
                    other._occurrences,
                    StringComparison.OrdinalIgnoreCase
                )
                && _occurrencesSet == other._occurrencesSet
                && _typed == other._typed
                && _typedSet == other._typedSet
                && _reference == other._reference
                && _referenceSet == other._referenceSet
                && Equals(_user, other._user)
                && _userSet == other._userSet
                && Equals(_invoiceHeader, other._invoiceHeader)
                && _invoiceHeaderSet == other._invoiceHeaderSet
                && Equals(_invoiceItem, other._invoiceItem)
                && _invoiceItemSet == other._invoiceItemSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is InvoiceFollowUp up && Equals(up));
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
            hashCode = (hashCode * 397) ^ _sequence;
            hashCode = (hashCode * 397) ^ _sequenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateOccurrence.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateOccurrenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _timeOccurrence.GetHashCode();
            hashCode = (hashCode * 397) ^ _timeOccurrenceSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _occurrences != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_occurrences)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _occurrencesSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _typed.GetHashCode();
            hashCode = (hashCode * 397) ^ _typedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_reference;
            hashCode = (hashCode * 397) ^ _referenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _userSet.GetHashCode();
            hashCode =
                (hashCode * 397) ^ (_invoiceHeader != null ? _invoiceHeader.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _invoiceHeaderSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_invoiceItem != null ? _invoiceItem.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _invoiceItemSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(InvoiceFollowUp left, InvoiceFollowUp right) =>
        Equals(left, right);

    public static bool operator !=(InvoiceFollowUp left, InvoiceFollowUp right) =>
        !Equals(left, right);

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _sequence;

    private bool _sequenceSet;

    private int _codeUser;

    private bool _codeUserSet;

    private DateTime _dateOccurrence;

    private bool _dateOccurrenceSet;

    private TimeSpan _timeOccurrence;

    private bool _timeOccurrenceSet;

    private string _occurrences;

    private bool _occurrencesSet;

    private bool _typed;

    private bool _typedSet;

    private InvoiceFollowUpReference _reference;

    private bool _referenceSet;

    private User _user;

    private bool _userSet;

    private InvoiceHeader _invoiceHeader;

    private bool _invoiceHeaderSet;

    private InvoiceItem _invoiceItem;

    private bool _invoiceItemSet;

    [EntityElement("NUNOTA")]
    [EntityKey]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    [EntityElement("SEQUENCIA")]
    [EntityKey]
    public int Sequence
    {
        get => _sequence;
        set
        {
            _sequence = value;
            _sequenceSet = true;
        }
    }

    [EntityElement("CODUSU")]
    public int CodeUser
    {
        get => _codeUser;
        set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    [EntityElement("DHOCOR")]
    [EntityKey]
    public DateTime DateOccurrence
    {
        get => _dateOccurrence;
        set
        {
            _dateOccurrence = value;
            _dateOccurrenceSet = true;
        }
    }

    [EntityIgnore]
    public TimeSpan TimeOccurrence
    {
        get => _timeOccurrence;
        set
        {
            _timeOccurrence = value;
            _timeOccurrenceSet = true;
        }
    }

    [EntityElement("HRACT")]
    [EntityKey]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TimeOccurrenceInternal
    {
        get =>
            string.Concat(_timeOccurrence.Hours, _timeOccurrence.Minutes, _timeOccurrence.Seconds);
        set
        {
            if (value == null)
            {
                return;
            }

            switch (value.Length)
            {
                case 1:
                    _timeOccurrence = new(value.ToInt32(), 0, 0);
                    break;
                case 2:
                    _timeOccurrence = new(
                        value.Substring(0, 1).ToInt32(),
                        value.Substring(1, 1).ToInt32(),
                        0
                    );
                    break;
                case 3:
                    _timeOccurrence = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 1).ToInt32(),
                        0
                    );
                    break;
                case 4:
                    _timeOccurrence = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        0
                    );
                    break;
                case 5:
                    _timeOccurrence = new(
                        value.Substring(0, 2).ToInt32(),
                        value.Substring(2, 2).ToInt32(),
                        value.Substring(4, 1).ToInt32()
                    );
                    break;
                case 6:
                    _timeOccurrence = new(
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
                            nameof(TimeOccurrence)
                        )
                    );
            }

            _timeOccurrenceSet = true;
        }
    }

    [EntityElement("OCORRENCIAS")]
    public string Occurrences
    {
        get => _occurrences;
        set
        {
            _occurrences = value;
            _occurrencesSet = true;
        }
    }

    [EntityIgnore]
    public bool Typed
    {
        get => _typed;
        set
        {
            _typed = value;
            _typedSet = true;
        }
    }

    [EntityElement("DIGITADO")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypedInternal
    {
        get => _typed.ToString(@"S", @"N");
        set
        {
            _typed = value.ToBoolean(@"S|N");
            _typedSet = true;
        }
    }

    [EntityIgnore]
    public InvoiceFollowUpReference Reference
    {
        get => _reference;
        set
        {
            _reference = value;
            _referenceSet = true;
        }
    }

    [EntityElement("REFERENCIA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ReferenceInternal
    {
        get => _reference.GetInternalValue();
        set
        {
            _reference = EnumExtensions.GetEnumByInternalValueAttribute<InvoiceFollowUpReference>(
                value
            );
            _referenceSet = true;
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
    public InvoiceHeader InvoiceHeader
    {
        get => _invoiceHeader;
        set
        {
            _invoiceHeader = value;
            _invoiceHeaderSet = true;
        }
    }

    [EntityReference]
    public InvoiceItem InvoiceItem
    {
        get => _invoiceItem;
        set
        {
            _invoiceItem = value;
            _invoiceItemSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequence() => _sequenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateOccurrence() => _dateOccurrenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeOccurrence() => _timeOccurrenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOccurrences() => _occurrencesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTyped() => _typedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReference() => _referenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceHeader() => _invoiceHeaderSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceItem() => _invoiceItemSet;
}
