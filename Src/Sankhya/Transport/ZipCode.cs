using System;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("CEP")]
public class ZipCode : IEntity, IEquatable<ZipCode>
{
    public bool Equals(ZipCode other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                string.Equals(_zip, other._zip)
                && _zipSet.Equals(other._zipSet)
                && string.Equals(_interval, other._interval)
                && _intervalSet.Equals(other._intervalSet)
                && _codeCity == other._codeCity
                && _codeCitySet.Equals(other._codeCitySet)
                && _codeNeighborhood == other._codeNeighborhood
                && _codeNeighborhoodSet.Equals(other._codeNeighborhoodSet)
                && _codeAddress == other._codeAddress
                && _codeAddressSet.Equals(other._codeAddressSet)
                && Equals(_city, other._city)
                && _citySet.Equals(other._citySet)
                && Equals(_neighborhood, other._neighborhood)
                && _neighborhoodSet.Equals(other._neighborhoodSet)
                && Equals(_address, other._address)
                && _addressSet.Equals(other._addressSet)
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is ZipCode code && Equals(code));
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
            var hashCode = _zip?.GetHashCode() ?? 0;
            hashCode = (hashCode * 397) ^ _zipSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_interval?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _intervalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCity;
            hashCode = (hashCode * 397) ^ _codeCitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeNeighborhood;
            hashCode = (hashCode * 397) ^ _codeNeighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeAddress;
            hashCode = (hashCode * 397) ^ _codeAddressSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_city != null ? _city.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _citySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_neighborhood != null ? _neighborhood.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _neighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_address != null ? _address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _addressSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(ZipCode left, ZipCode right) => Equals(left, right);

    public static bool operator !=(ZipCode left, ZipCode right) => !Equals(left, right);

    private string _zip;

    private bool _zipSet;

    private string _interval;

    private bool _intervalSet;

    private int _codeCity;

    private bool _codeCitySet;

    private int _codeNeighborhood;

    private bool _codeNeighborhoodSet;

    private int _codeAddress;

    private bool _codeAddressSet;

    private City _city;

    private bool _citySet;

    private Neighborhood _neighborhood;

    private bool _neighborhoodSet;

    private Address _address;

    private bool _addressSet;

    [EntityKey]
    [EntityElement("CEP")]
    public string Zip
    {
        get => _zip;
        set
        {
            _zip = value;
            _zipSet = true;
        }
    }

    [EntityElement("INTERVALO")]
    public string Interval
    {
        get => _interval;
        set
        {
            _interval = value;
            _intervalSet = true;
        }
    }

    [EntityKey]
    [EntityElement("CODCID")]
    public int CodeCity
    {
        get => _codeCity;
        set
        {
            _codeCity = value;
            _codeCitySet = true;
        }
    }

    [EntityKey]
    [EntityElement("CODBAI")]
    public int CodeNeighborhood
    {
        get => _codeNeighborhood;
        set
        {
            _codeNeighborhood = value;
            _codeNeighborhoodSet = true;
        }
    }

    [EntityKey]
    [EntityElement("CODEND")]
    public int CodeAddress
    {
        get => _codeAddress;
        set
        {
            _codeAddress = value;
            _codeAddressSet = true;
        }
    }

    [EntityReference]
    public City City
    {
        get => _city;
        set
        {
            _city = value;
            _citySet = true;
        }
    }

    [EntityReference]
    public Neighborhood Neighborhood
    {
        get => _neighborhood;
        set
        {
            _neighborhood = value;
            _neighborhoodSet = true;
        }
    }

    [EntityReference]
    public Address Address
    {
        get => _address;
        set
        {
            _address = value;
            _addressSet = true;
        }
    }

    public bool ShouldSerializeZip() => _zipSet;

    public bool ShouldSerializeInterval() => _intervalSet;

    public bool ShouldSerializeCodeCity() => _codeCitySet;

    public bool ShouldSerializeCodeNeighborhood() => _codeNeighborhoodSet;

    public bool ShouldSerializeCodeAddress() => _codeAddressSet;

    public bool ShouldSerializeCity() => _citySet;

    public bool ShouldSerializeNeighborhood() => _neighborhoodSet;

    public bool ShouldSerializeAddress() => _addressSet;
}
