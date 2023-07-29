// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="PartnerComplement.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Transport;

using System;
using System.ComponentModel;
using Sankhya.Attributes;

/// <summary>
/// Class PartnerComplement. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("ComplementoParc")]
public class PartnerComplement : IEntity, IEquatable<PartnerComplement>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(PartnerComplement other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && string.Equals(
                    _zipCodeDelivery,
                    other._zipCodeDelivery,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _zipCodeDeliverySet == other._zipCodeDeliverySet
                && _codeAddressDelivery == other._codeAddressDelivery
                && _codeAddressDeliverySet == other._codeAddressDeliverySet
                && string.Equals(
                    _addressNumberDelivery,
                    other._addressNumberDelivery,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _addressNumberDeliverySet == other._addressNumberDeliverySet
                && string.Equals(
                    _addressComplementDelivery,
                    other._addressComplementDelivery,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _addressComplementDeliverySet == other._addressComplementDeliverySet
                && _codeNeighborhoodDelivery == other._codeNeighborhoodDelivery
                && _codeNeighborhoodDeliverySet == other._codeNeighborhoodDeliverySet
                && _codeCityDelivery == other._codeCityDelivery
                && _codeCityDeliverySet == other._codeCityDeliverySet
                && string.Equals(
                    _latitudeDelivery,
                    other._latitudeDelivery,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _latitudeDeliverySet == other._latitudeDeliverySet
                && string.Equals(
                    _longitudeDelivery,
                    other._longitudeDelivery,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _longitudeDeliverySet == other._longitudeDeliverySet
                && Equals(_addressDelivery, other._addressDelivery)
                && _addressDeliverySet == other._addressDeliverySet
                && Equals(_neighborhoodDelivery, other._neighborhoodDelivery)
                && _neighborhoodDeliverySet == other._neighborhoodDeliverySet
                && Equals(_cityDelivery, other._cityDelivery)
                && _cityDeliverySet == other._cityDeliverySet;
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

        return ReferenceEquals(this, obj)
            || obj is PartnerComplement complement && Equals(complement);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(PartnerComplement left, PartnerComplement right) =>
        Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(PartnerComplement left, PartnerComplement right) =>
        !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The zip code delivery
    /// </summary>
    private string _zipCodeDelivery;

    /// <summary>
    /// The zip code delivery set
    /// </summary>
    private bool _zipCodeDeliverySet;

    /// <summary>
    /// The code address delivery
    /// </summary>
    private int _codeAddressDelivery;

    /// <summary>
    /// The code address delivery set
    /// </summary>
    private bool _codeAddressDeliverySet;

    /// <summary>
    /// The address number delivery
    /// </summary>
    private string _addressNumberDelivery;

    /// <summary>
    /// The address number delivery set
    /// </summary>
    private bool _addressNumberDeliverySet;

    /// <summary>
    /// The address complement delivery
    /// </summary>
    private string _addressComplementDelivery;

    /// <summary>
    /// The address complement delivery set
    /// </summary>
    private bool _addressComplementDeliverySet;

    /// <summary>
    /// The code neighborhood delivery
    /// </summary>
    private int _codeNeighborhoodDelivery;

    /// <summary>
    /// The code neighborhood delivery set
    /// </summary>
    private bool _codeNeighborhoodDeliverySet;

    /// <summary>
    /// The code city delivery
    /// </summary>
    private int _codeCityDelivery;

    /// <summary>
    /// The code city delivery set
    /// </summary>
    private bool _codeCityDeliverySet;

    /// <summary>
    /// The latitude delivery
    /// </summary>
    private string _latitudeDelivery;

    /// <summary>
    /// The latitude delivery set
    /// </summary>
    private bool _latitudeDeliverySet;

    /// <summary>
    /// The longitude delivery
    /// </summary>
    private string _longitudeDelivery;

    /// <summary>
    /// The longitude delivery set
    /// </summary>
    private bool _longitudeDeliverySet;

    /// <summary>
    /// The address delivery
    /// </summary>
    private Address _addressDelivery;

    /// <summary>
    /// The address delivery set
    /// </summary>
    private bool _addressDeliverySet;

    /// <summary>
    /// The neighborhood delivery
    /// </summary>
    private Neighborhood _neighborhoodDelivery;

    /// <summary>
    /// The neighborhood delivery set
    /// </summary>
    private bool _neighborhoodDeliverySet;

    /// <summary>
    /// The city delivery
    /// </summary>
    private City _cityDelivery;

    /// <summary>
    /// The city delivery set
    /// </summary>
    private bool _cityDeliverySet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
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

    /// <summary>
    /// Gets or sets the zip code delivery.
    /// </summary>
    /// <value>The zip code delivery.</value>
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

    /// <summary>
    /// Gets or sets the code address delivery.
    /// </summary>
    /// <value>The code address delivery.</value>
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

    /// <summary>
    /// Gets or sets the address number delivery.
    /// </summary>
    /// <value>The address number delivery.</value>
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

    /// <summary>
    /// Gets or sets the address complement delivery.
    /// </summary>
    /// <value>The address complement delivery.</value>
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

    /// <summary>
    /// Gets or sets the code neighborhood delivery.
    /// </summary>
    /// <value>The code neighborhood delivery.</value>
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

    /// <summary>
    /// Gets or sets the code city delivery.
    /// </summary>
    /// <value>The code city delivery.</value>
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

    /// <summary>
    /// Gets or sets the latitude delivery.
    /// </summary>
    /// <value>The latitude delivery.</value>
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

    /// <summary>
    /// Gets or sets the longitude delivery.
    /// </summary>
    /// <value>The longitude delivery.</value>
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

    /// <summary>
    /// Gets or sets the address delivery.
    /// </summary>
    /// <value>The address delivery.</value>
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

    /// <summary>
    /// Gets or sets the neighborhood delivery.
    /// </summary>
    /// <value>The neighborhood delivery.</value>
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

    /// <summary>
    /// Gets or sets the city delivery.
    /// </summary>
    /// <value>The city delivery.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize zip code delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeZipCodeDelivery() => _zipCodeDeliverySet;

    /// <summary>
    /// Should the serialize code address delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeAddressDelivery() => _codeAddressDeliverySet;

    /// <summary>
    /// Should the serialize address number delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeAddressNumberDelivery() => _addressNumberDeliverySet;

    /// <summary>
    /// Should the serialize address complement delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeAddressComplementDelivery() => _addressComplementDeliverySet;

    /// <summary>
    /// Should the serialize code neighborhood delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeNeighborhoodDelivery() => _codeNeighborhoodDeliverySet;

    /// <summary>
    /// Should the serialize code city delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeCityDelivery() => _codeCityDeliverySet;

    /// <summary>
    /// The should serialize latitude delivery serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLatitudeDelivery() => _latitudeDeliverySet;

    /// <summary>
    /// The should serialize longitude delivery serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLongitudeDelivery() => _longitudeDeliverySet;

    /// <summary>
    /// Should the serialize address delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeAddressDelivery() => _addressDeliverySet;

    /// <summary>
    /// Should the serialize neighborhood delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeNeighborhoodDelivery() => _neighborhoodDeliverySet;

    /// <summary>
    /// Should the serialize city delivery.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCityDelivery() => _cityDeliverySet;

    #endregion
}
