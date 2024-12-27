using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("Financeiro")]
public class Financial : IEntity, IEquatable<Financial>
{
    public bool Equals(Financial other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _singleNumberInvoice == other._singleNumberInvoice
                && _singleNumberInvoiceSet == other._singleNumberInvoiceSet
                && _invoiceNumber == other._invoiceNumber
                && _invoiceNumberSet == other._invoiceNumberSet
                && _dateLow.Equals(other._dateLow)
                && _dateLowSet == other._dateLowSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
                && string.Equals(_barCode, other._barCode, StringComparison.OrdinalIgnoreCase)
                && _barCodeSet == other._barCodeSet
                && string.Equals(
                    _typefulLine,
                    other._typefulLine,
                    StringComparison.OrdinalIgnoreCase
                )
                && _typefulLineSet == other._typefulLineSet
                && string.Equals(_ourNumber, other._ourNumber, StringComparison.OrdinalIgnoreCase)
                && _ourNumberSet == other._ourNumberSet
                && _codeResultCenter == other._codeResultCenter
                && _codeResultCenterSet == other._codeResultCenterSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is Financial financial && Equals(financial));
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
            hashCode = (hashCode * 397) ^ _singleNumberInvoice;
            hashCode = (hashCode * 397) ^ _singleNumberInvoiceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _invoiceNumber;
            hashCode = (hashCode * 397) ^ _invoiceNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateLow.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateLowSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _barCode != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_barCode)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _barCodeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _typefulLine != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_typefulLine)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _typefulLineSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _ourNumber != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_ourNumber)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _ourNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeResultCenter;
            hashCode = (hashCode * 397) ^ _codeResultCenterSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(Financial left, Financial right) => Equals(left, right);

    public static bool operator !=(Financial left, Financial right) => !Equals(left, right);

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _singleNumberInvoice;

    private bool _singleNumberInvoiceSet;

    private int _invoiceNumber;

    private bool _invoiceNumberSet;

    private DateTime? _dateLow;

    private bool _dateLowSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    private string _barCode;

    private bool _barCodeSet;

    private string _typefulLine;

    private bool _typefulLineSet;

    private string _ourNumber;

    private bool _ourNumberSet;

    private int _codeResultCenter;

    private bool _codeResultCenterSet;

    [EntityElement("NUFIN")]
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

    [EntityElement("NUNOTA")]
    public int SingleNumberInvoice
    {
        get => _singleNumberInvoice;
        set
        {
            _singleNumberInvoice = value;
            _singleNumberInvoiceSet = true;
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
    public DateTime? DateLow
    {
        get => _dateLow;
        set
        {
            _dateLow = value;
            _dateLowSet = true;
        }
    }

    [EntityElement("DHBAIXA")]
    public string DateLowInternal
    {
        get => _dateLow?.ToString(@"dd/MM/yyyy HH:mm:ss") ?? string.Empty;
        set
        {
            _dateLowSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var culture = new CultureInfo("pt-BR");
            if (value.TryToDateTime(out var date))
            {
                _dateLow = date;
            }
            else if (
                DateTime.TryParseExact(
                    value,
                    @"dd/MM/yyyy HH:mm:ss",
                    culture,
                    DateTimeStyles.None,
                    out date
                )
            )
            {
                _dateLow = date;
            }
            else if (
                DateTime.TryParseExact(value, @"dd/MM/yyyy", culture, DateTimeStyles.None, out date)
            )
            {
                _dateLow = date;
            }
            else
            {
                throw new InvalidOperationException($@"Invalid date format for value {value}");
            }
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

    [EntityElement("CODIGOBARRA")]
    public string BarCode
    {
        get => _barCode;
        set
        {
            _barCode = value;
            _barCodeSet = true;
        }
    }

    [EntityElement("LINHADIGITAVEL")]
    public string TypefulLine
    {
        get => _typefulLine;
        set
        {
            _typefulLine = value;
            _typefulLineSet = true;
        }
    }

    [EntityElement("NOSSONUM")]
    public string OurNumber
    {
        get => _ourNumber;
        set
        {
            _ourNumber = value;
            _ourNumberSet = true;
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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberInvoice() => _singleNumberInvoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateLow() => _dateLowSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBarCode() => _barCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTypefulLine() => _typefulLineSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOurNumber() => _ourNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;
}
