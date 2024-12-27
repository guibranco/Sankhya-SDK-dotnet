using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("Regiao")]
public class Region : IEntity, IEquatable<Region>
{
    public bool Equals(Region other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codeRegionFather == other._codeRegionFather
                && _codeRegionFatherSet == other._codeRegionFatherSet
                && _codePriceTable == other._codePriceTable
                && _codePriceTableSet == other._codePriceTableSet
                && _codeSeller == other._codeSeller
                && _codeSellerSet == other._codeSellerSet
                && _active == other._active
                && _activeSet == other._activeSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
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

        return ReferenceEquals(this, obj) || (obj is Region region && Equals(region));
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
            hashCode = (hashCode * 397) ^ _codeRegionFather;
            hashCode = (hashCode * 397) ^ _codeRegionFatherSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePriceTable;
            hashCode = (hashCode * 397) ^ _codePriceTableSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeSeller;
            hashCode = (hashCode * 397) ^ _codeSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _active.GetHashCode();
            hashCode = (hashCode * 397) ^ _activeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_seller != null ? _seller.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _sellerSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(Region left, Region right) => Equals(left, right);

    public static bool operator !=(Region left, Region right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codeRegionFather;

    private bool _codeRegionFatherSet;

    private int _codePriceTable;

    private bool _codePriceTableSet;

    private int _codeSeller;

    private bool _codeSellerSet;

    private bool _active;

    private bool _activeSet;

    private string _name;

    private bool _nameSet;

    private Seller _seller;

    private bool _sellerSet;

    [EntityElement("CODREG")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("CODREGPAI")]
    public int CodeRegionFather
    {
        get => _codeRegionFather;
        set
        {
            _codeRegionFather = value;
            _codeRegionFatherSet = true;
        }
    }

    [EntityElement("CODTAB")]
    public int CodePriceTable
    {
        get => _codePriceTable;
        set
        {
            _codePriceTable = value;
            _codePriceTableSet = true;
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

    [EntityElement("ATIVA")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ActiveInternal
    {
        get => _active.ToString(@"S", @"N");
        set
        {
            _active = value.ToBoolean();
            _activeSet = true;
        }
    }

    [EntityElement("NOMEREG")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
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
    public bool ShouldSerializeCodeRegionFather() => _codeRegionFatherSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePriceTable() => _codePriceTableSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeSeller() => _codeSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSeller() => _sellerSet;
}
