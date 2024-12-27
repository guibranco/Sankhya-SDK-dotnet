using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("ComplementoParc")]
public class PartnerComplement : IEntity, IEquatable<PartnerComplement>
{
    public bool Equals(PartnerComplement other)
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
                    _zipCodeDelivery,
                    other._zipCodeDelivery,
                    StringComparison.OrdinalIgnoreCase
                )
                && _zipCodeDeliverySet == other._zipCodeDeliverySet
                && _codeAddressDelivery == other._codeAddressDelivery
                && _codeAddressDeliverySet == other._codeAddressDeliverySet
                && string.Equals(
                    _addressNumberDelivery,
                    other._addressNumberDelivery,
                    StringComparison.OrdinalIgnoreCase
                )
                && _addressNumberDeliverySet == other._addressNumberDeliverySet
                && string.Equals(
                    _addressComplementDelivery,
                    other._addressComplementDelivery,
                    StringComparison.OrdinalIgnoreCase
                )
                && _addressComplementDeliverySet == other._addressComplementDeliverySet
                && _codeNeighborhoodDelivery == other._codeNeighborhoodDelivery
                && _codeNeighborhoodDeliverySet == other._codeNeighborhoodDeliverySet
                && _codeCityDelivery == other._codeCityDelivery
                && _codeCityDeliverySet == other._codeCityDeliverySet
                && string.Equals(
                    _latitudeDelivery,
                    other._latitudeDelivery,
                    StringComparison.OrdinalIgnoreCase
                )
                && _latitudeDeliverySet == other._latitudeDeliverySet
                && string.Equals(
                    _longitudeDelivery,
                    other._longitudeDelivery,
                    StringComparison.OrdinalIgnoreCase
                )
                && _longitudeDeliverySet == other._longitudeDeliverySet
                && Equals(_addressDelivery, other._addressDelivery)
                && _addressDeliverySet == other._addressDeliverySet
                && Equals(_neighborhoodDelivery, other._neighborhoodDelivery)
                && _neighborhoodDeliverySet == other._neighborhoodDeliverySet
                && Equals(_cityDelivery, other._cityDelivery)
                && _cityDeliverySet == other._cityDeliverySet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj)
            || (obj is PartnerComplement complement && Equals(complement));
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
                    _zipCodeDelivery != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_zipCodeDelivery)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _zipCodeDeliverySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeAddressDelivery;
            hashCode = (hashCode * 397) ^ _codeAddressDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _addressNumberDelivery != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _addressNumberDelivery
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressNumberDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _addressComplementDelivery != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _addressComplementDelivery
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressComplementDeliverySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeNeighborhoodDelivery;
            hashCode = (hashCode * 397) ^ _codeNeighborhoodDeliverySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCityDelivery;
            hashCode = (hashCode * 397) ^ _codeCityDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _latitudeDelivery != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_latitudeDelivery)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _latitudeDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _longitudeDelivery != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_longitudeDelivery)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _longitudeDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397) ^ (_addressDelivery != null ? _addressDelivery.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _addressDeliverySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_neighborhoodDelivery != null ? _neighborhoodDelivery.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _neighborhoodDeliverySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_cityDelivery != null ? _cityDelivery.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _cityDeliverySet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(PartnerComplement left, PartnerComplement right) =>
        Equals(left, right);

    public static bool operator !=(PartnerComplement left, PartnerComplement right) =>
        !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _zipCodeDelivery;

    private bool _zipCodeDeliverySet;

    private int _codeAddressDelivery;

    private bool _codeAddressDeliverySet;

    private string _addressNumberDelivery;

    private bool _addressNumberDeliverySet;

    private string _addressComplementDelivery;

    private bool _addressComplementDeliverySet;

    private int _codeNeighborhoodDelivery;

    private bool _codeNeighborhoodDeliverySet;

    private int _codeCityDelivery;

    private bool _codeCityDeliverySet;

    private string _latitudeDelivery;

    private bool _latitudeDeliverySet;

    private string _longitudeDelivery;

    private bool _longitudeDeliverySet;

    private Address _addressDelivery;

    private bool _addressDeliverySet;

    private Neighborhood _neighborhoodDelivery;

    private bool _neighborhoodDeliverySet;

    private City _cityDelivery;

    private bool _cityDeliverySet;

    [EntityElement("CODPARC")]
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

    [EntityElement("CEPENTREGA")]
    public string ZipCodeDelivery
    {
        get => _zipCodeDelivery;
        set
        {
            _zipCodeDelivery = value;
            _zipCodeDeliverySet = true;
        }
    }

    [EntityElement("CODENDENTREGA")]
    public int CodeAddressDelivery
    {
        get => _codeAddressDelivery;
        set
        {
            _codeAddressDelivery = value;
            _codeAddressDeliverySet = true;
        }
    }

    [EntityElement("NUMENTREGA")]
    public string AddressNumberDelivery
    {
        get => _addressNumberDelivery;
        set
        {
            _addressNumberDelivery = value;
            _addressNumberDeliverySet = true;
        }
    }

    [EntityElement("COMPLENTREGA")]
    [EntityCustomData(MaxLength = 30)]
    public string AddressComplementDelivery
    {
        get => _addressComplementDelivery;
        set
        {
            _addressComplementDelivery = value;
            _addressComplementDeliverySet = true;
        }
    }

    [EntityElement("CODBAIENTREGA")]
    public int CodeNeighborhoodDelivery
    {
        get => _codeNeighborhoodDelivery;
        set
        {
            _codeNeighborhoodDelivery = value;
            _codeNeighborhoodDeliverySet = true;
        }
    }

    [EntityElement("CODCIDENTREGA")]
    public int CodeCityDelivery
    {
        get => _codeCityDelivery;
        set
        {
            _codeCityDelivery = value;
            _codeCityDeliverySet = true;
        }
    }

    [EntityElement("LATITUDEENTREGA")]
    public string LatitudeDelivery
    {
        get => _latitudeDelivery;
        set
        {
            _latitudeDelivery = value;
            _latitudeDeliverySet = true;
        }
    }

    [EntityElement("LONGITUDEENTREGA")]
    public string LongitudeDelivery
    {
        get => _longitudeDelivery;
        set
        {
            _longitudeDelivery = value;
            _longitudeDeliverySet = true;
        }
    }

    [EntityReference]
    public Address AddressDelivery
    {
        get => _addressDelivery;
        set
        {
            _addressDelivery = value;
            _addressDeliverySet = true;
        }
    }

    [EntityReference]
    public Neighborhood NeighborhoodDelivery
    {
        get => _neighborhoodDelivery;
        set
        {
            _neighborhoodDelivery = value;
            _neighborhoodDeliverySet = true;
        }
    }

    [EntityReference]
    public City CityDelivery
    {
        get => _cityDelivery;
        set
        {
            _cityDelivery = value;
            _cityDeliverySet = true;
        }
    }

    public bool ShouldSerializeCode() => _codeSet;

    public bool ShouldSerializeZipCodeDelivery() => _zipCodeDeliverySet;

    public bool ShouldSerializeCodeAddressDelivery() => _codeAddressDeliverySet;

    public bool ShouldSerializeAddressNumberDelivery() => _addressNumberDeliverySet;

    public bool ShouldSerializeAddressComplementDelivery() => _addressComplementDeliverySet;

    public bool ShouldSerializeCodeNeighborhoodDelivery() => _codeNeighborhoodDeliverySet;

    public bool ShouldSerializeCodeCityDelivery() => _codeCityDeliverySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLatitudeDelivery() => _latitudeDeliverySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLongitudeDelivery() => _longitudeDeliverySet;

    public bool ShouldSerializeAddressDelivery() => _addressDeliverySet;

    public bool ShouldSerializeNeighborhoodDelivery() => _neighborhoodDeliverySet;

    public bool ShouldSerializeCityDelivery() => _cityDeliverySet;
}
