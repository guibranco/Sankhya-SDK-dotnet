using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class InvoiceCanceled. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("NotaCancelada")]
public class InvoiceCanceled : IEntity, IEquatable<InvoiceCanceled>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(InvoiceCanceled other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && _dateCanceled.Equals(other._dateCanceled)
                && _dateCanceledSet == other._dateCanceledSet
                && _invoiceNumber == other._invoiceNumber
                && _invoiceNumberSet == other._invoiceNumberSet
                && string.Equals(
                    _cancellationReason,
                    other._cancellationReason,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _cancellationReasonSet == other._cancellationReasonSet;
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

        return ReferenceEquals(this, obj) || obj is InvoiceCanceled canceled && Equals(canceled);
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
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateCanceled.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateCanceledSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceNumber;
            hashCode = (hashCode * 397) ^ _invoiceNumberSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _cancellationReason != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_cancellationReason)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _cancellationReasonSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(InvoiceCanceled left, InvoiceCanceled right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(InvoiceCanceled left, InvoiceCanceled right) =>
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
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The date canceled
    /// </summary>
    private DateTime _dateCanceled;

    /// <summary>
    /// The date canceled set
    /// </summary>
    private bool _dateCanceledSet;

    /// <summary>
    /// The invoice number
    /// </summary>
    private int _invoiceNumber;

    /// <summary>
    /// The invoice number set
    /// </summary>
    private bool _invoiceNumberSet;

    /// <summary>
    /// The cancellation reason
    /// </summary>
    private string _cancellationReason;

    /// <summary>
    /// The cancellation reason set
    /// </summary>
    private bool _cancellationReasonSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
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
    /// Gets or sets the date canceled.
    /// </summary>
    /// <value>The date canceled.</value>
    [EntityElement("DTCANC")]
    public DateTime DateCanceled
    {
        get => _dateCanceled;
        set
        {
            _dateCanceled = value;
            _dateCanceledSet = true;
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
    /// Gets or sets the cancellation reason.
    /// </summary>
    /// <value>The cancellation reason.</value>
    [EntityElement("MOTCANCEL")]
    public string CancellationReason
    {
        get => _cancellationReason;
        set
        {
            _cancellationReason = value;
            _cancellationReasonSet = true;
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
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize date canceled.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateCanceled() => _dateCanceledSet;

    /// <summary>
    /// Should the serialize invoice number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    /// <summary>
    /// Should the serialize cancellation reason.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancellationReason() => _cancellationReasonSet;

    #endregion
}
