using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Class FiscalInvoiceHeader.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("CabecalhoNota")]
public class FiscalInvoiceHeader : IEntity, IEquatable<FiscalInvoiceHeader>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(FiscalInvoiceHeader other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || string.Equals(_invoiceKey, other._invoiceKey, StringComparison.OrdinalIgnoreCase)
                && _invoiceKeySet == other._invoiceKeySet
                && _invoiceNumber == other._invoiceNumber
                && _invoiceNumberSet == other._invoiceNumberSet
                && _operationType == other._operationType
                && _operationTypeSet == other._operationTypeSet
                && _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _status == other._status
                && _statusSet == other._statusSet;
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

        var a = obj as FiscalInvoiceHeader;
        return a != null && Equals(a);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(FiscalInvoiceHeader left, FiscalInvoiceHeader right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(FiscalInvoiceHeader left, FiscalInvoiceHeader right) =>
        !Equals(left, right);

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
    /// The status
    /// </summary>
    private FiscalInvoiceStatus _status;

    /// <summary>
    /// The status set
    /// </summary>
    private bool _statusSet;

    /// <summary>
    /// The operation type
    /// </summary>
    private int _operationType;

    /// <summary>
    /// The operation type set
    /// </summary>
    private bool _operationTypeSet;

    /// <summary>
    /// The invoice key
    /// </summary>
    private string _invoiceKey;

    /// <summary>
    /// The invoice key set
    /// </summary>
    private bool _invoiceKeySet;

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
    /// Gets or sets the status.
    /// </summary>
    /// <value>The status.</value>
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

    /// <summary>
    /// Gets or sets the status internal.
    /// </summary>
    /// <value>The status internal.</value>
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
    /// Gets or sets the invoice key.
    /// </summary>
    /// <value>The invoice key.</value>
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
    /// Should the serialize status.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStatus() => _statusSet;

    /// <summary>
    /// Should the type of the serialize operation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationType() => _operationTypeSet;

    /// <summary>
    /// Should the serialize invoice key.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceKey() => _invoiceKeySet;
}
