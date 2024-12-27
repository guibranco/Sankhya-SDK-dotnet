using System;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("Custo")]
public class ProductCost : IEntity, IEquatable<ProductCost>
{
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

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is ProductCost cost && Equals(cost));
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

    public static bool operator ==(ProductCost left, ProductCost right) => Equals(left, right);

    public static bool operator !=(ProductCost left, ProductCost right) => !Equals(left, right);

    private int _codeProduct;

    private bool _codeProductSet;

    private int _codeCompany;

    private bool _codeCompanySet;

    private DateTime _date;

    private bool _dateSet;

    private int _codeLocal;

    private bool _codeLocalSet;

    private string _control;

    private bool _controlSet;

    private int _singleNumber;

    private bool _singleNumberSet;

    private int _sequence;

    private bool _sequenceSet;

    private decimal _costReplacement;

    private bool _costReplacementSet;

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

    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    public bool ShouldSerializeDate() => _dateSet;

    public bool ShouldSerializeCodeLocal() => _codeLocalSet;

    public bool ShouldSerializeControl() => _controlSet;

    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    public bool ShouldSerializeSequence() => _sequenceSet;

    public bool ShouldSerializeCostReplacement() => _costReplacementSet;
}
