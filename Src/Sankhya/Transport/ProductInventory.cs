using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Class ProductInventory. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Estoque")]
[Serializer]
public class ProductInventory : IEntity, IEquatable<ProductInventory>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(ProductInventory other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeCompany == other._codeCompany
                && _codeCompanySet == other._codeCompanySet
                && _codeLocal == other._codeLocal
                && _codeLocalSet == other._codeLocalSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && string.Equals(
                    _control,
                    other._control,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _controlSet == other._controlSet
                && _quantity == other._quantity
                && _quantitySet == other._quantitySet
                && _reserved == other._reserved
                && _reservedSet == other._reservedSet
                && _minAllowedQuantity == other._minAllowedQuantity
                && _minAllowedQuantitySet == other._minAllowedQuantitySet
                && _maxAllowedQuantity == other._maxAllowedQuantity
                && _maxAllowedQuantitySet == other._maxAllowedQuantitySet
                && _type == other._type
                && _typeSet == other._typeSet
                && Equals(_product, other._product)
                && _productSet == other._productSet
                && Equals(_partner, other._partner)
                && _partnerSet == other._partnerSet;
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

        var a = obj as ProductInventory;
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
            var hashCode = _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCompany;
            hashCode = (hashCode * 397) ^ _codeCompanySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeLocal;
            hashCode = (hashCode * 397) ^ _codeLocalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _control != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_control)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _controlSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _reserved.GetHashCode();
            hashCode = (hashCode * 397) ^ _reservedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _minAllowedQuantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _minAllowedQuantitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _maxAllowedQuantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _maxAllowedQuantitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_type;
            hashCode = (hashCode * 397) ^ _typeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_product != null ? _product.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _productSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_partner != null ? _partner.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ProductInventory left, ProductInventory right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ProductInventory left, ProductInventory right) =>
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
    /// The code company
    /// </summary>
    private int _codeCompany;

    /// <summary>
    /// The code company set
    /// </summary>
    private bool _codeCompanySet;

    /// <summary>
    /// The code local
    /// </summary>
    private int _codeLocal;

    /// <summary>
    /// The code local set
    /// </summary>
    private bool _codeLocalSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The control
    /// </summary>
    private string _control;

    /// <summary>
    /// The control set
    /// </summary>
    private bool _controlSet;

    /// <summary>
    /// The quantity
    /// </summary>
    private decimal _quantity;

    /// <summary>
    /// The quantity set
    /// </summary>
    private bool _quantitySet;

    /// <summary>
    /// The reserved
    /// </summary>
    private decimal _reserved;

    /// <summary>
    /// The reserved set
    /// </summary>
    private bool _reservedSet;

    /// <summary>
    /// The minimum allowed quantity
    /// </summary>
    private decimal _minAllowedQuantity;

    /// <summary>
    /// The minimum allowed quantity set
    /// </summary>
    private bool _minAllowedQuantitySet;

    /// <summary>
    /// The maximum allowed quantity
    /// </summary>
    private decimal _maxAllowedQuantity;

    /// <summary>
    /// The maximum allowed quantity set
    /// </summary>
    private bool _maxAllowedQuantitySet;

    /// <summary>
    /// The type
    /// </summary>
    private InventoryType _type;

    /// <summary>
    /// The type set
    /// </summary>
    private bool _typeSet;

    /// <summary>
    /// The product
    /// </summary>
    private Product _product;

    /// <summary>
    /// The product set
    /// </summary>
    private bool _productSet;

    /// <summary>
    /// The partner
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// The partner set
    /// </summary>
    private bool _partnerSet;

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
    [EntityKey]
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
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [EntityElement("CODPARC")]
    public int CodePartner
    {
        get => _codePartner;
        set
        {
            _codePartner = value;
            _codePartnerSet = true;
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
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>The quantity.</value>
    [EntityElement("ESTOQUE")]
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
    /// Gets or sets the reserved.
    /// </summary>
    /// <value>The reserved.</value>
    [EntityElement("RESERVADO")]
    public decimal Reserved
    {
        get => _reserved;
        set
        {
            _reserved = value;
            _reservedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the minimum allowed quantity.
    /// </summary>
    /// <value>The minimum allowed quantity.</value>
    [EntityElement("ESTMIN")]
    public decimal MinAllowedQuantity
    {
        get => _minAllowedQuantity;
        set
        {
            _minAllowedQuantity = value;
            _minAllowedQuantitySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the maximum allowed quantity.
    /// </summary>
    /// <value>The maximum allowed quantity.</value>
    [EntityElement("ESTMAX")]
    public decimal MaxAllowedQuantity
    {
        get => _maxAllowedQuantity;
        set
        {
            _maxAllowedQuantity = value;
            _maxAllowedQuantitySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [EntityIgnore]
    public InventoryType Type
    {
        get => _type;
        set
        {
            _type = value;
            _typeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type internal.
    /// </summary>
    /// <value>The type internal.</value>
    [EntityElement("TIPO")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue();
        set
        {
            _type = EnumExtensions.GetEnumByInternalValueAttribute<InventoryType>(value);
            _typeSet = true;
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
    /// Gets or sets the partner.
    /// </summary>
    /// <value>The partner.</value>
    [EntityReference]
    public Partner Partner
    {
        get => _partner;
        set
        {
            _partner = value;
            _partnerSet = true;
        }
    }

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize code company.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    /// <summary>
    /// Should the serialize code local.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeLocal() => _codeLocalSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize control.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeControl() => _controlSet;

    /// <summary>
    /// Should the serialize quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantity() => _quantitySet;

    /// <summary>
    /// Should the serialize reserved.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReserved() => _reservedSet;

    /// <summary>
    /// Should the serialize minimum allowed quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMinAllowedQuantity() => _minAllowedQuantitySet;

    /// <summary>
    /// Should the serialize maximum allowed quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMaxAllowedQuantity() => _maxAllowedQuantitySet;

    /// <summary>
    /// Should the type of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    /// <summary>
    /// Should the serialize product.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProduct() => _productSet;

    /// <summary>
    /// Should the serialize partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;
}
