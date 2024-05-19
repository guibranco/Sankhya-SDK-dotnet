using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class ItemMakeupProduct. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("ItemComposicaoProduto")]
public class ItemMakeupProduct : IEntity, IEquatable<ItemMakeupProduct>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(ItemMakeupProduct other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _codeFeedStock == other._codeFeedStock
                && _codeFeedStockSet == other._codeFeedStockSet
                && _feedStockQuantity == other._feedStockQuantity
                && _feedStockQuantitySet == other._feedStockQuantitySet
                && string.Equals(_observation, other._observation)
                && _observationSet == other._observationSet
                && Equals(_product, other._product)
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _productSet == other._productSet
                && _sequence == other._sequence
                && _sequenceSet == other._sequenceSet
                && string.Equals(_volume, other._volume)
                && _volumeSet == other._volumeSet
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

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        var a = obj as ItemMakeupProduct;
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
            var hashCode = _codeFeedStock;
            hashCode = (hashCode * 397) ^ _codeFeedStockSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _feedStockQuantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _feedStockQuantitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_observation?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _observationSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_product != null ? _product.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _productSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _sequence;
            hashCode = (hashCode * 397) ^ _sequenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_volume?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _volumeSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ItemMakeupProduct left, ItemMakeupProduct right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ItemMakeupProduct left, ItemMakeupProduct right) =>
        !Equals(left, right);

    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The code feed stock
    /// </summary>
    private int _codeFeedStock;

    /// <summary>
    /// The code feed stock set
    /// </summary>
    private bool _codeFeedStockSet;

    /// <summary>
    /// The feed stock quantity
    /// </summary>
    private decimal _feedStockQuantity;

    /// <summary>
    /// The feed stock quantity set
    /// </summary>
    private bool _feedStockQuantitySet;

    /// <summary>
    /// The volume
    /// </summary>
    private string _volume;

    /// <summary>
    /// The volume set
    /// </summary>
    private bool _volumeSet;

    /// <summary>
    /// The sequence
    /// </summary>
    private int _sequence;

    /// <summary>
    /// The sequence set
    /// </summary>
    private bool _sequenceSet;

    /// <summary>
    /// The observation
    /// </summary>
    private string _observation;

    /// <summary>
    /// The observation set
    /// </summary>
    private bool _observationSet;

    /// <summary>
    /// The product
    /// </summary>
    private Product _product;

    /// <summary>
    /// The product set
    /// </summary>
    private bool _productSet;

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
    /// Gets or sets the code feed stock.
    /// </summary>
    /// <value>The code feed stock.</value>
    [EntityElement("CODMATPRIMA")]
    public int CodeFeedStock
    {
        get => _codeFeedStock;
        set
        {
            _codeFeedStock = value;
            _codeFeedStockSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the feed stock quantity.
    /// </summary>
    /// <value>The feed stock quantity.</value>
    [EntityElement("QTDMISTURA")]
    public decimal FeedStockQuantity
    {
        get => _feedStockQuantity;
        set
        {
            _feedStockQuantity = value;
            _feedStockQuantitySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the volume.
    /// </summary>
    /// <value>The volume.</value>
    [EntityElement("CODVOL")]
    public string Volume
    {
        get => _volume;
        set
        {
            _volume = value;
            _volumeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>The sequence.</value>
    [EntityElement("SEQUENCIA")]
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
    /// Gets or sets the observation.
    /// </summary>
    /// <value>The observation.</value>
    [EntityElement("OBSERVACAO")]
    public string Observation
    {
        get => _observation;
        set
        {
            _observation = value;
            _observationSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>The product.</value>
    [EntityReference("ProdutoMateriaPrima")]
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
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize code feed stock.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeFeedStock() => _codeFeedStockSet;

    /// <summary>
    /// Should the serialize feed stock quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeFeedStockQuantity() => _feedStockQuantitySet;

    /// <summary>
    /// Should the serialize volume.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeVolume() => _volumeSet;

    /// <summary>
    /// Should the serialize sequence.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeSequence() => _sequenceSet;

    /// <summary>
    /// Should the serialize observation.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeObservation() => _observationSet;

    /// <summary>
    /// Should the serialize product.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeProduct() => _productSet;
}
