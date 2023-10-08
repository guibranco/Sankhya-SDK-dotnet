// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Region.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class Region. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Regiao")]
public class Region : IEntity, IEquatable<Region>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(Region other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && _codeRegionFather == other._codeRegionFather
                && _codeRegionFatherSet == other._codeRegionFatherSet
                && _codePriceTable == other._codePriceTable
                && _codePriceTableSet == other._codePriceTableSet
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _active == other._active
                && _activeSet == other._activeSet
                && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
                && _nameSet == other._nameSet
                && Equals(_seller, other._seller)
                && _sellerSet == other._sellerSet;
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

        return ReferenceEquals(this, obj) || obj is Region region && Equals(region);
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
            var hashCode = _code;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRegionFather;
            hashCode = (hashCode * 397) ^ _codeRegionFatherSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePriceTable;
            hashCode = (hashCode * 397) ^ _codePriceTableSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _active.GetHashCode();
            hashCode = (hashCode * 397) ^ _activeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null ? _seller.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Region left, Region right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Region left, Region right) => !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The code region father
    /// </summary>
    private int _codeRegionFather;

    /// <summary>
    /// The code region father set
    /// </summary>
    private bool _codeRegionFatherSet;

    /// <summary>
    /// The code price table
    /// </summary>
    private int _codePriceTable;

    /// <summary>
    /// The code price table set
    /// </summary>
    private bool _codePriceTableSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;

    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// The active
    /// </summary>
    private bool _active;

    /// <summary>
    /// The active set
    /// </summary>
    private bool _activeSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The seller
    /// </summary>
    private Seller _seller;

    /// <summary>
    /// The seller set
    /// </summary>
    private bool _sellerSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityElement("CODREG")]
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
    /// Gets or sets the code region father.
    /// </summary>
    /// <value>The code region father.</value>
    [EntityElement("CODREGPAI")]
    public int CodeRegionFather
    {
        get => _codeRegionFather;
        set
        {
            _codeRegionFather = value;
            _codeRegionFatherSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code price table.
    /// </summary>
    /// <value>The code price table.</value>
    [EntityElement("CODTAB")]
    public int CodePriceTable
    {
        get => _codePriceTable;
        set
        {
            _codePriceTable = value;
            _codePriceTableSet = true;
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
    /// Gets or sets the active.
    /// </summary>
    /// <value>The active.</value>
    [EntityIgnore]
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            _activeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the active internal.
    /// </summary>
    /// <value>The active internal.</value>
    [EntityElement("ATIVA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ActiveInternal
    {
        get => _active.ToString(@"S", @"N");
        set
        {
            _active = value.ToBoolean();
            _activeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [EntityElement("NOMEREG")]
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
    /// Gets or sets the seller.
    /// </summary>
    /// <value>The seller.</value>
    [EntityReference]
    public Seller Seller
    {
        get => _seller;
        set
        {
            _seller = value;
            _sellerSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize code region father.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeRegionFather() => _codeRegionFatherSet;

    /// <summary>
    /// Should the serialize code price table.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePriceTable() => _codePriceTableSet;

    /// <summary>
    /// Should the serialize code seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    /// <summary>
    /// Should the serialize active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;

    #endregion
}
