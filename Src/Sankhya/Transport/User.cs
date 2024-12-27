using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("Usuario")]
public class User : IEntity, IEquatable<User>
{
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

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is User user && Equals(user));
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

    public static bool operator ==(User left, User right) => Equals(left, right);

    public static bool operator !=(User left, User right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private int _codeSeller;

    private bool _codeSellerSet;

    private int _codeGroup;

    private bool _codeGroupSet;

    private string _name;

    private bool _nameSet;

    private string _email;

    private bool _emailSet;

    private DateTime? _accessLimitDate;

    private bool _accessLimitDateSet;

    private Partner _partner;

    private bool _partnerSet;

    private UserGroup _group;

    private bool _groupSet;

    private Seller _seller;

    private bool _sellerSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeGroup() => _codeGroupSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmail() => _emailSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccessLimitDate() => _accessLimitDateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeGroup() => _groupSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;

    public override string ToString() =>
        Partner.Name.IndexOf(@"SEM PARCEIRO", StringComparison.OrdinalIgnoreCase) != -1
            ? Name
            : $@"{Name} - {Partner.Name.ToCamelCase()}";
}
