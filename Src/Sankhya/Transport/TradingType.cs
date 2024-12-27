using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("TipoNegociacao")]
public class TradingType : IEntity, IEquatable<TradingType>
{
    public bool Equals(TradingType other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
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
                && _subTypeSet == other._subTypeSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is TradingType type && Equals(type));
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

    public static bool operator ==(TradingType left, TradingType right) => Equals(left, right);

    public static bool operator !=(TradingType left, TradingType right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _description;

    private bool _descriptionSet;

    private bool _active;

    private bool _activeSet;

    private TradingSubType _subType;

    private bool _subTypeSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSubType() => _subTypeSet;
}
