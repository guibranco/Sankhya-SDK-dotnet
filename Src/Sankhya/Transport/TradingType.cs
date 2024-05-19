using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

/// <summary>
/// Class TradingType. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("TipoNegociacao")]
public class TradingType : IEntity, IEquatable<TradingType>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(TradingType other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (_code == other._code
                && _codeSet == other._codeSet
                && string.Equals(
                    _description,
                    other._description,
                    StringComparison.OrdinalIgnoreCase
                )
                && _descriptionSet == other._descriptionSet
                && _active == other._active
                && _activeSet == other._activeSet
                && _subType == other._subType
                && _subTypeSet == other._subTypeSet);
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

        return ReferenceEquals(this, obj) || (obj is TradingType type && Equals(type));
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
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
                    _description != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_description)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _descriptionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _active.GetHashCode();
            hashCode = (hashCode * 397) ^ _activeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_subType;
            hashCode = (hashCode * 397) ^ _subTypeSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(TradingType left, TradingType right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(TradingType left, TradingType right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The description
    /// </summary>
    private string _description;

    /// <summary>
    /// The description set
    /// </summary>
    private bool _descriptionSet;

    /// <summary>
    /// The active
    /// </summary>
    private bool _active;

    /// <summary>
    /// The active set
    /// </summary>
    private bool _activeSet;

    /// <summary>
    /// The sub type
    /// </summary>
    private TradingSubType _subType;

    /// <summary>
    /// The sub type set
    /// </summary>
    private bool _subTypeSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityElement("CODTIPVENDA")]
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
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [EntityElement("DESCRTIPVENDA")]
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
    [EntityElement("ATIVO")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ActiveInternal
    {
        get => _active.ToString();
        set
        {
            _active = value.ToBoolean(@"S|N");
            _activeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the sub.
    /// </summary>
    /// <value>The type of the sub.</value>
    [EntityIgnore]
    public TradingSubType SubType
    {
        get => _subType;
        set
        {
            _subType = value;
            _subTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the sub type internal.
    /// </summary>
    /// <value>The sub type internal.</value>
    [EntityElement("SUBTIPOVENDA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SubTypeInternal
    {
        get => _subType.GetInternalValue();
        set
        {
            _subType = EnumExtensions.GetEnumByInternalValueAttribute<TradingSubType>(value);
            _subTypeSet = true;
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
    /// Should the serialize description.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    /// <summary>
    /// Should the serialize active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    /// <summary>
    /// Should the type of the serialize sub.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSubType() => _subTypeSet;
}
