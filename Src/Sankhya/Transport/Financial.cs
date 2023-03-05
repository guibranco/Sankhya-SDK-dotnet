namespace Sankhya.Transport;

using System;
using System.ComponentModel;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

/// <summary>
/// Class Financial. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Financeiro")]
public class Financial : IEntity, IEquatable<Financial>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(Financial other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other) || _singleNumber == other._singleNumber && _singleNumberSet == other._singleNumberSet &&
            _singleNumberInvoice == other._singleNumberInvoice &&
            _singleNumberInvoiceSet == other._singleNumberInvoiceSet &&
            _invoiceNumber == other._invoiceNumber && _invoiceNumberSet == other._invoiceNumberSet &&
            _dateLow.Equals(other._dateLow) && _dateLowSet == other._dateLowSet &&
            _dateChanged.Equals(other._dateChanged) && _dateChangedSet == other._dateChangedSet &&
            string.Equals(_barCode, other._barCode, StringComparison.InvariantCultureIgnoreCase) &&
            _barCodeSet == other._barCodeSet &&
            string.Equals(_typefulLine, other._typefulLine, StringComparison.InvariantCultureIgnoreCase) &&
            _typefulLineSet == other._typefulLineSet &&
            string.Equals(_ourNumber, other._ourNumber, StringComparison.InvariantCultureIgnoreCase) &&
            _ourNumberSet == other._ourNumberSet && _codeResultCenter == other._codeResultCenter &&
            _codeResultCenterSet == other._codeResultCenterSet;
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

        return ReferenceEquals(this, obj) || obj is Financial financial && Equals(financial);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
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
            hashCode = (hashCode * 397) ^ (_barCode != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_barCode) : 0);
            hashCode = (hashCode * 397) ^ _barCodeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_typefulLine != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_typefulLine) : 0);
            hashCode = (hashCode * 397) ^ _typefulLineSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_ourNumber != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_ourNumber) : 0);
            hashCode = (hashCode * 397) ^ _ourNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeResultCenter;
            hashCode = (hashCode * 397) ^ _codeResultCenterSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Financial left, Financial right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Financial left, Financial right) => !Equals(left, right);

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
    /// The single number invoice
    /// </summary>
    private int _singleNumberInvoice;
    /// <summary>
    /// The single number invoice set
    /// </summary>
    private bool _singleNumberInvoiceSet;

    /// <summary>
    /// The invoice number
    /// </summary>
    private int _invoiceNumber;
    /// <summary>
    /// The invoice number set
    /// </summary>
    private bool _invoiceNumberSet;

    /// <summary>
    /// The date low
    /// </summary>
    private DateTime? _dateLow;
    /// <summary>
    /// The date low set
    /// </summary>
    private bool _dateLowSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;
    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The bar code
    /// </summary>
    private string _barCode;
    /// <summary>
    /// The bar code set
    /// </summary>
    private bool _barCodeSet;

    /// <summary>
    /// The typeful line
    /// </summary>
    private string _typefulLine;
    /// <summary>
    /// The typeful line set
    /// </summary>
    private bool _typefulLineSet;

    /// <summary>
    /// Our number
    /// </summary>
    private string _ourNumber;
    /// <summary>
    /// Our number set
    /// </summary>
    private bool _ourNumberSet;

    /// <summary>
    /// The code result center
    /// </summary>
    private int _codeResultCenter;
    /// <summary>
    /// The code result center set
    /// </summary>
    private bool _codeResultCenterSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
    [EntityElement("NUFIN")]
    [EntityKey]
    public int SingleNumber
    {
        get => _singleNumber; set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the single number invoice.
    /// </summary>
    /// <value>The single number invoice.</value>
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
    /// Gets or sets the date low.
    /// </summary>
    /// <value>The date low.</value>
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

    /// <summary>
    /// Gets or sets the date low internal.
    /// </summary>
    /// <value>The date low internal.</value>
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
            else if (DateTime.TryParseExact(value, @"dd/MM/yyyy HH:mm:ss", culture, DateTimeStyles.None, out date))
            {
                _dateLow = date;
            }
            else if (DateTime.TryParseExact(value, @"dd/MM/yyyy", culture,
                         DateTimeStyles.None, out date))
            {
                _dateLow = date;
            }
            else
            {
                throw new InvalidOperationException($@"Invalid date format for value {value}");
            }
        }
    }

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
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

    /// <summary>
    /// Gets or sets the bar code.
    /// </summary>
    /// <value>The bar code.</value>
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

    /// <summary>
    /// Gets or sets the typeful line.
    /// </summary>
    /// <value>The typeful line.</value>
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

    /// <summary>
    /// Gets or sets our number.
    /// </summary>
    /// <value>Our number.</value>
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

    /// <summary>
    /// Gets or sets the code result center.
    /// </summary>
    /// <value>The code result center.</value>
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
    /// Should the serialize single number invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumberInvoice() => _singleNumberInvoiceSet;

    /// <summary>
    /// Should the serialize invoice number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoiceNumber() => _invoiceNumberSet;

    /// <summary>
    /// Should the serialize date low.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateLow() => _dateLowSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Should the serialize bar code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBarCode() => _barCodeSet;

    /// <summary>
    /// Should the serialize typeful line.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTypefulLine() => _typefulLineSet;

    /// <summary>
    /// Should the serialize our number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOurNumber() => _ourNumberSet;

    /// <summary>
    /// Should the serialize code result center.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeResultCenter() => _codeResultCenterSet;

    #endregion

}