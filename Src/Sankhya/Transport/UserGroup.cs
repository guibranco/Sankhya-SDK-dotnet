using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class UserGroup. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
/// <seealso cref="IEquatable{UserGroup}" />
[Entity("GrupoUsuario")]
public class UserGroup : IEntity, IEquatable<UserGroup>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(UserGroup other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
                && _nameSet == other._nameSet
                && _isActive == other._isActive
                && _isActiveSet == other._isActiveSet
                && string.Equals(
                    _userName,
                    other._userName,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _userNameSet == other._userNameSet
                && string.Equals(
                    _emailAddress,
                    other._emailAddress,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _emailAddressSet == other._emailAddressSet;
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

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        var a = obj as UserGroup;
        return a != null && Equals(a);
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

    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="UserGroup" /> objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
    public static bool operator ==(UserGroup left, UserGroup right) => Equals(left, right);

    /// <summary>
    /// Returns a value that indicates whether two <see cref="UserGroup" /> objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
    public static bool operator !=(UserGroup left, UserGroup right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The is active
    /// </summary>
    private bool _isActive;

    /// <summary>
    /// The is active set
    /// </summary>
    private bool _isActiveSet;

    /// <summary>
    /// The user name
    /// </summary>
    private string _userName;

    /// <summary>
    /// The user name set
    /// </summary>
    private bool _userNameSet;

    /// <summary>
    /// The email address
    /// </summary>
    private string _emailAddress;

    /// <summary>
    /// The email address set
    /// </summary>
    private bool _emailAddressSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
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

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
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

    /// <summary>
    /// Gets or sets the is active.
    /// </summary>
    /// <value>The is active.</value>
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
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
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

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <value>The email address.</value>
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

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize is active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    /// <summary>
    /// Should the name of the serialize user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserName() => _userNameSet;

    /// <summary>
    /// Should the serialize email address.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;
}
