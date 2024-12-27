using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("Estoque")]
[Serializer]
public class ProductInventory : IEntity, IEquatable<ProductInventory>
{
    public bool Equals(ProductInventory other)
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
                && _codeLocal == other._codeLocal
                && _codeLocalSet == other._codeLocalSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && string.Equals(_control, other._control, StringComparison.OrdinalIgnoreCase)
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
                && _partnerSet == other._partnerSet
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

        var a = obj as ProductInventory;
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

    public static bool operator ==(ProductInventory left, ProductInventory right) =>
        Equals(left, right);

    public static bool operator !=(ProductInventory left, ProductInventory right) =>
        !Equals(left, right);

    private int _codeProduct;

    private bool _codeProductSet;

    private int _codeCompany;

    private bool _codeCompanySet;

    private int _codeLocal;

    private bool _codeLocalSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private string _control;

    private bool _controlSet;

    private decimal _quantity;

    private bool _quantitySet;

    private decimal _reserved;

    private bool _reservedSet;

    private decimal _minAllowedQuantity;

    private bool _minAllowedQuantitySet;

    private decimal _maxAllowedQuantity;

    private bool _maxAllowedQuantitySet;

    private InventoryType _type;

    private bool _typeSet;

    private Product _product;

    private bool _productSet;

    private Partner _partner;

    private bool _partnerSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCompany() => _codeCompanySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeLocal() => _codeLocalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeControl() => _controlSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantity() => _quantitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReserved() => _reservedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMinAllowedQuantity() => _minAllowedQuantitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMaxAllowedQuantity() => _maxAllowedQuantitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProduct() => _productSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;
}
