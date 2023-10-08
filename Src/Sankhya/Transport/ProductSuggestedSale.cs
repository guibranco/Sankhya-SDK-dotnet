using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Class ProductSuggestedSale. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("VendaCasada")]
public class ProductSuggestedSale : IEntity, IEquatable<ProductSuggestedSale>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(ProductSuggestedSale other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _codeSource == other._codeSource
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
                && _productSuggestionSet == other._productSuggestionSet;
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

        return ReferenceEquals(this, obj) || obj is ProductSuggestedSale sale && Equals(sale);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ProductSuggestedSale left, ProductSuggestedSale right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ProductSuggestedSale left, ProductSuggestedSale right) =>
        !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The code source
    /// </summary>
    private int _codeSource;

    /// <summary>
    /// The code source set
    /// </summary>
    private bool _codeSourceSet;

    /// <summary>
    /// The code suggestion
    /// </summary>
    private int _codeSuggestion;

    /// <summary>
    /// The code suggestion set
    /// </summary>
    private bool _codeSuggestionSet;

    /// <summary>
    /// The source type
    /// </summary>
    private ProductSourceType _sourceType;

    /// <summary>
    /// The source type set
    /// </summary>
    private bool _sourceTypeSet;

    /// <summary>
    /// The quantity
    /// </summary>
    private decimal _quantity;

    /// <summary>
    /// The quantity set
    /// </summary>
    private bool _quantitySet;

    /// <summary>
    /// The is quantity multiplier
    /// </summary>
    private bool _isQuantityMultiplier;

    /// <summary>
    /// The is quantity multiplier set
    /// </summary>
    private bool _isQuantityMultiplierSet;

    /// <summary>
    /// The product suggestion
    /// </summary>
    private Product _productSuggestion;

    /// <summary>
    /// The product suggestion set
    /// </summary>
    private bool _productSuggestionSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code source.
    /// </summary>
    /// <value>The code source.</value>
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

    /// <summary>
    /// Gets or sets the code suggestion.
    /// </summary>
    /// <value>The code suggestion.</value>
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

    /// <summary>
    /// Gets or sets the type of the source.
    /// </summary>
    /// <value>The type of the source.</value>
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

    /// <summary>
    /// Gets or sets the source type internal.
    /// </summary>
    /// <value>The source type internal.</value>
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

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>The quantity.</value>
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

    /// <summary>
    /// Gets or sets the is quantity multiplier.
    /// </summary>
    /// <value>The is quantity multiplier.</value>
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

    /// <summary>
    /// Gets or sets the is quantity multiplier internal.
    /// </summary>
    /// <value>The is quantity multiplier internal.</value>
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

    /// <summary>
    /// Gets or sets the product suggestion.
    /// </summary>
    /// <value>The product suggestion.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code source.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeSource() => _codeSourceSet;

    /// <summary>
    /// Should the serialize code suggestion.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeSuggestion() => _codeSuggestionSet;

    /// <summary>
    /// Should the type of the serialize source.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeSourceType() => _sourceTypeSet;

    /// <summary>
    /// Should the serialize quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeQuantity() => _quantitySet;

    /// <summary>
    /// Should the serialize is quantity multiplier.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeIsQuantityMultiplier() => _isQuantityMultiplierSet;

    /// <summary>
    /// Should the serialize product suggestion.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeProductSuggestion() => _productSuggestionSet;

    #endregion
}
