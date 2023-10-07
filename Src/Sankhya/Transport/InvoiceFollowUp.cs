using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.Transport;

/// <summary>
/// Class InvoiceFollowUp. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("AcompanhamentoNota")]
public class InvoiceFollowUp : IEntity, IEquatable<InvoiceFollowUp>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>

    // ReSharper disable once CyclomaticComplexity
    public bool Equals(InvoiceFollowUp other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _singleNumber == other._singleNumber
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
                    StringComparison.InvariantCultureIgnoreCase
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
                && _invoiceItemSet == other._invoiceItemSet;
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

        return ReferenceEquals(this, obj) || obj is InvoiceFollowUp up && Equals(up);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(InvoiceFollowUp left, InvoiceFollowUp right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(InvoiceFollowUp left, InvoiceFollowUp right) =>
        !Equals(left, right);

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
    /// The sequence
    /// </summary>
    private int _sequence;

    /// <summary>
    /// The sequence set
    /// </summary>
    private bool _sequenceSet;

    /// <summary>
    /// The code user
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The date occurrence
    /// </summary>
    private DateTime _dateOccurrence;

    /// <summary>
    /// The date occurrence set
    /// </summary>
    private bool _dateOccurrenceSet;

    /// <summary>
    /// The time occurrence
    /// </summary>
    private TimeSpan _timeOccurrence;

    /// <summary>
    /// The time occurrence set
    /// </summary>
    private bool _timeOccurrenceSet;

    /// <summary>
    /// The occurrences
    /// </summary>
    private string _occurrences;

    /// <summary>
    /// The occurrences set
    /// </summary>
    private bool _occurrencesSet;

    /// <summary>
    /// The typed
    /// </summary>
    private bool _typed;

    /// <summary>
    /// The typed set
    /// </summary>
    private bool _typedSet;

    /// <summary>
    /// The reference
    /// </summary>
    private InvoiceFollowUpReference _reference;

    /// <summary>
    /// The reference set
    /// </summary>
    private bool _referenceSet;

    /// <summary>
    /// The user
    /// </summary>
    private User _user;

    /// <summary>
    /// The user set
    /// </summary>
    private bool _userSet;

    /// <summary>
    /// The invoice header
    /// </summary>
    private InvoiceHeader _invoiceHeader;

    /// <summary>
    /// The invoice header set
    /// </summary>
    private bool _invoiceHeaderSet;

    /// <summary>
    /// The invoice item
    /// </summary>
    private InvoiceItem _invoiceItem;

    /// <summary>
    /// The invoice item set
    /// </summary>
    private bool _invoiceItemSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
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

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>The sequence.</value>
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

    /// <summary>
    /// Gets or sets the code user.
    /// </summary>
    /// <value>The code user.</value>
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

    /// <summary>
    /// Gets or sets the date occurrence.
    /// </summary>
    /// <value>The date occurrence.</value>
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

    /// <summary>
    /// Gets or sets the time occurrence.
    /// </summary>
    /// <value>The time occurrence.</value>
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

    /// <summary>
    /// Gets or sets the time occurrence internal.
    /// </summary>
    /// <value>The time occurrence internal.</value>
    /// <exception cref="ArgumentOutOfRangeException">The {nameof(TimeOccurrence)}</exception>
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

    /// <summary>
    /// Gets or sets the occurrences.
    /// </summary>
    /// <value>The occurrences.</value>
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

    /// <summary>
    /// Gets or sets the typed.
    /// </summary>
    /// <value>The typed.</value>
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

    /// <summary>
    /// Gets or sets the typed internal.
    /// </summary>
    /// <value>The typed internal.</value>
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

    /// <summary>
    /// Gets or sets the reference.
    /// </summary>
    /// <value>The reference.</value>
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

    /// <summary>
    /// Gets or sets the reference internal.
    /// </summary>
    /// <value>The reference internal.</value>
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

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
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
    /// Gets or sets the invoice header.
    /// </summary>
    /// <value>The invoice header.</value>
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

    /// <summary>
    /// Gets or sets the invoice item.
    /// </summary>
    /// <value>The invoice item.</value>
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
    /// Should the serialize sequence.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSequence() => _sequenceSet;

    /// <summary>
    /// Should the serialize code user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Should the serialize date occurrence.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateOccurrence() => _dateOccurrenceSet;

    /// <summary>
    /// Should the serialize time occurrence.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTimeOccurrence() => _timeOccurrenceSet;

    /// <summary>
    /// Should the serialize occurrences.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOccurrences() => _occurrencesSet;

    /// <summary>
    /// Should the serialize typed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTyped() => _typedSet;

    /// <summary>
    /// Should the serialize reference.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReference() => _referenceSet;

    /// <summary>
    /// Should the serialize user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;

    /// <summary>
    /// Should the serialize invoice header.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceHeader() => _invoiceHeaderSet;

    /// <summary>
    /// Should the serialize invoice item.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceItem() => _invoiceItemSet;

    #endregion
}
