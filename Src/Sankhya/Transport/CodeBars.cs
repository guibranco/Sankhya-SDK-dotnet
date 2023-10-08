// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="CodeBars.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class CodeBars. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("CodigoBarras")]
public class CodeBars : IEntity, IEquatable<CodeBars>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(CodeBars other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || string.Equals(_code, other._code, StringComparison.InvariantCultureIgnoreCase)
                && _codeSet == other._codeSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && string.Equals(
                    _codeVolume,
                    other._codeVolume,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _codeVolumeSet == other._codeVolumeSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet;
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

        return ReferenceEquals(this, obj) || obj is CodeBars bars && Equals(bars);
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
            var hashCode =
                _code != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_code) : 0;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _codeVolume != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_codeVolume)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _codeVolumeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(CodeBars left, CodeBars right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(CodeBars left, CodeBars right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private string _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The code user
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The code volume
    /// </summary>
    private string _codeVolume;

    /// <summary>
    /// The code volume set
    /// </summary>
    private bool _codeVolumeSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityKey]
    [EntityElement("CODBARRA")]
    public string Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
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
    /// Gets or sets the code user.
    /// </summary>
    /// <value>The code user.</value>
    [EntityElement("CODUSU")]
    public int CodeUser
    {
        get => _codeUser;
        set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code volume.
    /// </summary>
    /// <value>The code volume.</value>
    [EntityElement("CODVOL")]
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
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
    [EntityElement("DHALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged;
        set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize code user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Should the serialize code volume.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
