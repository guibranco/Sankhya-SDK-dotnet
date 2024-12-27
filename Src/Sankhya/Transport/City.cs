using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("Cidade")]
public class City : IEntity, IEquatable<City>
{
    public bool Equals(City other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codeState == other._codeState
                && _codeStateSet == other._codeStateSet
                && _codeRegion == other._codeRegion
                && _codeRegionSet == other._codeRegionSet
                && _codeFiscal == other._codeFiscal
                && _codeFiscalSet == other._codeFiscalSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
                && string.Equals(
                    _descriptionCorreios,
                    other._descriptionCorreios,
                    StringComparison.OrdinalIgnoreCase
                )
                && _descriptionCorreiosSet == other._descriptionCorreiosSet
                && Equals(_state, other._state)
                && _stateSet == other._stateSet
                && Equals(_region, other._region)
                && _regionSet == other._regionSet
                && _areaCode == other._areaCode
                && _areaCodeSet == other._areaCodeSet
                && string.Equals(_latitude, other._latitude, StringComparison.OrdinalIgnoreCase)
                && _latitudeSet == other._latitudeSet
                && string.Equals(_longitude, other._longitude, StringComparison.OrdinalIgnoreCase)
                && _longitudeSet == other._longitudeSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((City)obj));
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
            hashCode = (hashCode * 397) ^ _codeState;
            hashCode = (hashCode * 397) ^ _codeStateSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRegion;
            hashCode = (hashCode * 397) ^ _codeRegionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeFiscal;
            hashCode = (hashCode * 397) ^ _codeFiscalSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _descriptionCorreios != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _descriptionCorreios
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _descriptionCorreiosSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_state != null ? _state.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _stateSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_region != null ? _region.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _regionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _areaCode;
            hashCode = (hashCode * 397) ^ _areaCodeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _latitude != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_latitude)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _latitudeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _longitude != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_longitude)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _longitudeSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(City left, City right) => Equals(left, right);

    public static bool operator !=(City left, City right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codeState;

    private bool _codeStateSet;

    private int _codeRegion;

    private bool _codeRegionSet;

    private int _codeFiscal;

    private bool _codeFiscalSet;

    private string _name;

    private bool _nameSet;

    private string _descriptionCorreios;

    private bool _descriptionCorreiosSet;

    private State _state;

    private bool _stateSet;

    private Region _region;

    private bool _regionSet;

    private int _areaCode;

    private bool _areaCodeSet;

    private string _latitude;

    private bool _latitudeSet;

    private string _longitude;

    private bool _longitudeSet;

    [EntityKey]
    [EntityElement("CODCID")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("UF")]
    public int CodeState
    {
        get => _codeState;
        set
        {
            _codeState = value;
            _codeStateSet = true;
        }
    }

    [EntityElement("CODREG")]
    public int CodeRegion
    {
        get => _codeRegion;
        set
        {
            _codeRegion = value;
            _codeRegionSet = true;
        }
    }

    [EntityElement("CODMUNFIS")]
    public int CodeFiscal
    {
        get => _codeFiscal;
        set
        {
            _codeFiscal = value;
            _codeFiscalSet = true;
        }
    }

    [EntityElement("NOMECID")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [EntityElement("DESCRICAOCORREIO")]
    public string DescriptionCorreios
    {
        get => _descriptionCorreios;
        set
        {
            _descriptionCorreios = value;
            _descriptionCorreiosSet = true;
        }
    }

    [EntityElement("DDD")]
    public int AreaCode
    {
        get => _areaCode;
        set
        {
            _areaCode = value;
            _areaCodeSet = true;
        }
    }

    [EntityElement("LATITUDE")]
    public string Latitude
    {
        get => _latitude;
        set
        {
            _latitude = value;
            _latitudeSet = true;
        }
    }

    [EntityElement("LONGITUDE")]
    public string Longitude
    {
        get => _longitude;
        set
        {
            _longitude = value;
            _longitudeSet = true;
        }
    }

    [EntityReference]
    public State State
    {
        get => _state;
        set
        {
            _state = value;
            _stateSet = true;
        }
    }

    [EntityReference]
    public Region Region
    {
        get => _region;
        set
        {
            _region = value;
            _regionSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeState() => _codeStateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeRegion() => _codeRegionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeFiscal() => _codeFiscalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescriptionCorreios() => _descriptionCorreiosSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAreaCode() => _areaCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLatitude() => _latitudeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLongitude() => _longitudeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeState() => _stateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRegion() => _regionSet;
}
