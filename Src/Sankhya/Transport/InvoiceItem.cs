using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Helpers;

namespace Sankhya.Transport;

[Entity("ItemNota")]
[Serializer]
public class InvoiceItem : GenericServiceEntity, IEquatable<InvoiceItem>
{
    public bool Equals(InvoiceItem other)
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
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeSourceLocal == other._codeSourceLocal
                && _codeSourceLocalSet == other._codeSourceLocalSet
                && _quantityTraded == other._quantityTraded
                && _quantityTradedSet == other._quantityTradedSet
                && string.Equals(_control, other._control, StringComparison.OrdinalIgnoreCase)
                && _controlSet == other._controlSet
                && _valueUnit == other._valueUnit
                && _valueUnitSet == other._valueUnitSet
                && _valueTotal == other._valueTotal
                && _valueTotalSet == other._valueTotalSet
                && _productUse == other._productUse
                && _productUseSet == other._productUseSet
                && string.Equals(_gtin, other._gtin, StringComparison.OrdinalIgnoreCase)
                && _gtinSet == other._gtinSet
                && string.Equals(_gtinTax, other._gtinTax, StringComparison.OrdinalIgnoreCase)
                && _gtinTaxSet == other._gtinTaxSet
                && _discountPercentage == other._discountPercentage
                && _discountPercentageSet == other._discountPercentageSet
                && _discountValue == other._discountValue
                && _discountValueSet == other._discountValueSet
                && string.Equals(_codeVolume, other._codeVolume, StringComparison.OrdinalIgnoreCase)
                && _codeVolumeSet == other._codeVolumeSet
                && Equals(_product, other._product)
                && _productSet == other._productSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is InvoiceItem item && Equals(item));
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
            var hashCode = _singleNumber.GetHashCode();
            hashCode = (hashCode * 397) ^ _singleNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _sequence.GetHashCode();
            hashCode = (hashCode * 397) ^ _sequenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSourceLocal;
            hashCode = (hashCode * 397) ^ _codeSourceLocalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantityTraded.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantityTradedSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _control != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_control)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _controlSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _valueUnit.GetHashCode();
            hashCode = (hashCode * 397) ^ _valueUnitSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _valueTotal.GetHashCode();
            hashCode = (hashCode * 397) ^ _valueTotalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_productUse;
            hashCode = (hashCode * 397) ^ _productUseSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _gtin != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_gtin) : 0
                );
            hashCode = (hashCode * 397) ^ _gtinSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _gtinTax != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_gtinTax)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _gtinTaxSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _discountPercentage.GetHashCode();
            hashCode = (hashCode * 397) ^ _discountPercentageSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _discountValue.GetHashCode();
            hashCode = (hashCode * 397) ^ _discountValueSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _codeVolume != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_codeVolume)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _codeVolumeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_product != null ? _product.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _productSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(InvoiceItem left, InvoiceItem right) => Equals(left, right);

    public static bool operator !=(InvoiceItem left, InvoiceItem right) => !Equals(left, right);

    private int? _singleNumber;

    private bool _singleNumberSet;

    private int? _sequence;

    private bool _sequenceSet;

    private int _codeSeller;

    private bool _codeSellerSet;

    private int _codeProduct;

    private bool _codeProductSet;

    private int _codeSourceLocal;

    private bool _codeSourceLocalSet;

    private int _operationsAndBenefitsFiscalCode;

    private bool _operationsAndBenefitsFiscalCodeSet;

    private decimal _quantityTraded;

    private bool _quantityTradedSet;

    private string _control;

    private bool _controlSet;

    private decimal _valueUnit;

    private bool _valueUnitSet;

    private decimal _valueTotal;

    private bool _valueTotalSet;

    private ProductUse _productUse;

    private bool _productUseSet;

    private string _gtin;

    private bool _gtinSet;

    private string _gtinTax;

    private bool _gtinTaxSet;

    private decimal _discountPercentage;

    private bool _discountPercentageSet;

    private decimal _discountValue;

    private bool _discountValueSet;

    private string _codeVolume;

    private bool _codeVolumeSet;

    private Product _product;

    private bool _productSet;

    [EntityElement("NUNOTA")]
    [EntityKey]
    public int? SingleNumber
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
    public int? Sequence
    {
        get => _sequence;
        set
        {
            _sequence = value;
            _sequenceSet = true;
        }
    }

    [EntityElement("CODVEND")]
    public int CodeSeller
    {
        get => _codeSeller;
        set
        {
            _codeSeller = value;
            _codeSellerSet = true;
        }
    }

    [EntityElement("CODPROD")]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    [EntityElement("CODLOCALORIG")]
    public int CodeSourceLocal
    {
        get => _codeSourceLocal;
        set
        {
            _codeSourceLocal = value;
            _codeSourceLocalSet = true;
        }
    }

    [EntityElement("CODCFO")]
    public int OperationsAndBenefitsFiscalCode
    {
        get => _operationsAndBenefitsFiscalCode;
        set
        {
            _operationsAndBenefitsFiscalCode = value;
            _operationsAndBenefitsFiscalCodeSet = true;
        }
    }

    [EntityElement("QTDNEG")]
    public decimal QuantityTraded
    {
        get => _quantityTraded;
        set
        {
            _quantityTraded = value;
            _quantityTradedSet = true;
        }
    }

    [EntityElement("CONTROLE")]
    public string Control
    {
        get => _control;
        set
        {
            _control = value;
            _controlSet = true;
        }
    }

    [EntityElement("VLRUNIT")]
    public decimal ValueUnit
    {
        get => _valueUnit;
        set
        {
            _valueUnit = value;
            _valueUnitSet = true;
        }
    }

    [EntityElement("VLRTOT")]
    public decimal ValueTotal
    {
        get => _valueTotal;
        set
        {
            _valueTotal = value;
            _valueTotalSet = true;
        }
    }

    [EntityIgnore]
    public ProductUse ProductUse
    {
        get => _productUse;
        set
        {
            _productUse = value;
            _productUseSet = true;
        }
    }

    [EntityElement("USOPROD")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ProductUseInternal
    {
        get => _productUse.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _productUse = EnumExtensions.GetEnumByInternalValueAttribute<ProductUse>(value);
            _productUseSet = true;
        }
    }

    [EntityElement("GTINNFE")]
    public string Gtin
    {
        get => _gtin;
        set
        {
            _gtin = value;
            _gtinSet = true;
        }
    }

    [EntityElement("GTINTRIBNFE")]
    public string GtinTax
    {
        get => _gtinTax;
        set
        {
            _gtinTax = value;
            _gtinTaxSet = true;
        }
    }

    [EntityElement("PERCDESC")]
    public decimal DiscountPercentage
    {
        get => _discountPercentage;
        set
        {
            _discountPercentage = value;
            _discountPercentageSet = true;
        }
    }

    [EntityElement("VLRDESC")]
    public decimal DiscountValue
    {
        get => _discountValue;
        set
        {
            _discountValue = value;
            _discountValueSet = true;
        }
    }

    [EntityElement("CODVOL")]
    [Localizable(false)]
    public string CodeVolume
    {
        get => _codeVolume;
        set
        {
            _codeVolume = value;
            _codeVolumeSet = true;
        }
    }

    [EntityReference]
    public Product Product
    {
        get => _product;
        set
        {
            _product = value;
            _productSet = true;
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
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSourceLocal() => _codeSourceLocalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationsAndBenefitsFiscalCode() =>
        _operationsAndBenefitsFiscalCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantityTraded() => _quantityTradedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeControl() => _controlSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueUnit() => _valueUnitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueTotal() => _valueTotalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductUse() => _productUseSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGtin() => _gtinSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGtinTax() => _gtinTaxSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDiscountPercentage() => _discountPercentageSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDiscountValue() => _discountValueSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProduct() => _productSet;
}
