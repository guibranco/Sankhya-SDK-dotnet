// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ZipCode.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class ZipCode.
/// </summary>
/// <seealso cref="IEntity" />
[Serializer]
[Entity("CEP")]
public class ZipCode : IEntity, IEquatable<ZipCode>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    public bool Equals(ZipCode other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || string.Equals(_zip, other._zip)
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
                && _addressSet.Equals(other._addressSet);
    }

    /// <summary>
    /// Determines whether the specified <see cref="Object" /> is equal to the current <see cref="Object" />.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || obj is ZipCode code && Equals(code);
    }

    /// <summary>
    /// Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Object" />.</returns>
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(ZipCode left, ZipCode right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(ZipCode left, ZipCode right) => !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The zip
    /// </summary>
    private string _zip;

    /// <summary>
    /// The zip set
    /// </summary>
    private bool _zipSet;

    /// <summary>
    /// The interval
    /// </summary>
    private string _interval;

    /// <summary>
    /// The interval set
    /// </summary>
    private bool _intervalSet;

    /// <summary>
    /// The code city
    /// </summary>
    private int _codeCity;

    /// <summary>
    /// The code city set
    /// </summary>
    private bool _codeCitySet;

    /// <summary>
    /// The code neighborhood
    /// </summary>
    private int _codeNeighborhood;

    /// <summary>
    /// The code neighborhood set
    /// </summary>
    private bool _codeNeighborhoodSet;

    /// <summary>
    /// The code address
    /// </summary>
    private int _codeAddress;

    /// <summary>
    /// The code address set
    /// </summary>
    private bool _codeAddressSet;

    /// <summary>
    /// The city
    /// </summary>
    private City _city;

    /// <summary>
    /// The city set
    /// </summary>
    private bool _citySet;

    /// <summary>
    /// The neighborhood
    /// </summary>
    private Neighborhood _neighborhood;

    /// <summary>
    /// The neighborhood set
    /// </summary>
    private bool _neighborhoodSet;

    /// <summary>
    /// The address
    /// </summary>
    private Address _address;

    /// <summary>
    /// The address set
    /// </summary>
    private bool _addressSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the zip.
    /// </summary>
    /// <value>The zip.</value>
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

    /// <summary>
    /// Gets or sets the interval.
    /// </summary>
    /// <value>The interval.</value>
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

    /// <summary>
    /// Gets or sets the code city.
    /// </summary>
    /// <value>The code city.</value>
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

    /// <summary>
    /// Gets or sets the code neighborhood.
    /// </summary>
    /// <value>The code neighborhood.</value>
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

    /// <summary>
    /// Gets or sets the code address.
    /// </summary>
    /// <value>The code address.</value>
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

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
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

    /// <summary>
    /// Gets or sets the neighborhood.
    /// </summary>
    /// <value>The neighborhood.</value>
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

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize zip.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeZip() => _zipSet;

    /// <summary>
    /// Should the serialize interval.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeInterval() => _intervalSet;

    /// <summary>
    /// Should the serialize code city.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeCity() => _codeCitySet;

    /// <summary>
    /// Should the serialize code neighborhood.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeNeighborhood() => _codeNeighborhoodSet;

    /// <summary>
    /// Should the serialize code address.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeAddress() => _codeAddressSet;

    /// <summary>
    /// Should the serialize city.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCity() => _citySet;

    /// <summary>
    /// Should the serialize neighborhood.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeNeighborhood() => _neighborhoodSet;

    /// <summary>
    /// Should the serialize address.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeAddress() => _addressSet;

    #endregion
}
