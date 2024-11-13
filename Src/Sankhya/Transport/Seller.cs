using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Represents a seller entity in the system, including details such as codes, nickname, email, active status, type, and related partner information.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
[Entity("Vendedor")]
public class Seller : IEntity, IEquatable<Seller>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(Seller other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && _isActive == other._isActive
                && _isActiveSet == other._isActiveSet
                && string.Equals(_nickname, other._nickname, StringComparison.OrdinalIgnoreCase)
                && _nicknameSet == other._nicknameSet
                && string.Equals(_email, other._email, StringComparison.OrdinalIgnoreCase)
                && _emailSet == other._emailSet
                && _type == other._type
                && _typeSet == other._typeSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
                && Equals(_partner, other._partner)
                && _partnerSet == other._partnerSet
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

        return ReferenceEquals(this, obj) || (obj is Seller seller && Equals(seller));
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
    /// Implements the == operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Seller left, Seller right) => Equals(left, right);

    /// <summary>
    /// Implements the != operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Seller left, Seller right) => !Equals(left, right);

    /// <summary>
    /// The seller's code.
    /// </summary>
    private int _code;

    /// <summary>
    /// Indicates whether the seller's code is set.
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The user's code associated with the seller.
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// Indicates whether the user's code is set.
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The partner's code associated with the seller.
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// Indicates whether the partner's code is set.
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// Indicates whether the seller is active.
    /// </summary>
    private bool _isActive;

    /// <summary>
    /// Indicates whether the active status is set.
    /// </summary>
    private bool _isActiveSet;

    /// <summary>
    /// The seller's nickname.
    /// </summary>
    private string _nickname;

    /// <summary>
    /// Indicates whether the nickname is set.
    /// </summary>
    private bool _nicknameSet;

    /// <summary>
    /// The seller's email address.
    /// </summary>
    private string _email;

    /// <summary>
    /// Indicates whether the email is set.
    /// </summary>
    private bool _emailSet;

    /// <summary>
    /// The type of the seller.
    /// </summary>
    private SellerType _type;

    /// <summary>
    /// Indicates whether the seller type is set.
    /// </summary>
    private bool _typeSet;

    /// <summary>
    /// The date the seller was last changed.
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// Indicates whether the date changed is set.
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The partner associated with the seller.
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// Indicates whether the partner is set.
    /// </summary>
    private bool _partnerSet;

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

    /// <summary>
    /// Shoulds the serialize code.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Shoulds the serialize code user.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Shoulds the serialize code partner.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Shoulds the serialize is active.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    /// <summary>
    /// Shoulds the serialize nickname.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNickname() => _nicknameSet;

    /// <summary>
    /// Shoulds the serialize email.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmail() => _emailSet;

    /// <summary>
    /// Shoulds the type of the serialize.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    /// <summary>
    /// Shoulds the serialize date changed.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Shoulds the serialize partner.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;
}
