using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("VendaCasada")]
public class ProductSuggestedSale : IEntity, IEquatable<ProductSuggestedSale>
{
    public bool Equals(ProductSuggestedSale other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _codeSource == other._codeSource
                && _codeSourceSet == other._codeSourceSet
                && _codeSuggestion == other._codeSuggestion
                && _codeSuggestionSet == other._codeSuggestionSet
                && _sourceType == other._sourceType
                && _sourceTypeSet == other._sourceTypeSet
                && _quantity == other._quantity
                && _quantitySet == other._quantitySet
                && _isQuantityMultiplier == other._isQuantityMultiplier
                && _isQuantityMultiplierSet == other._isQuantityMultiplierSet
                && Equals(_productSuggestion, other._productSuggestion)
                && _productSuggestionSet == other._productSuggestionSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is ProductSuggestedSale sale && Equals(sale));
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
            var hashCode = _codeSource;
            hashCode = (hashCode * 397) ^ _codeSourceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSuggestion;
            hashCode = (hashCode * 397) ^ _codeSuggestionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_sourceType;
            hashCode = (hashCode * 397) ^ _sourceTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isQuantityMultiplier.GetHashCode();
            hashCode = (hashCode * 397) ^ _isQuantityMultiplierSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_productSuggestion != null ? _productSuggestion.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _productSuggestionSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(ProductSuggestedSale left, ProductSuggestedSale right) =>
        Equals(left, right);

    public static bool operator !=(ProductSuggestedSale left, ProductSuggestedSale right) =>
        !Equals(left, right);

    private int _codeSource;

    private bool _codeSourceSet;

    private int _codeSuggestion;

    private bool _codeSuggestionSet;

    private ProductSourceType _sourceType;

    private bool _sourceTypeSet;

    private decimal _quantity;

    private bool _quantitySet;

    private bool _isQuantityMultiplier;

    private bool _isQuantityMultiplierSet;

    private Product _productSuggestion;

    private bool _productSuggestionSet;

    [EntityElement("CODORIG")]
    [EntityKey]
    public int CodeSource
    {
        get => _codeSource;
        set
        {
            _codeSource = value;
            _codeSourceSet = true;
        }
    }

    [EntityElement("CODPRODSUG")]
    [EntityKey]
    public int CodeSuggestion
    {
        get => _codeSuggestion;
        set
        {
            _codeSuggestion = value;
            _codeSuggestionSet = true;
        }
    }

    [EntityIgnore]
    public ProductSourceType SourceType
    {
        get => _sourceType;
        set
        {
            _sourceType = value;
            _sourceTypeSet = true;
        }
    }

    [EntityElement("TIPORIG")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SourceTypeInternal
    {
        get => _sourceType.GetInternalValue();
        set
        {
            _sourceType = EnumExtensions.GetEnumByInternalValueAttribute<ProductSourceType>(value);
            _sourceTypeSet = true;
        }
    }

    [EntityElement("QTDSUGERIDA")]
    public decimal Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            _quantitySet = true;
        }
    }

    [EntityIgnore]
    public bool IsQuantityMultiplier
    {
        get => _isQuantityMultiplier;
        set
        {
            _isQuantityMultiplier = value;
            _isQuantityMultiplierSet = true;
        }
    }

    [EntityElement("MULTQTD")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsQuantityMultiplierInternal
    {
        get => _isQuantityMultiplier.ToString(@"S", @"N");
        set
        {
            _isQuantityMultiplier = value.ToBoolean();
            _isQuantityMultiplierSet = true;
        }
    }

    [EntityReference]
    public Product ProductSuggestion
    {
        get => _productSuggestion;
        set
        {
            _productSuggestion = value;
            _productSuggestionSet = true;
        }
    }

    public bool ShouldSerializeCodeSource() => _codeSourceSet;

    public bool ShouldSerializeCodeSuggestion() => _codeSuggestionSet;

    public bool ShouldSerializeSourceType() => _sourceTypeSet;

    public bool ShouldSerializeQuantity() => _quantitySet;

    public bool ShouldSerializeIsQuantityMultiplier() => _isQuantityMultiplierSet;

    public bool ShouldSerializeProductSuggestion() => _productSuggestionSet;
}
