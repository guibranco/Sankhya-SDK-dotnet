using System;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("ItemComposicaoProduto")]
public class ItemMakeupProduct : IEntity, IEquatable<ItemMakeupProduct>
{
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

    public static bool operator ==(ItemMakeupProduct left, ItemMakeupProduct right) =>
        Equals(left, right);

    public static bool operator !=(ItemMakeupProduct left, ItemMakeupProduct right) =>
        !Equals(left, right);

    private int _codeProduct;

    private bool _codeProductSet;

    private int _codeFeedStock;

    private bool _codeFeedStockSet;

    private decimal _feedStockQuantity;

    private bool _feedStockQuantitySet;

    private string _volume;

    private bool _volumeSet;

    private int _sequence;

    private bool _sequenceSet;

    private string _observation;

    private bool _observationSet;

    private Product _product;

    private bool _productSet;

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

    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    public bool ShouldSerializeCodeFeedStock() => _codeFeedStockSet;

    public bool ShouldSerializeFeedStockQuantity() => _feedStockQuantitySet;

    public bool ShouldSerializeVolume() => _volumeSet;

    public bool ShouldSerializeSequence() => _sequenceSet;

    public bool ShouldSerializeObservation() => _observationSet;

    public bool ShouldSerializeProduct() => _productSet;
}
