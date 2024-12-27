using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("Vendedor")]
public class Seller : IEntity, IEquatable<Seller>
{
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

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is Seller seller && Equals(seller));
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

    public static bool operator ==(Seller left, Seller right) => Equals(left, right);

    public static bool operator !=(Seller left, Seller right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codeUser;

    private bool _codeUserSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private bool _isActive;

    private bool _isActiveSet;

    private string _nickname;

    private bool _nicknameSet;

    private string _email;

    private bool _emailSet;

    private SellerType _type;

    private bool _typeSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    private Partner _partner;

    private bool _partnerSet;

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
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNickname() => _nicknameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmail() => _emailSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;
}
