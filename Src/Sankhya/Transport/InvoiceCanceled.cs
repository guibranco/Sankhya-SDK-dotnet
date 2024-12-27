using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("NotaCancelada")]
public class InvoiceCanceled : IEntity, IEquatable<InvoiceCanceled>
{
    public bool Equals(InvoiceCanceled other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _singleNumber == other._singleNumber
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
                    StringComparison.OrdinalIgnoreCase
                )
                && _cancellationReasonSet == other._cancellationReasonSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is InvoiceCanceled canceled && Equals(canceled));
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

    public static bool operator ==(InvoiceCanceled left, InvoiceCanceled right) =>
        Equals(left, right);

    public static bool operator !=(InvoiceCanceled left, InvoiceCanceled right) =>
        !Equals(left, right);

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private DateTime _dateCanceled;

    private bool _dateCanceledSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private string _cancellationReason;

    private bool _cancellationReasonSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateCanceled() => _dateCanceledSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancellationReason() => _cancellationReasonSet;
}
