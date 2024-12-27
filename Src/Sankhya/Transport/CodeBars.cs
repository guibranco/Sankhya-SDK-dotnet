using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("CodigoBarras")]
public class CodeBars : IEntity, IEquatable<CodeBars>
{
    public bool Equals(CodeBars other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                string.Equals(_code, other._code, StringComparison.OrdinalIgnoreCase)
                && _codeSet == other._codeSet
                && _codeProduct == other._codeProduct
                && _codeProductSet == other._codeProductSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && string.Equals(_codeVolume, other._codeVolume, StringComparison.OrdinalIgnoreCase)
                && _codeVolumeSet == other._codeVolumeSet
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet == other._dateChangedSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is CodeBars bars && Equals(bars));
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
            var hashCode =
                _code != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_code) : 0;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _codeVolume != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_codeVolume)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _codeVolumeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(CodeBars left, CodeBars right) => Equals(left, right);

    public static bool operator !=(CodeBars left, CodeBars right) => !Equals(left, right);

    private string _code;

    private bool _codeSet;

    private int _codeProduct;

    private bool _codeProductSet;

    private int _codeUser;

    private bool _codeUserSet;

    private string _codeVolume;

    private bool _codeVolumeSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    [EntityKey]
    [EntityElement("CODBARRA")]
    public string Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("CODPROD")]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
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

    [EntityElement("CODVOL")]
    public string CodeVolume
    {
        get => _codeVolume;
        set
        {
            _codeVolume = value;
            _codeVolumeSet = true;
        }
    }

    [EntityElement("DHALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged;
        set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeVolume() => _codeVolumeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
