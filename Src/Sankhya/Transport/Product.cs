using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.ValueObjects;

namespace Sankhya.Transport;

[Entity("Produto")]
public class Product : IEntity, IEquatable<Product>
{
    public bool Equals(Product other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _isActive == other._isActive
                && _isActiveSet == other._isActiveSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
                && string.Equals(_complement, other._complement, StringComparison.OrdinalIgnoreCase)
                && _complementSet == other._complementSet
                && string.Equals(
                    _description,
                    other._description,
                    StringComparison.OrdinalIgnoreCase
                )
                && _descriptionSet == other._descriptionSet
                && string.Equals(_codeVolume, other._codeVolume, StringComparison.OrdinalIgnoreCase)
                && _codeVolumeSet == other._codeVolumeSet
                && string.Equals(
                    _codeVolumeComponent,
                    other._codeVolumeComponent,
                    StringComparison.OrdinalIgnoreCase
                )
                && _codeVolumeComponentSet == other._codeVolumeComponentSet
                && _codeGroup == other._codeGroup
                && _codeGroupSet == other._codeGroupSet
                && _netWeight == other._netWeight
                && _netWeightSet == other._netWeightSet
                && _grossWeight == other._grossWeight
                && _grossWeightSet == other._grossWeightSet
                && _quantity == other._quantity
                && _quantitySet == other._quantitySet
                && string.Equals(_brand, other._brand, StringComparison.OrdinalIgnoreCase)
                && _brandSet == other._brandSet
                && string.Equals(_reference, other._reference, StringComparison.OrdinalIgnoreCase)
                && _referenceSet == other._referenceSet
                && _width == other._width
                && _widthSet == other._widthSet
                && _height == other._height
                && _heightSet == other._heightSet
                && _length == other._length
                && _lengthSet == other._lengthSet
                && _source == other._source
                && _sourceSet == other._sourceSet
                && _isSaleAllowedOutsideKit == other._isSaleAllowedOutsideKit
                && _isSaleAllowedOutsideKitSet == other._isSaleAllowedOutsideKitSet
                && string.Equals(_ncm, other._ncm, StringComparison.OrdinalIgnoreCase)
                && _ncmSet == other._ncmSet
                && _use == other._use
                && _useSet == other._useSet
                && Equals(_productFather, other._productFather)
                && _productFatherSet == other._productFatherSet
                && Equals(_productReplacement, other._productReplacement)
                && _productReplacementSet == other._productReplacementSet
                && Equals(_cost, other._cost)
                && _costSet == other._costSet
                && Equals(Components, other.Components)
                && Equals(AlternativeImages, other.AlternativeImages)
                && Equals(Suggestions, other.Suggestions)
                && Equals(CodesBars, other.CodesBars)
                && Equals(Image, other.Image)
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((Product)obj));
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
            var hashCode = _code;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActive.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActiveSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _complement != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_complement)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _complementSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _description != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_description)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _descriptionSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _codeVolume != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_codeVolume)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _codeVolumeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _codeVolumeComponent != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _codeVolumeComponent
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _codeVolumeComponentSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeGroup;
            hashCode = (hashCode * 397) ^ _codeGroupSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _netWeight.GetHashCode();
            hashCode = (hashCode * 397) ^ _netWeightSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _grossWeight.GetHashCode();
            hashCode = (hashCode * 397) ^ _grossWeightSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantity.GetHashCode();
            hashCode = (hashCode * 397) ^ _quantitySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _brand != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_brand)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _brandSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _reference != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_reference)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _referenceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _width.GetHashCode();
            hashCode = (hashCode * 397) ^ _widthSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _height.GetHashCode();
            hashCode = (hashCode * 397) ^ _heightSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _length.GetHashCode();
            hashCode = (hashCode * 397) ^ _lengthSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_source;
            hashCode = (hashCode * 397) ^ _sourceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSaleAllowedOutsideKit.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSaleAllowedOutsideKitSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_ncm != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_ncm) : 0);
            hashCode = (hashCode * 397) ^ _ncmSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_use;
            hashCode = (hashCode * 397) ^ _useSet.GetHashCode();
            hashCode =
                (hashCode * 397) ^ (_productFather != null ? _productFather.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _productFatherSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_productReplacement != null ? _productReplacement.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _productReplacementSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_cost != null ? _cost.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _costSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (Components != null ? Components.GetHashCode() : 0);
            hashCode =
                (hashCode * 397)
                ^ (AlternativeImages != null ? AlternativeImages.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Suggestions != null ? Suggestions.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (CodesBars != null ? CodesBars.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Image != null ? Image.GetHashCode() : 0);
            return hashCode;
        }
    }

    public static bool operator ==(Product left, Product right) => Equals(left, right);

    public static bool operator !=(Product left, Product right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private bool _isActive;

    private bool _isActiveSet;

    private string _name;

    private bool _nameSet;

    private string _complement;

    private bool _complementSet;

    private string _description;

    private bool _descriptionSet;

    private string _codeVolume;

    private bool _codeVolumeSet;

    private string _codeVolumeComponent;

    private bool _codeVolumeComponentSet;

    private int _codeGroup;

    private bool _codeGroupSet;

    private decimal _netWeight;

    private bool _netWeightSet;

    private decimal _grossWeight;

    private bool _grossWeightSet;

    private decimal _quantity;

    private bool _quantitySet;

    private string _brand;

    private bool _brandSet;

    private string _reference;

    private bool _referenceSet;

    private decimal _width;

    private bool _widthSet;

    private decimal _height;

    private bool _heightSet;

    private decimal _length;

    private bool _lengthSet;

    private ProductSource _source;

    private bool _sourceSet;

    private bool _isSaleAllowedOutsideKit;

    private bool _isSaleAllowedOutsideKitSet;

    private string _ncm;

    private bool _ncmSet;

    private ProductUse _use;

    private bool _useSet;

    private Product _productFather;

    private bool _productFatherSet;

    private Product _productReplacement;

    private bool _productReplacementSet;

    private ProductCost _cost;

    private bool _costSet;

    [EntityKey]
    [EntityElement("CODPROD")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityIgnore]
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            _isActiveSet = true;
        }
    }

    [EntityElement("ATIVO")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsActiveInternal
    {
        get => _isActive.ToString(@"S", @"N");
        set
        {
            _isActive = value.ToBoolean();
            _isActiveSet = true;
        }
    }

    [EntityElement("DESCRPROD")]
    [Localizable(false)]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [EntityElement("COMPLDESC")]
    [Localizable(false)]
    public string Complement
    {
        get => _complement;
        set
        {
            _complement = value;
            _complementSet = true;
        }
    }

    [EntityElement("CARACTERISTICAS")]
    [Localizable(false)]
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            _descriptionSet = true;
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

    [EntityIgnore]
    public string CodeVolumeComponent
    {
        get => _codeVolumeComponent;
        set
        {
            _codeVolumeComponent = value;
            _codeVolumeComponentSet = true;
        }
    }

    [EntityElement("CODGRUPOPROD")]
    public int CodeGroup
    {
        get => _codeGroup;
        set
        {
            _codeGroup = value;
            _codeGroupSet = true;
        }
    }

    [EntityElement("PESOLIQ")]
    public decimal NetWeight
    {
        get => _netWeight;
        set
        {
            _netWeight = value;
            _netWeightSet = true;
        }
    }

    [EntityElement("PESOBRUTO")]
    public decimal GrossWeight
    {
        get => _grossWeight;
        set
        {
            _grossWeight = value;
            _grossWeightSet = true;
        }
    }

    [EntityIgnore]
    public decimal Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            _quantitySet = true;
        }
    }

    [EntityElement("MARCA")]
    public string Brand
    {
        get => _brand;
        set
        {
            _brand = value;
            _brandSet = true;
        }
    }

    [EntityElement("REFERENCIA")]
    public string Reference
    {
        get => _reference;
        set
        {
            _reference = value;
            _referenceSet = true;
        }
    }

    [EntityIgnore]
    public ProductSource Source
    {
        get => _source;
        set
        {
            _source = value;
            _sourceSet = true;
        }
    }

    [EntityElement("ORIGPROD")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SourceInternal
    {
        get => _source.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _source = EnumExtensions.GetEnumByInternalValueAttribute<ProductSource>(value);
            _sourceSet = true;
        }
    }

    [EntityIgnore]
    public bool IsSaleAllowedOutsideKit
    {
        get => _isSaleAllowedOutsideKit;
        set
        {
            _isSaleAllowedOutsideKit = value;
            _isSaleAllowedOutsideKitSet = true;
        }
    }

    [EntityElement("VENCOMPINDIV")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsSaleAllowedOutsideKitInternal
    {
        get => _isSaleAllowedOutsideKit.ToString();
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _isSaleAllowedOutsideKit = value.ToBoolean(@"S|N");
            }

            _isSaleAllowedOutsideKitSet = true;
        }
    }

    [EntityElement("LARGURA")]
    public decimal Width
    {
        get => _width;
        set
        {
            _width = value;
            _widthSet = true;
        }
    }

    [EntityElement("ALTURA")]
    public decimal Height
    {
        get => _height;
        set
        {
            _height = value;
            _heightSet = true;
        }
    }

    [EntityElement("ESPESSURA")]
    public decimal Length
    {
        get => _length;
        set
        {
            _length = value;
            _lengthSet = true;
        }
    }

    [EntityElement("NCM")]
    public string NCM
    {
        get => _ncm;
        set
        {
            _ncm = value;
            _ncmSet = true;
        }
    }

    [EntityIgnore]
    public ProductUse Use
    {
        get => _use;
        set
        {
            _use = value;
            _useSet = true;
        }
    }

    [EntityElement("USOPROD")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string UseInternal
    {
        get => _use.GetInternalValue();
        set
        {
            _use = EnumExtensions.GetEnumByInternalValueAttribute<ProductUse>(value);
            _useSet = true;
        }
    }

    [EntityReference("Produto_AD001")]
    public Product ProductFather
    {
        get => _productFather;
        set
        {
            _productFather = value;
            _productFatherSet = true;
        }
    }

    [EntityReference("Produto_AD002")]
    public Product ProductReplacement
    {
        get => _productReplacement;
        set
        {
            _productReplacement = value;
            _productReplacementSet = true;
        }
    }

    [EntityIgnore]
    public ProductCost Cost
    {
        get => _cost;
        set
        {
            _cost = value;
            _costSet = true;
        }
    }

    [EntityIgnore]
    public Lazy<ServiceFile> Image { get; set; }

    public readonly List<Product> Components;

    public readonly Collection<Lazy<ServiceFile>> AlternativeImages;

    public readonly List<ProductSuggestedSale> Suggestions;

    public readonly Collection<CodeBars> CodesBars;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeComplement() => _complementSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolumeComponent() => _codeVolumeComponentSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeGroup() => _codeGroupSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNetWeight() => _netWeightSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGrossWeight() => _grossWeightSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantity() => _quantitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBrand() => _brandSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReference() => _referenceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSource() => _sourceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSaleAllowedOutsideKit() => _isSaleAllowedOutsideKitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeWidth() => _widthSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHeight() => _heightSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLength() => _lengthSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNCM() => _ncmSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUse() => _useSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductFather() => _productFatherSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductReplacement() => _productReplacementSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCost() => _costSet;

    public Product()
    {
        AlternativeImages = new();
        Components = new();
        Suggestions = new();
        CodesBars = new();
    }
}
