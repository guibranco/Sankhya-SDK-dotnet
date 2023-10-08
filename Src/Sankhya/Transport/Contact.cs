using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class Contact. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Contato")]
public class Contact : IEntity, IEquatable<Contact>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(Contact other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet == other._codeSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && string.Equals(
                    _zipCode,
                    other._zipCode,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _zipCodeSet == other._zipCodeSet
                && _codeAddress == other._codeAddress
                && _codeAddressSet == other._codeAddressSet
                && string.Equals(
                    _addressComplement,
                    other._addressComplement,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _addressComplementSet == other._addressComplementSet
                && string.Equals(
                    _addressNumber,
                    other._addressNumber,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _addressNumberSet == other._addressNumberSet
                && _codeNeighborhood == other._codeNeighborhood
                && _codeNeighborhoodSet == other._codeNeighborhoodSet
                && _codeCity == other._codeCity
                && _codeCitySet == other._codeCitySet
                && _codeRegion == other._codeRegion
                && _codeRegionSet == other._codeRegionSet
                && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
                && _nameSet == other._nameSet
                && _active == other._active
                && _activeSet == other._activeSet
                && string.Equals(
                    _documentIndividual,
                    other._documentIndividual,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _documentIndividualSet == other._documentIndividualSet
                && string.Equals(
                    _documentCorporation,
                    other._documentCorporation,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _documentCorporationSet == other._documentCorporationSet
                && _registerDate.Equals(other._registerDate)
                && _registerDateSet == other._registerDateSet
                && string.Equals(
                    _emailAddress,
                    other._emailAddress,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _emailAddressSet == other._emailAddressSet
                && string.Equals(
                    _fixedTelephone,
                    other._fixedTelephone,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _fixedTelephoneSet == other._fixedTelephoneSet
                && string.Equals(
                    _mobileTelephone,
                    other._mobileTelephone,
                    StringComparison.InvariantCultureIgnoreCase
                )
                && _mobileTelephoneSet == other._mobileTelephoneSet
                && Equals(_partner, other._partner)
                && _partnerSet == other._partnerSet
                && Equals(_address, other._address)
                && _addressSet == other._addressSet
                && Equals(_neighborhood, other._neighborhood)
                && _neighborhoodSet == other._neighborhoodSet
                && Equals(_city, other._city)
                && _citySet == other._citySet
                && Equals(_region, other._region)
                && _regionSet == other._regionSet;
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

        return ReferenceEquals(this, obj) || obj is Contact contact && Equals(contact);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once MethodTooLong
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
            hashCode = (hashCode * 397) ^ _codePartner;
            hashCode = (hashCode * 397) ^ _codePartnerSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _zipCode != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_zipCode)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _zipCodeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeAddress;
            hashCode = (hashCode * 397) ^ _codeAddressSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _addressComplement != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_addressComplement)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressComplementSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _addressNumber != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_addressNumber)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressNumberSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeNeighborhood;
            hashCode = (hashCode * 397) ^ _codeNeighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCity;
            hashCode = (hashCode * 397) ^ _codeCitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRegion;
            hashCode = (hashCode * 397) ^ _codeRegionSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _active.GetHashCode();
            hashCode = (hashCode * 397) ^ _activeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _documentIndividual != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_documentIndividual)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _documentIndividualSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _documentCorporation != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _documentCorporation
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _documentCorporationSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _registerDate.GetHashCode();
            hashCode = (hashCode * 397) ^ _registerDateSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _emailAddress != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_emailAddress)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _emailAddressSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _fixedTelephone != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_fixedTelephone)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _fixedTelephoneSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _mobileTelephone != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_mobileTelephone)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _mobileTelephoneSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_partner != null ? _partner.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _partnerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_address != null ? _address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _addressSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_neighborhood != null ? _neighborhood.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _neighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_city != null ? _city.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _citySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_region != null ? _region.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _regionSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Contact left, Contact right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Contact left, Contact right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The zip code
    /// </summary>
    private string _zipCode;

    /// <summary>
    /// The zip code set
    /// </summary>
    private bool _zipCodeSet;

    /// <summary>
    /// The code address
    /// </summary>
    private int _codeAddress;

    /// <summary>
    /// The code address set
    /// </summary>
    private bool _codeAddressSet;

    /// <summary>
    /// The address complement
    /// </summary>
    private string _addressComplement;

    /// <summary>
    /// The address complement set
    /// </summary>
    private bool _addressComplementSet;

    /// <summary>
    /// The address number
    /// </summary>
    private string _addressNumber;

    /// <summary>
    /// The address number set
    /// </summary>
    private bool _addressNumberSet;

    /// <summary>
    /// The code neighborhood
    /// </summary>
    private int _codeNeighborhood;

    /// <summary>
    /// The code neighborhood set
    /// </summary>
    private bool _codeNeighborhoodSet;

    /// <summary>
    /// The code city
    /// </summary>
    private int _codeCity;

    /// <summary>
    /// The code city set
    /// </summary>
    private bool _codeCitySet;

    /// <summary>
    /// The code region
    /// </summary>
    private int _codeRegion;

    /// <summary>
    /// The code region set
    /// </summary>
    private bool _codeRegionSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The active
    /// </summary>
    private bool _active;

    /// <summary>
    /// The active set
    /// </summary>
    private bool _activeSet;

    /// <summary>
    /// The document individual
    /// </summary>
    private string _documentIndividual;

    /// <summary>
    /// The document individual set
    /// </summary>
    private bool _documentIndividualSet;

    /// <summary>
    /// The document corporation
    /// </summary>
    private string _documentCorporation;

    /// <summary>
    /// The document corporation set
    /// </summary>
    private bool _documentCorporationSet;

    /// <summary>
    /// The register date
    /// </summary>
    private DateTime _registerDate;

    /// <summary>
    /// The register date set
    /// </summary>
    private bool _registerDateSet;

    /// <summary>
    /// The email address
    /// </summary>
    private string _emailAddress;

    /// <summary>
    /// The email address set
    /// </summary>
    private bool _emailAddressSet;

    /// <summary>
    /// The fixed telephone
    /// </summary>
    private string _fixedTelephone;

    /// <summary>
    /// The fixed telephone set
    /// </summary>
    private bool _fixedTelephoneSet;

    /// <summary>
    /// The mobile telephone
    /// </summary>
    private string _mobileTelephone;

    /// <summary>
    /// The mobile telephone set
    /// </summary>
    private bool _mobileTelephoneSet;

    /// <summary>
    /// The partner
    /// </summary>
    private Partner _partner;

    /// <summary>
    /// The partner set
    /// </summary>
    private bool _partnerSet;

    /// <summary>
    /// The address
    /// </summary>
    private Address _address;

    /// <summary>
    /// The address set
    /// </summary>
    private bool _addressSet;

    /// <summary>
    /// The neighborhood
    /// </summary>
    private Neighborhood _neighborhood;

    /// <summary>
    /// The neighborhood set
    /// </summary>
    private bool _neighborhoodSet;

    /// <summary>
    /// The city
    /// </summary>
    private City _city;

    /// <summary>
    /// The city set
    /// </summary>
    private bool _citySet;

    /// <summary>
    /// The region
    /// </summary>
    private Region _region;

    /// <summary>
    /// The region set
    /// </summary>
    private bool _regionSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityElement("CODCONTATO")]
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
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [EntityElement("CODPARC")]
    public int CodePartner
    {
        get => _codePartner;
        set
        {
            _codePartner = value;
            _codePartnerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    /// <value>The zip code.</value>
    [EntityElement("CEP")]
    public string ZipCode
    {
        get => _zipCode;
        set
        {
            _zipCode = value;
            _zipCodeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code address.
    /// </summary>
    /// <value>The code address.</value>
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
    /// Gets or sets the address complement.
    /// </summary>
    /// <value>The address complement.</value>
    [EntityElement("COMPLEMENTO")]
    [EntityCustomData(MaxLength = 30)]
    public string AddressComplement
    {
        get => _addressComplement;
        set
        {
            _addressComplement = value;
            _addressComplementSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the address number.
    /// </summary>
    /// <value>The address number.</value>
    [EntityElement("NUMEND")]
    public string AddressNumber
    {
        get => _addressNumber;
        set
        {
            _addressNumber = value;
            _addressNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code neighborhood.
    /// </summary>
    /// <value>The code neighborhood.</value>
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
    /// Gets or sets the code city.
    /// </summary>
    /// <value>The code city.</value>
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
    /// Gets or sets the code region.
    /// </summary>
    /// <value>The code region.</value>
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

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [EntityElement("NOMECONTATO")]
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

    /// <summary>
    /// Gets or sets the document individual.
    /// </summary>
    /// <value>The document individual.</value>
    [EntityElement("CPF")]
    public string DocumentIndividual
    {
        get => _documentIndividual;
        set
        {
            _documentIndividual = value;
            _documentIndividualSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the document corporation.
    /// </summary>
    /// <value>The document corporation.</value>
    [EntityElement("CNPJ")]
    public string DocumentCorporation
    {
        get => _documentCorporation;
        set
        {
            _documentCorporation = value;
            _documentCorporationSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the register date.
    /// </summary>
    /// <value>The register date.</value>
    [EntityElement("DTCAD")]
    public DateTime RegisterDate
    {
        get => _registerDate;
        set
        {
            _registerDate = value;
            _registerDateSet = true;
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
    /// Gets or sets the fixed telephone.
    /// </summary>
    /// <value>The fixed telephone.</value>
    [EntityElement("TELEFONE")]
    public string FixedTelephone
    {
        get => _fixedTelephone;
        set
        {
            _fixedTelephone = value;
            _fixedTelephoneSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the mobile telephone.
    /// </summary>
    /// <value>The mobile telephone.</value>
    [EntityElement("CELULAR")]
    public string MobileTelephone
    {
        get => _mobileTelephone;
        set
        {
            _mobileTelephone = value;
            _mobileTelephoneSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the partner.
    /// </summary>
    /// <value>The partner.</value>
    [EntityReference]
    public Partner Partner
    {
        get => _partner;
        set
        {
            _partner = value;
            _partnerSet = true;
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
    /// Gets or sets the region.
    /// </summary>
    /// <value>The region.</value>
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

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize zip code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeZipCode() => _zipCodeSet;

    /// <summary>
    /// Should the serialize code address.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeAddress() => _codeAddressSet;

    /// <summary>
    /// Should the serialize address complement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressComplement() => _addressComplementSet;

    /// <summary>
    /// Should the serialize address number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressNumber() => _addressNumberSet;

    /// <summary>
    /// Should the serialize code neighborhood.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeNeighborhood() => _codeNeighborhoodSet;

    /// <summary>
    /// Should the serialize code city.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCity() => _codeCitySet;

    /// <summary>
    /// Should the serialize code region.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeRegion() => _codeRegionSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    /// <summary>
    /// Should the serialize document individual.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocumentIndividual() => _documentIndividualSet;

    /// <summary>
    /// Should the serialize document corporation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocumentCorporation() => _documentCorporationSet;

    /// <summary>
    /// Should the serialize register date.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRegisterDate() => _registerDateSet;

    /// <summary>
    /// Should the serialize email address.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;

    /// <summary>
    /// Should the serialize fixed telephone.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFixedTelephone() => _fixedTelephoneSet;

    /// <summary>
    /// Should the serialize mobile telephone.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMobileTelephone() => _mobileTelephoneSet;

    /// <summary>
    /// Should the serialize partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    /// <summary>
    /// Should the serialize address.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddress() => _addressSet;

    /// <summary>
    /// Should the serialize neighborhood.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNeighborhood() => _neighborhoodSet;

    /// <summary>
    /// Should the serialize city.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCity() => _citySet;

    /// <summary>
    /// Should the serialize region.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRegion() => _regionSet;
}
