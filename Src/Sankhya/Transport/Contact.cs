using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("Contato")]
public class Contact : IEntity, IEquatable<Contact>
{
    public bool Equals(Contact other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet == other._codeSet
                && _codePartner == other._codePartner
                && _codePartnerSet == other._codePartnerSet
                && string.Equals(_zipCode, other._zipCode, StringComparison.OrdinalIgnoreCase)
                && _zipCodeSet == other._zipCodeSet
                && _codeAddress == other._codeAddress
                && _codeAddressSet == other._codeAddressSet
                && string.Equals(
                    _addressComplement,
                    other._addressComplement,
                    StringComparison.OrdinalIgnoreCase
                )
                && _addressComplementSet == other._addressComplementSet
                && string.Equals(
                    _addressNumber,
                    other._addressNumber,
                    StringComparison.OrdinalIgnoreCase
                )
                && _addressNumberSet == other._addressNumberSet
                && _codeNeighborhood == other._codeNeighborhood
                && _codeNeighborhoodSet == other._codeNeighborhoodSet
                && _codeCity == other._codeCity
                && _codeCitySet == other._codeCitySet
                && _codeRegion == other._codeRegion
                && _codeRegionSet == other._codeRegionSet
                && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
                && _nameSet == other._nameSet
                && _active == other._active
                && _activeSet == other._activeSet
                && string.Equals(
                    _documentIndividual,
                    other._documentIndividual,
                    StringComparison.OrdinalIgnoreCase
                )
                && _documentIndividualSet == other._documentIndividualSet
                && string.Equals(
                    _documentCorporation,
                    other._documentCorporation,
                    StringComparison.OrdinalIgnoreCase
                )
                && _documentCorporationSet == other._documentCorporationSet
                && _registerDate.Equals(other._registerDate)
                && _registerDateSet == other._registerDateSet
                && string.Equals(
                    _emailAddress,
                    other._emailAddress,
                    StringComparison.OrdinalIgnoreCase
                )
                && _emailAddressSet == other._emailAddressSet
                && string.Equals(
                    _fixedTelephone,
                    other._fixedTelephone,
                    StringComparison.OrdinalIgnoreCase
                )
                && _fixedTelephoneSet == other._fixedTelephoneSet
                && string.Equals(
                    _mobileTelephone,
                    other._mobileTelephone,
                    StringComparison.OrdinalIgnoreCase
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
                && _regionSet == other._regionSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || (obj is Contact contact && Equals(contact));
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

    public static bool operator ==(Contact left, Contact right) => Equals(left, right);

    public static bool operator !=(Contact left, Contact right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private string _zipCode;

    private bool _zipCodeSet;

    private int _codeAddress;

    private bool _codeAddressSet;

    private string _addressComplement;

    private bool _addressComplementSet;

    private string _addressNumber;

    private bool _addressNumberSet;

    private int _codeNeighborhood;

    private bool _codeNeighborhoodSet;

    private int _codeCity;

    private bool _codeCitySet;

    private int _codeRegion;

    private bool _codeRegionSet;

    private string _name;

    private bool _nameSet;

    private bool _active;

    private bool _activeSet;

    private string _documentIndividual;

    private bool _documentIndividualSet;

    private string _documentCorporation;

    private bool _documentCorporationSet;

    private DateTime _registerDate;

    private bool _registerDateSet;

    private string _emailAddress;

    private bool _emailAddressSet;

    private string _fixedTelephone;

    private bool _fixedTelephoneSet;

    private string _mobileTelephone;

    private bool _mobileTelephoneSet;

    private Partner _partner;

    private bool _partnerSet;

    private Address _address;

    private bool _addressSet;

    private Neighborhood _neighborhood;

    private bool _neighborhoodSet;

    private City _city;

    private bool _citySet;

    private Region _region;

    private bool _regionSet;

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
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeZipCode() => _zipCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeAddress() => _codeAddressSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressComplement() => _addressComplementSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressNumber() => _addressNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeNeighborhood() => _codeNeighborhoodSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeCity() => _codeCitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeRegion() => _codeRegionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeActive() => _activeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocumentIndividual() => _documentIndividualSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocumentCorporation() => _documentCorporationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRegisterDate() => _registerDateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFixedTelephone() => _fixedTelephoneSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMobileTelephone() => _mobileTelephoneSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePartner() => _partnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddress() => _addressSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNeighborhood() => _neighborhoodSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCity() => _citySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRegion() => _regionSet;
}
