using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("GrupoUsuario")]
public class UserGroup : IEntity, IEquatable<UserGroup>
{
    public bool Equals(UserGroup other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
                && _isActive == other._isActive
                && _isActiveSet == other._isActiveSet
                && string.Equals(_userName, other._userName, StringComparison.OrdinalIgnoreCase)
                && _userNameSet == other._userNameSet
                && string.Equals(
                    _emailAddress,
                    other._emailAddress,
                    StringComparison.OrdinalIgnoreCase
                )
                && _emailAddressSet == other._emailAddressSet
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

        var a = obj as UserGroup;
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
            var hashCode = _code;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActive.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActiveSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _userName != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_userName)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _userNameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _emailAddress != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_emailAddress)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _emailAddressSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(UserGroup left, UserGroup right) => Equals(left, right);

    public static bool operator !=(UserGroup left, UserGroup right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _name;

    private bool _nameSet;

    private bool _isActive;

    private bool _isActiveSet;

    private string _userName;

    private bool _userNameSet;

    private string _emailAddress;

    private bool _emailAddressSet;

    [EntityElement("CODGRUPO")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("NOMEGRUPO")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
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

    [EntityElement("USER_NAME", true)]
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            _userNameSet = true;
        }
    }

    [EntityElement("EMAIL")]
    public string EmailAddress
    {
        get => _emailAddress;
        set
        {
            _emailAddress = value;
            _emailAddressSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserName() => _userNameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;
}
