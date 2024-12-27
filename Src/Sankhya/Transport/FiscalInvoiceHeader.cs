using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("CabecalhoNota")]
public class FiscalInvoiceHeader : IEntity, IEquatable<FiscalInvoiceHeader>
{
    public bool Equals(FiscalInvoiceHeader other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                string.Equals(_invoiceKey, other._invoiceKey, StringComparison.OrdinalIgnoreCase)
                && _invoiceKeySet == other._invoiceKeySet
                && _invoiceNumber == other._invoiceNumber
                && _invoiceNumberSet == other._invoiceNumberSet
                && _operationType == other._operationType
                && _operationTypeSet == other._operationTypeSet
                && _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _status == other._status
                && _statusSet == other._statusSet
            );
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

        var a = obj as FiscalInvoiceHeader;
        return a != null && Equals(a);
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
            var hashCode =
                _invoiceKey != null
                    ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_invoiceKey)
                    : 0;
            hashCode = (hashCode * 397) ^ _invoiceKeySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceNumber;
            hashCode = (hashCode * 397) ^ _invoiceNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _operationType;
            hashCode = (hashCode * 397) ^ _operationTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _singleNumber;
            hashCode = (hashCode * 397) ^ _singleNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_status;
            hashCode = (hashCode * 397) ^ _statusSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(FiscalInvoiceHeader left, FiscalInvoiceHeader right) =>
        Equals(left, right);

    public static bool operator !=(FiscalInvoiceHeader left, FiscalInvoiceHeader right) =>
        !Equals(left, right);

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private FiscalInvoiceStatus _status;

    private bool _statusSet;

    private int _operationType;

    private bool _operationTypeSet;

    private string _invoiceKey;

    private bool _invoiceKeySet;

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

    [EntityIgnore]
    public FiscalInvoiceStatus Status
    {
        get => _status;
        set
        {
            _status = value;
            _statusSet = true;
        }
    }

    [EntityElement("STATUSNFE")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string StatusInternal
    {
        get => _status.GetInternalValue();
        set
        {
            _status = string.IsNullOrWhiteSpace(value)
                ? FiscalInvoiceStatus.NotNfe
                : EnumExtensions.GetEnumByInternalValueAttribute<FiscalInvoiceStatus>(value);
            _statusSet = true;
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

    [EntityElement("CHAVENFE")]
    public string InvoiceKey
    {
        get => _invoiceKey;
        set
        {
            _invoiceKey = value;
            _invoiceKeySet = true;
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
    public bool ShouldSerializeStatus() => _statusSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationType() => _operationTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceKey() => _invoiceKeySet;
}
