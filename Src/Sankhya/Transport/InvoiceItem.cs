using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Helpers;

namespace Sankhya.Transport;

/// <summary>
/// Class InvoiceItem. This class cannot be inherited.
/// </summary>
/// <seealso cref="GenericServiceEntity" />
[Entity("ItemNota")]
[Serializer]
public class InvoiceItem : GenericServiceEntity, IEquatable<InvoiceItem>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(InvoiceItem other)
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
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeSourceLocal == other._codeSourceLocal
                && _codeSourceLocalSet == other._codeSourceLocalSet
                && _quantityTraded == other._quantityTraded
                && _quantityTradedSet == other._quantityTradedSet
                && string.Equals(
                    _control,
                    other._control,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _controlSet == other._controlSet
                && _valueUnit == other._valueUnit
                && _valueUnitSet == other._valueUnitSet
                && _valueTotal == other._valueTotal
                && _valueTotalSet == other._valueTotalSet
                && _productUse == other._productUse
                && _productUseSet == other._productUseSet
                && string.Equals(_gtin, other._gtin, StringComparison.InvariantCultureIgnoreCase)
                && _gtinSet == other._gtinSet
                && string.Equals(
                    _gtinTax,
                    other._gtinTax,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _gtinTaxSet == other._gtinTaxSet
                && _discountPercentage == other._discountPercentage
                && _discountPercentageSet == other._discountPercentageSet
                && _discountValue == other._discountValue
                && _discountValueSet == other._discountValueSet
                && string.Equals(
                    _codeVolume,
                    other._codeVolume,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _codeVolumeSet == other._codeVolumeSet
                && Equals(_product, other._product)
                && _productSet == other._productSet;
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

        return ReferenceEquals(this, obj) || obj is InvoiceItem item && Equals(item);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    // ReSharper disable once MethodTooLong
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(InvoiceItem left, InvoiceItem right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(InvoiceItem left, InvoiceItem right) => !Equals(left, right);

    /// <summary>
    /// The single number
    /// </summary>
    private int? _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The sequence
    /// </summary>
    private int? _sequence;

    /// <summary>
    /// The sequence set
    /// </summary>
    private bool _sequenceSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;

    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The code source local
    /// </summary>
    private int _codeSourceLocal;

    /// <summary>
    /// The code source local set
    /// </summary>
    private bool _codeSourceLocalSet;

    /// <summary>
    /// The operations and benefits fiscal code
    /// </summary>
    private int _operationsAndBenefitsFiscalCode;

    /// <summary>
    /// The operations and benefits fiscal code set
    /// </summary>
    private bool _operationsAndBenefitsFiscalCodeSet;

    /// <summary>
    /// The quantity traded
    /// </summary>
    private decimal _quantityTraded;

    /// <summary>
    /// The quantity traded set
    /// </summary>
    private bool _quantityTradedSet;

    /// <summary>
    /// The control
    /// </summary>
    private string _control;

    /// <summary>
    /// The control set
    /// </summary>
    private bool _controlSet;

    /// <summary>
    /// The value unit
    /// </summary>
    private decimal _valueUnit;

    /// <summary>
    /// The value unit set
    /// </summary>
    private bool _valueUnitSet;

    /// <summary>
    /// The value total
    /// </summary>
    private decimal _valueTotal;

    /// <summary>
    /// The value total set
    /// </summary>
    private bool _valueTotalSet;

    /// <summary>
    /// The product use
    /// </summary>
    private ProductUse _productUse;

    /// <summary>
    /// The product use set
    /// </summary>
    private bool _productUseSet;

    /// <summary>
    /// The gtin
    /// </summary>
    private string _gtin;

    /// <summary>
    /// The gtin set
    /// </summary>
    private bool _gtinSet;

    /// <summary>
    /// The gtin tax
    /// </summary>
    private string _gtinTax;

    /// <summary>
    /// The gtin tax set
    /// </summary>
    private bool _gtinTaxSet;

    /// <summary>
    /// The discount percentage
    /// </summary>
    private decimal _discountPercentage;

    /// <summary>
    /// The discount percentage set
    /// </summary>
    private bool _discountPercentageSet;

    /// <summary>
    /// The discount value
    /// </summary>
    private decimal _discountValue;

    /// <summary>
    /// The discount value set
    /// </summary>
    private bool _discountValueSet;

    /// <summary>
    /// The code volume
    /// </summary>
    private string _codeVolume;

    /// <summary>
    /// The code volume set
    /// </summary>
    private bool _codeVolumeSet;

    /// <summary>
    /// The product
    /// </summary>
    private Product _product;

    /// <summary>
    /// The product set
    /// </summary>
    private bool _productSet;

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
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

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>The sequence.</value>
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

    /// <summary>
    /// Gets or sets the code seller.
    /// </summary>
    /// <value>The code seller.</value>
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

    /// <summary>
    /// Gets or sets the code product.
    /// </summary>
    /// <value>The code product.</value>
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

    /// <summary>
    /// Gets or sets the code source local.
    /// </summary>
    /// <value>The code source local.</value>
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

    /// <summary>
    /// Gets or sets the operations and benefits fiscal code.
    /// </summary>
    /// <value>
    /// The operations and benefits fiscal code.
    /// </value>
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

    /// <summary>
    /// Gets or sets the quantity traded.
    /// </summary>
    /// <value>The quantity traded.</value>
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

    /// <summary>
    /// Gets or sets the control.
    /// </summary>
    /// <value>The control.</value>
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

    /// <summary>
    /// Gets or sets the value unit.
    /// </summary>
    /// <value>The value unit.</value>
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

    /// <summary>
    /// Gets or sets the value total.
    /// </summary>
    /// <value>The value total.</value>
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

    /// <summary>
    /// Gets or sets the product use.
    /// </summary>
    /// <value>The product use.</value>
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

    /// <summary>
    /// Gets or sets the product use internal.
    /// </summary>
    /// <value>The product use internal.</value>
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

    /// <summary>
    /// Gets or sets the gtin.
    /// </summary>
    /// <value>The gtin.</value>
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

    /// <summary>
    /// Gets or sets the gtin tax.
    /// </summary>
    /// <value>The gtin tax.</value>
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

    /// <summary>
    /// Gets or sets the discount percentage.
    /// </summary>
    /// <value>The discount percentage.</value>
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

    /// <summary>
    /// Gets or sets the discount value.
    /// </summary>
    /// <value>The discount value.</value>
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

    /// <summary>
    /// Gets or sets the code volume.
    /// </summary>
    /// <value>The code volume.</value>
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

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>The product.</value>
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
    /// Should the serialize code seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize code source local.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSourceLocal() => _codeSourceLocalSet;

    /// <summary>
    /// The should serialize operations and benefits fiscal code serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOperationsAndBenefitsFiscalCode() =>
        _operationsAndBenefitsFiscalCodeSet;

    /// <summary>
    /// Should the serialize quantity traded.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantityTraded() => _quantityTradedSet;

    /// <summary>
    /// Should the serialize control.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeControl() => _controlSet;

    /// <summary>
    /// Should the serialize value unit.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueUnit() => _valueUnitSet;

    /// <summary>
    /// Should the serialize value total.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueTotal() => _valueTotalSet;

    /// <summary>
    /// Should the serialize product use.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductUse() => _productUseSet;

    /// <summary>
    /// Should the serialize gtin.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGtin() => _gtinSet;

    /// <summary>
    /// Should the serialize gtin tax.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGtinTax() => _gtinTaxSet;

    /// <summary>
    /// Should the serialize discount percentage.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDiscountPercentage() => _discountPercentageSet;

    /// <summary>
    /// Should the serialize discount value.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDiscountValue() => _discountValueSet;

    /// <summary>
    /// Should the serialize code volume.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    /// <summary>
    /// Should the serialize product.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProduct() => _productSet;
}
