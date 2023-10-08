// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Seller.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Class Seller. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEquatable{T}" />
/// <seealso cref="IEntity" />
[Entity("Vendedor")]
public class Seller : IEntity, IEquatable<Seller>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>

    // ReSharper disable once CyclomaticComplexity
    public bool Equals(Seller other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && _isActive == other._isActive
                && _isActiveSet == other._isActiveSet
                && string.Equals(
                    _nickname,
                    other._nickname,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _nicknameSet == other._nicknameSet
                && string.Equals(_email, other._email, StringComparison.InvariantCultureIgnoreCase)
                && _emailSet == other._emailSet
                && _type == other._type
                && _typeSet == other._typeSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
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

        return ReferenceEquals(this, obj) || obj is Seller seller && Equals(seller);
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
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActive.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActiveSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _nickname != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_nickname)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _nicknameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _email != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_email)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _emailSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_type;
            hashCode = (hashCode * 397) ^ _typeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
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
    public static bool operator ==(Seller left, Seller right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Seller left, Seller right) => !Equals(left, right);

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
    /// The code user
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The active
    /// </summary>
    private bool _isActive;

    /// <summary>
    /// The active set
    /// </summary>
    private bool _isActiveSet;

    /// <summary>
    /// The nickname
    /// </summary>
    private string _nickname;

    /// <summary>
    /// The nickname set
    /// </summary>
    private bool _nicknameSet;

    /// <summary>
    /// The email
    /// </summary>
    private string _email;

    /// <summary>
    /// The email set
    /// </summary>
    private bool _emailSet;

    /// <summary>
    /// The type
    /// </summary>
    private SellerType _type;

    /// <summary>
    /// The type set
    /// </summary>
    private bool _typeSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The partner
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// The partner set
    /// </summary>
    private bool _partnerSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityElement("CODVEND")]
    [EntityKey]
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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsActiveInternal
    {
        get => _isActive.ToString(@"S", @"N");
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _isActive = value.ToBoolean(@"S|N");
            _isActiveSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the nickname.
    /// </summary>
    /// <value>The nickname.</value>
    [EntityElement("APELIDO")]
    public string Nickname
    {
        get => _nickname;
        set
        {
            _nickname = value;
            _nicknameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [EntityElement("EMAIL")]
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            _emailSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [EntityIgnore]
    public SellerType Type
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
    [EntityElement("TIPVEND")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _type = EnumExtensions.GetEnumByInternalValueAttribute<SellerType>(value);
            _typeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
    [EntityElement("DTALTER")]
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
    /// Should the serialize code user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize is active.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    /// <summary>
    /// Should the serialize nickname.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNickname() => _nicknameSet;

    /// <summary>
    /// Should the serialize email.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmail() => _emailSet;

    /// <summary>
    /// Should the type of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Should the serialize partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    #endregion
}
