using System;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class ProductCost. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Custo")]
public class ProductCost : IEntity, IEquatable<ProductCost>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(ProductCost other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeCompany == other._codeCompany
                && _codeCompanySet == other._codeCompanySet
                && _date.Equals(other._date)
                && _dateSet == other._dateSet
                && _codeLocal == other._codeLocal
                && _codeLocalSet == other._codeLocalSet
                && string.Equals(_control, other._control, StringComparison.OrdinalIgnoreCase)
                && _controlSet == other._controlSet
                && _singleNumber == other._singleNumber
                && _singleNumberSet == other._singleNumberSet
                && _sequence == other._sequence
                && _sequenceSet == other._sequenceSet
                && _costReplacement == other._costReplacement
                && _costReplacementSet == other._costReplacementSet
            );
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

        return ReferenceEquals(this, obj) || (obj is ProductCost cost && Equals(cost));
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
            var hashCode = _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCompany;
            hashCode = (hashCode * 397) ^ _codeCompanySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _date.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeLocal;
            hashCode = (hashCode * 397) ^ _codeLocalSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _control != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_control)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _controlSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _singleNumber;
            hashCode = (hashCode * 397) ^ _singleNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _sequence;
            hashCode = (hashCode * 397) ^ _sequenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _costReplacement.GetHashCode();
            hashCode = (hashCode * 397) ^ _costReplacementSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ProductCost left, ProductCost right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ProductCost left, ProductCost right) => !Equals(left, right);

    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The code company
    /// </summary>
    private int _codeCompany;

    /// <summary>
    /// The code company set
    /// </summary>
    private bool _codeCompanySet;

    /// <summary>
    /// The date
    /// </summary>
    private DateTime _date;

    /// <summary>
    /// The date set
    /// </summary>
    private bool _dateSet;

    /// <summary>
    /// The code local
    /// </summary>
    private int _codeLocal;

    /// <summary>
    /// The code local set
    /// </summary>
    private bool _codeLocalSet;

    /// <summary>
    /// The control
    /// </summary>
    private string _control;

    /// <summary>
    /// The control set
    /// </summary>
    private bool _controlSet;

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
    /// The cost replacement
    /// </summary>
    private decimal _costReplacement;

    /// <summary>
    /// The cost replacement set
    /// </summary>
    private bool _costReplacementSet;

    /// <summary>
    /// Gets or sets the code product.
    /// </summary>
    /// <value>The code product.</value>
    [EntityElement("CODPROD")]
    [EntityKey]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code company.
    /// </summary>
    /// <value>The code company.</value>
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

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    [EntityElement("DTATUAL")]
    [EntityKey]
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            _dateSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code local.
    /// </summary>
    /// <value>The code local.</value>
    [EntityElement("CODLOCAL")]
    [EntityKey]
    public int CodeLocal
    {
        get => _codeLocal;
        set
        {
            _codeLocal = value;
            _codeLocalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the control.
    /// </summary>
    /// <value>The control.</value>
    [EntityElement("CONTROLE")]
    [EntityKey]
    public string Control
    {
        get => _control;
        set
        {
            _control = value;
            _controlSet = true;
        }
    }

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
    /// Gets or sets the cost replacement.
    /// </summary>
    /// <value>The cost replacement.</value>
    [EntityElement("CUSREP")]
    public decimal CostReplacement
    {
        get => _costReplacement;
        set
        {
            _costReplacement = value;
            _costReplacementSet = true;
        }
    }

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize code company.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    /// <summary>
    /// Should the serialize date.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeDate() => _dateSet;

    /// <summary>
    /// Should the serialize code local.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeLocal() => _codeLocalSet;

    /// <summary>
    /// Should the serialize control.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeControl() => _controlSet;

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize sequence.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeSequence() => _sequenceSet;

    /// <summary>
    /// Should the serialize cost replacement.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCostReplacement() => _costReplacementSet;
}
