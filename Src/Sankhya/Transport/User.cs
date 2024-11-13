using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class User. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
/// <seealso cref="IEquatable{T}" />
[Serializer]
[Entity("Usuario")]
public class User : IEntity, IEquatable<User>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise,
    /// false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(User other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _codeGroup == other._codeGroup
                && _codeGroupSet == other._codeGroupSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
                && string.Equals(_email, other._email, StringComparison.OrdinalIgnoreCase)
                && _emailSet == other._emailSet
                && _accessLimitDate.Equals(other._accessLimitDate)
                && _accessLimitDateSet == other._accessLimitDateSet
                && Equals(_partner, other._partner)
                && _partnerSet == other._partnerSet
                && Equals(_group, other._group)
                && _groupSet == other._groupSet
                && Equals(_seller, other._seller)
                && _sellerSet == other._sellerSet
            );
    }

    /// <summary>
    /// Determines whether the specified <see cref="Object" /> is equal to the current
    /// <see cref="Object" />.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is User user && Equals(user));
    }

    /// <summary>
    /// Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Object" />.</returns>
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
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeGroup;
            hashCode = (hashCode * 397) ^ _codeGroupSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _email != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_email)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _emailSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _accessLimitDate.GetHashCode();
            hashCode = (hashCode * 397) ^ _accessLimitDateSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_partner != null ? _partner.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_group != null ? _group.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _groupSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null ? _seller.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Equality operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operation.</returns>
    public static bool operator ==(User left, User right) => Equals(left, right);

    /// <summary>
    /// Inequality operator.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operation.</returns>
    public static bool operator !=(User left, User right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The code seller
    /// </summary>
    private int _codeSeller;

    /// <summary>
    /// The code seller set
    /// </summary>
    private bool _codeSellerSet;

    /// <summary>
    /// The code group
    /// </summary>
    private int _codeGroup;

    /// <summary>
    /// The code group set
    /// </summary>
    private bool _codeGroupSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The email
    /// </summary>
    private string _email;

    /// <summary>
    /// The email set
    /// </summary>
    private bool _emailSet;

    /// <summary>
    /// The access limit date
    /// </summary>
    private DateTime? _accessLimitDate;

    /// <summary>
    /// The access limit date set
    /// </summary>
    private bool _accessLimitDateSet;

    /// <summary>
    /// The partner
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// The partner set
    /// </summary>
    private bool _partnerSet;

    /// <summary>
    /// The group
    /// </summary>
    private UserGroup _group;

    /// <summary>
    /// The group set
    /// </summary>
    private bool _groupSet;

    /// <summary>
    /// The seller
    /// </summary>
    private Seller _seller;

    /// <summary>
    /// The seller set
    /// </summary>
    private bool _sellerSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityKey]
    [EntityElement("CODUSU")]
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
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [EntityKey]
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
    /// Gets or sets the code seller.
    /// </summary>
    /// <value>
    /// The code seller.
    /// </value>
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
    /// Gets or sets the code group.
    /// </summary>
    /// <value>The code group.</value>
    [EntityElement("CODGRUPO")]
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
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [EntityKey]
    [EntityElement("NOMEUSU")]
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
    /// Gets or sets the access limit date.
    /// </summary>
    /// <value>
    /// The access limit date.
    /// </value>
    [EntityElement("DTLIMACESSO")]
    public DateTime? AccessLimitDate
    {
        get => _accessLimitDate;
        set
        {
            _accessLimitDate = value;
            _accessLimitDateSet = true;
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
    /// Gets or sets the group.
    /// </summary>
    /// <value>The group.</value>
    [EntityReference]
    public UserGroup Group
    {
        get => _group;
        set
        {
            _group = value;
            _groupSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the seller.
    /// </summary>
    /// <value>
    /// The seller.
    /// </value>
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

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// The should serialize code seller serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    /// <summary>
    /// Should the serialize code group.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeGroup() => _codeGroupSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize email.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmail() => _emailSet;

    /// <summary>
    /// The should serialize access limit date serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccessLimitDate() => _accessLimitDateSet;

    /// <summary>
    /// Should the serialize partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    /// <summary>
    /// Should the serialize group.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGroup() => _groupSet;

    /// <summary>
    /// The should serialize seller serialization helper method
    /// </summary>
    /// <returns>
    /// Returns <c>true</c> when the field should be serialized, false otherwise
    /// </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() =>
        Partner.Name.IndexOf(@"SEM PARCEIRO", StringComparison.OrdinalIgnoreCase) != -1
            ? Name
            : $@"{Name} - {Partner.Name.ToCamelCase()}";
}
