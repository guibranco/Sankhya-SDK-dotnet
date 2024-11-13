// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="Product.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

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

/// <summary>
/// Class Product.
/// Implements the <see cref="IEntity" />
/// Implements the <see cref="Product" />.
/// </summary>
/// <seealso cref="IEntity" />
/// <seealso cref="Product" />
[Entity("Produto")]
public class Product : IEntity, IEquatable<Product>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
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

    /// <summary>
    /// Determines whether the specified <see cref="object" /> is equal to this instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((Product)obj));
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
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

    /// <summary>
    /// Implements the == operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Product left, Product right) => Equals(left, right);

    /// <summary>
    /// Implements the != operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Product left, Product right) => !Equals(left, right);

    /// <summary>
    /// The code.
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set.
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The is active.
    /// </summary>
    private bool _isActive;

    /// <summary>
    /// The is active set.
    /// </summary>
    private bool _isActiveSet;

    /// <summary>
    /// The name.
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set.
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The complement.
    /// </summary>
    private string _complement;

    /// <summary>
    /// The complement set.
    /// </summary>
    private bool _complementSet;

    /// <summary>
    /// The description.
    /// </summary>
    private string _description;

    /// <summary>
    /// The description set.
    /// </summary>
    private bool _descriptionSet;

    /// <summary>
    /// The code volume.
    /// </summary>
    private string _codeVolume;

    /// <summary>
    /// The code volume set.
    /// </summary>
    private bool _codeVolumeSet;

    /// <summary>
    /// The code volume component.
    /// </summary>
    private string _codeVolumeComponent;

    /// <summary>
    /// The code volume component set.
    /// </summary>
    private bool _codeVolumeComponentSet;

    /// <summary>
    /// The code group.
    /// </summary>
    private int _codeGroup;

    /// <summary>
    /// The code group set.
    /// </summary>
    private bool _codeGroupSet;

    /// <summary>
    /// The net weight.
    /// </summary>
    private decimal _netWeight;

    /// <summary>
    /// The net weight set.
    /// </summary>
    private bool _netWeightSet;

    /// <summary>
    /// The gross weight.
    /// </summary>
    private decimal _grossWeight;

    /// <summary>
    /// The gross weight set.
    /// </summary>
    private bool _grossWeightSet;

    /// <summary>
    /// The quantity.
    /// </summary>
    private decimal _quantity;

    /// <summary>
    /// The quantity set.
    /// </summary>
    private bool _quantitySet;

    /// <summary>
    /// The brand.
    /// </summary>
    private string _brand;

    /// <summary>
    /// The brand set.
    /// </summary>
    private bool _brandSet;

    /// <summary>
    /// The reference.
    /// </summary>
    private string _reference;

    /// <summary>
    /// The reference set.
    /// </summary>
    private bool _referenceSet;

    /// <summary>
    /// The width.
    /// </summary>
    private decimal _width;

    /// <summary>
    /// The width set.
    /// </summary>
    private bool _widthSet;

    /// <summary>
    /// The height.
    /// </summary>
    private decimal _height;

    /// <summary>
    /// The height set.
    /// </summary>
    private bool _heightSet;

    /// <summary>
    /// The length.
    /// </summary>
    private decimal _length;

    /// <summary>
    /// The length set..
    /// </summary>
    private bool _lengthSet;

    /// <summary>
    /// The source.
    /// </summary>
    private ProductSource _source;

    /// <summary>
    /// The source set.
    /// </summary>
    private bool _sourceSet;

    /// <summary>
    /// The is sale allowed outside kit.
    /// </summary>
    private bool _isSaleAllowedOutsideKit;

    /// <summary>
    /// The is sale allowed outside kit set.
    /// </summary>
    private bool _isSaleAllowedOutsideKitSet;

    /// <summary>
    /// The NCM.
    /// </summary>
    private string _ncm;

    /// <summary>
    /// The NCM set.
    /// </summary>
    private bool _ncmSet;

    /// <summary>
    /// The use.
    /// </summary>
    private ProductUse _use;

    /// <summary>
    /// The use set.
    /// </summary>
    private bool _useSet;

    /// <summary>
    /// The product father.
    /// </summary>
    private Product _productFather;

    /// <summary>
    /// The product father set.
    /// </summary>
    private bool _productFatherSet;

    /// <summary>
    /// The product replacement.
    /// </summary>
    private Product _productReplacement;

    /// <summary>
    /// The product replacement set.
    /// </summary>
    private bool _productReplacementSet;

    /// <summary>
    /// The cost.
    /// </summary>
    private ProductCost _cost;

    /// <summary>
    /// The cost set.
    /// </summary>
    private bool _costSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether this instance is active.
    /// </summary>
    /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the is active internal.
    /// </summary>
    /// <value>The is active internal.</value>
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

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
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

    /// <summary>
    /// Gets or sets the complement.
    /// </summary>
    /// <value>The complement.</value>
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

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
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
    /// Gets or sets the code volume component.
    /// </summary>
    /// <value>The code volume component.</value>
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

    /// <summary>
    /// Gets or sets the code group.
    /// </summary>
    /// <value>The code group.</value>
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

    /// <summary>
    /// Gets or sets the net weight.
    /// </summary>
    /// <value>The net weight.</value>
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

    /// <summary>
    /// Gets or sets the gross weight.
    /// </summary>
    /// <value>The gross weight.</value>
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

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>The quantity.</value>
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

    /// <summary>
    /// Gets or sets the brand.
    /// </summary>
    /// <value>The brand.</value>
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

    /// <summary>
    /// Gets or sets the reference.
    /// </summary>
    /// <value>The reference.</value>
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

    /// <summary>
    /// Gets or sets the source.
    /// </summary>
    /// <value>The source.</value>
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

    /// <summary>
    /// Gets or sets the source internal.
    /// </summary>
    /// <value>The source internal.</value>
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

    /// <summary>
    /// Gets or sets a value indicating whether this instance is sale allowed outside kit.
    /// </summary>
    /// <value><c>true</c> if this instance is sale allowed outside kit; otherwise, <c>false</c>.</value>
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

    /// <summary>
    /// Gets or sets the is sale allowed outside kit internal.
    /// </summary>
    /// <value>The is sale allowed outside kit internal.</value>
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

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    /// <value>The width.</value>
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

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    /// <value>The height.</value>
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

    /// <summary>
    /// Gets or sets the length.
    /// </summary>
    /// <value>The length.</value>
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

    /// <summary>
    /// Gets or sets the NCM.
    /// </summary>
    /// <value>The NCM.</value>
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

    /// <summary>
    /// Gets or sets the use.
    /// </summary>
    /// <value>The use.</value>
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

    /// <summary>
    /// Gets or sets the use internal.
    /// </summary>
    /// <value>The use internal.</value>
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

    /// <summary>
    /// Gets or sets the product father.
    /// </summary>
    /// <value>The product father.</value>
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

    /// <summary>
    /// Gets or sets the product replacement.
    /// </summary>
    /// <value>The product replacement.</value>
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

    /// <summary>
    /// Gets or sets the cost.
    /// </summary>
    /// <value>The cost.</value>
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

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>The image.</value>
    [EntityIgnore]
    public Lazy<ServiceFile> Image { get; set; }

    /// <summary>
    /// The components.
    /// </summary>
    public readonly List<Product> Components;

    /// <summary>
    /// The alternative images.
    /// </summary>
    public readonly Collection<Lazy<ServiceFile>> AlternativeImages;

    /// <summary>
    /// The suggestions.
    /// </summary>
    public readonly List<ProductSuggestedSale> Suggestions;

    /// <summary>
    /// The codes bars.
    /// </summary>
    public readonly Collection<CodeBars> CodesBars;

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize is active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize complement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeComplement() => _complementSet;

    /// <summary>
    /// Should the serialize description.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    /// <summary>
    /// Should the serialize code volume.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    /// <summary>
    /// Should the serialize code volume component.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolumeComponent() => _codeVolumeComponentSet;

    /// <summary>
    /// Should the serialize code group.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeGroup() => _codeGroupSet;

    /// <summary>
    /// Should the serialize net weight.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNetWeight() => _netWeightSet;

    /// <summary>
    /// Should the serialize gross weight.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGrossWeight() => _grossWeightSet;

    /// <summary>
    /// Should the serialize quantity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeQuantity() => _quantitySet;

    /// <summary>
    /// Should the serialize brand.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBrand() => _brandSet;

    /// <summary>
    /// Should the serialize reference.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReference() => _referenceSet;

    /// <summary>
    /// Should the serialize source.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSource() => _sourceSet;

    /// <summary>
    /// Should the serialize is sale allowed outside kit.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSaleAllowedOutsideKit() => _isSaleAllowedOutsideKitSet;

    /// <summary>
    /// Should the width of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeWidth() => _widthSet;

    /// <summary>
    /// Should the height of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHeight() => _heightSet;

    /// <summary>
    /// Should the length of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLength() => _lengthSet;

    /// <summary>
    /// Should the serialize NCM.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNCM() => _ncmSet;

    /// <summary>
    /// The should serialize use serialization helper method.
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUse() => _useSet;

    /// <summary>
    /// Should the serialize product father.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductFather() => _productFatherSet;

    /// <summary>
    /// The should serialize product replacement serialization helper method.
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeProductReplacement() => _productReplacementSet;

    /// <summary>
    /// Should the serialize cost.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCost() => _costSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="Product" /> class.
    /// </summary>
    public Product()
    {
        AlternativeImages = new();
        Components = new();
        Suggestions = new();
        CodesBars = new();
    }
}
