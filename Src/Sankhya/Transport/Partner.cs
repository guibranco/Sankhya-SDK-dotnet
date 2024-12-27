using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Serializer]
[Entity("Parceiro")]
public class Partner : IEntity, IEquatable<Partner>
{
    public bool Equals(Partner other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _code == other._code
            && _codeSet == other._codeSet
            && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(_companyName, other._companyName, StringComparison.OrdinalIgnoreCase)
            && _companyNameSet == other._companyNameSet
            && _fiscalType == other._fiscalType
            && _fiscalTypeSet == other._fiscalTypeSet
            && _fiscalClassification == other._fiscalClassification
            && _fiscalClassificationSet == other._fiscalClassificationSet
            && string.Equals(_emailAddress, other._emailAddress, StringComparison.OrdinalIgnoreCase)
            && _emailAddressSet == other._emailAddressSet
            && string.Equals(
                _emailAddressFiscalInvoice,
                other._emailAddressFiscalInvoice,
                StringComparison.OrdinalIgnoreCase
            )
            && _emailAddressFiscalInvoiceSet == other._emailAddressFiscalInvoiceSet
            && _isActive == other._isActive
            && _isActiveSet == other._isActiveSet
            && _isClient == other._isClient
            && _isClientSet == other._isClientSet
            && _isSeller == other._isSeller
            && _isSellerSet == other._isSellerSet
            && _isUser == other._isUser
            && _isUserSet == other._isUserSet
            && _isSupplier == other._isSupplier
            && _isSupplierSet == other._isSupplierSet
            && string.Equals(_document, other._document, StringComparison.OrdinalIgnoreCase)
            && _documentSet == other._documentSet
            && string.Equals(_identity, other._identity, StringComparison.OrdinalIgnoreCase)
            && _identitySet == other._identitySet
            && string.Equals(
                _stateInscription,
                other._stateInscription,
                StringComparison.OrdinalIgnoreCase
            )
            && _stateInscriptionSet == other._stateInscriptionSet
            && string.Equals(_zipCode, other._zipCode, StringComparison.OrdinalIgnoreCase)
            && _zipCodeSet == other._zipCodeSet
            && _codeAddress == other._codeAddress
            && _codeAddressSet == other._codeAddressSet
            && string.Equals(
                _addressNumber,
                other._addressNumber,
                StringComparison.OrdinalIgnoreCase
            )
            && _addressNumberSet == other._addressNumberSet
            && string.Equals(
                _addressComplement,
                other._addressComplement,
                StringComparison.OrdinalIgnoreCase
            )
            && _addressComplementSet == other._addressComplementSet
            && _codeNeighborhood == other._codeNeighborhood
            && _codeNeighborhoodSet == other._codeNeighborhoodSet
            && _codeCity == other._codeCity
            && _codeCitySet == other._codeCitySet
            && _codeRegion == other._codeRegion
            && _codeRegionSet == other._codeRegionSet
            && string.Equals(_telephone, other._telephone, StringComparison.OrdinalIgnoreCase)
            && _telephoneSet == other._telephoneSet
            && string.Equals(
                _telephoneExtensionLine,
                other._telephoneExtensionLine,
                StringComparison.OrdinalIgnoreCase
            )
            && _telephoneExtensionLineSet == other._telephoneExtensionLineSet
            && string.Equals(_mobilePhone, other._mobilePhone, StringComparison.OrdinalIgnoreCase)
            && _mobilePhoneSet == other._mobilePhoneSet
            && _dateCreated.Equals(other._dateCreated)
            && _dateCreatedSet == other._dateCreatedSet
            && _dateChanged.Equals(other._dateChanged)
            && _dateChangedSet == other._dateChangedSet
            && _sendFiscalInvoiceByEmail == other._sendFiscalInvoiceByEmail
            && _sendFiscalInvoiceByEmailSet == other._sendFiscalInvoiceByEmailSet
            && string.Equals(
                _authorizationGroup,
                other._authorizationGroup,
                StringComparison.OrdinalIgnoreCase
            )
            && _authorizationGroupSet == other._authorizationGroupSet
            && string.Equals(_latitude, other._latitude, StringComparison.OrdinalIgnoreCase)
            && _latitudeSet == other._latitudeSet
            && string.Equals(_longitude, other._longitude, StringComparison.OrdinalIgnoreCase)
            && _longitudeSet == other._longitudeSet
            && string.Equals(_notes, other._notes, StringComparison.OrdinalIgnoreCase)
            && _notesSet == other._notesSet
            && Equals(_address, other._address)
            && _addressSet == other._addressSet
            && Equals(_neighborhood, other._neighborhood)
            && _neighborhoodSet == other._neighborhoodSet
            && Equals(_city, other._city)
            && _citySet == other._citySet
            && Equals(_region, other._region)
            && _regionSet == other._regionSet
            && Equals(_complement, other._complement)
            && _complementSet == other._complementSet;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Partner)obj);
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
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _companyName != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_companyName)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _companyNameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_fiscalType;
            hashCode = (hashCode * 397) ^ _fiscalTypeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_fiscalClassification;
            hashCode = (hashCode * 397) ^ _fiscalClassificationSet.GetHashCode();
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
                    _emailAddressFiscalInvoice != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _emailAddressFiscalInvoice
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _emailAddressFiscalInvoiceSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActive.GetHashCode();
            hashCode = (hashCode * 397) ^ _isActiveSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isClient.GetHashCode();
            hashCode = (hashCode * 397) ^ _isClientSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSeller.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSellerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isUser.GetHashCode();
            hashCode = (hashCode * 397) ^ _isUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSupplier.GetHashCode();
            hashCode = (hashCode * 397) ^ _isSupplierSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _document != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_document)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _documentSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _identity != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_identity)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _identitySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _stateInscription != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_stateInscription)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _stateInscriptionSet.GetHashCode();
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
                    _addressNumber != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_addressNumber)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressNumberSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _addressComplement != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_addressComplement)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _addressComplementSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeNeighborhood;
            hashCode = (hashCode * 397) ^ _codeNeighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCity;
            hashCode = (hashCode * 397) ^ _codeCitySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRegion;
            hashCode = (hashCode * 397) ^ _codeRegionSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _telephone != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_telephone)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _telephoneSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _telephoneExtensionLine != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _telephoneExtensionLine
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _telephoneExtensionLineSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _mobilePhone != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_mobilePhone)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _mobilePhoneSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateCreated.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateCreatedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _sendFiscalInvoiceByEmail.GetHashCode();
            hashCode = (hashCode * 397) ^ _sendFiscalInvoiceByEmailSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _authorizationGroup != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_authorizationGroup)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _authorizationGroupSet.GetHashCode();
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
            hashCode =
                (hashCode * 397)
                ^ (
                    _notes != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_notes)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _notesSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_address != null ? _address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _addressSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_neighborhood != null ? _neighborhood.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _neighborhoodSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_city != null ? _city.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _citySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_region != null ? _region.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _regionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_complement != null ? _complement.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _complementSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(Partner left, Partner right) => Equals(left, right);

    public static bool operator !=(Partner left, Partner right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _name;

    private bool _nameSet;

    private string _companyName;

    private bool _companyNameSet;

    private FiscalPersonType _fiscalType;

    private bool _fiscalTypeSet;

    private FiscalClassification _fiscalClassification;

    private bool _fiscalClassificationSet;

    private string _emailAddress;

    private bool _emailAddressSet;

    private string _emailAddressFiscalInvoice;

    private bool _emailAddressFiscalInvoiceSet;

    private bool _isActive;

    private bool _isActiveSet;

    private bool _isClient;

    private bool _isClientSet;

    private bool _isSeller;

    private bool _isSellerSet;

    private bool _isUser;

    private bool _isUserSet;

    private bool _isSupplier;

    private bool _isSupplierSet;

    private string _document;

    private bool _documentSet;

    private string _identity;

    private bool _identitySet;

    private string _stateInscription;

    private bool _stateInscriptionSet;

    private string _zipCode;

    private bool _zipCodeSet;

    private int _codeAddress;

    private bool _codeAddressSet;

    private string _addressNumber;

    private bool _addressNumberSet;

    private string _addressComplement;

    private bool _addressComplementSet;

    private int _codeNeighborhood;

    private bool _codeNeighborhoodSet;

    private int _codeCity;

    private bool _codeCitySet;

    private int _codeRegion;

    private bool _codeRegionSet;

    private string _telephone;

    private bool _telephoneSet;

    private string _telephoneExtensionLine;

    private bool _telephoneExtensionLineSet;

    private string _mobilePhone;

    private bool _mobilePhoneSet;

    private DateTime _dateCreated;

    private bool _dateCreatedSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    private bool _sendFiscalInvoiceByEmail;

    private bool _sendFiscalInvoiceByEmailSet;

    private string _authorizationGroup;

    private bool _authorizationGroupSet;

    private string _latitude;

    private bool _latitudeSet;

    private string _longitude;

    private bool _longitudeSet;

    private string _notes;

    private bool _notesSet;

    private Address _address;

    private bool _addressSet;

    private Neighborhood _neighborhood;

    private bool _neighborhoodSet;

    private City _city;

    private bool _citySet;

    private Region _region;

    private bool _regionSet;

    private PartnerComplement _complement;

    private bool _complementSet;

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

    [EntityElement("NOMEPARC")]
    [Localizable(false)]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [EntityElement("RAZAOSOCIAL")]
    public string CompanyName
    {
        get => _companyName;
        set
        {
            _companyName = value;
            _companyNameSet = true;
        }
    }

    [EntityIgnore]
    public FiscalPersonType FiscalType
    {
        get => _fiscalType;
        set
        {
            _fiscalType = value;
            _fiscalTypeSet = true;
        }
    }

    [EntityElement("TIPPESSOA")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string FiscalTypeInternal
    {
        get => _fiscalType.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _fiscalType = EnumExtensions.GetEnumByInternalValueAttribute<FiscalPersonType>(value);
            _fiscalTypeSet = true;
        }
    }

    [EntityIgnore]
    public FiscalClassification FiscalClassification
    {
        get => _fiscalClassification;
        set
        {
            _fiscalClassification = value;
            _fiscalClassificationSet = true;
        }
    }

    [EntityElement("CLASSIFICMS")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string FiscalClassificationInternal
    {
        get => _fiscalClassification.GetInternalValue();
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _fiscalClassification =
                EnumExtensions.GetEnumByInternalValueAttribute<FiscalClassification>(value);
            _fiscalClassificationSet = true;
        }
    }

    [EntityElement("EMAIL")]
    [Localizable(false)]
    public string EmailAddress
    {
        get => _emailAddress;
        set
        {
            _emailAddress = value;
            _emailAddressSet = true;
        }
    }

    [EntityElement("EMAILNFE")]
    [Localizable(false)]
    public string EmailAddressFiscalInvoice
    {
        get => _emailAddressFiscalInvoice;
        set
        {
            _emailAddressFiscalInvoice = value;
            _emailAddressFiscalInvoiceSet = true;
        }
    }

    [EntityIgnore]
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            _isActiveSet = true;
        }
    }

    [EntityElement("ATIVO")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsActiveInternal
    {
        get => _isActive.ToString(@"S", @"N");
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            _isActive = value.ToBoolean();
            _isActiveSet = true;
        }
    }

    [EntityIgnore]
    public bool IsClient
    {
        get => _isClient;
        set
        {
            _isClient = value;
            _isClientSet = true;
        }
    }

    [EntityElement("CLIENTE")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsClientInternal
    {
        get => _isClient.ToString(@"S", @"N");
        set
        {
            _isClient = value.ToBoolean();
            _isClientSet = true;
        }
    }

    [EntityIgnore]
    public bool IsSeller
    {
        get => _isSeller;
        set
        {
            _isSeller = value;
            _isSellerSet = true;
        }
    }

    [EntityElement("VENDEDOR")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsSellerInternal
    {
        get => _isSeller.ToString(@"S", @"N");
        set
        {
            _isSeller = value.ToBoolean();
            _isSellerSet = true;
        }
    }

    [EntityIgnore]
    public bool IsUser
    {
        get => _isUser;
        set
        {
            _isUser = value;
            _isUserSet = true;
        }
    }

    [EntityElement("USUARIO")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsUserInternal
    {
        get => _isUser.ToString(@"S", @"N");
        set
        {
            _isUser = value.ToBoolean();
            _isUserSet = true;
        }
    }

    [EntityIgnore]
    public bool IsSupplier
    {
        get => _isSupplier;
        set
        {
            _isSupplier = value;
            _isSupplierSet = true;
        }
    }

    [EntityElement("FORNECEDOR")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsSupplierInternal
    {
        get => _isSupplier.ToString(@"S", @"N");
        set
        {
            _isSupplier = value.ToBoolean();
            _isSupplierSet = true;
        }
    }

    [EntityElement("CGC_CPF", true)]
    public string Document
    {
        get => _document;
        set
        {
            _document = value;
            _documentSet = true;
        }
    }

    [EntityElement("IDENTINSCESTAD")]
    public string Identity
    {
        get => _identity;
        set
        {
            _identity = value;
            _identitySet = true;
        }
    }

    [EntityElement("INSCESTADNAUF")]
    public string StateInscription
    {
        get => _stateInscription;
        set
        {
            _stateInscription = value;
            _stateInscriptionSet = true;
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

    [EntityElement("NUMEND")]
    [Localizable(false)]
    public string AddressNumber
    {
        get => _addressNumber;
        set
        {
            _addressNumber = value;
            _addressNumberSet = true;
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

    [EntityElement("TELEFONE")]
    public string Telephone
    {
        get => _telephone;
        set
        {
            _telephone = value;
            _telephoneSet = true;
        }
    }

    [EntityElement("RAMAL")]
    public string TelephoneExtensionLine
    {
        get => _telephoneExtensionLine;
        set
        {
            _telephoneExtensionLine = value;
            _telephoneExtensionLineSet = true;
        }
    }

    [EntityElement("FAX")]
    public string MobilePhone
    {
        get => _mobilePhone;
        set
        {
            _mobilePhone = value;
            _mobilePhoneSet = true;
        }
    }

    [EntityElement("DTCAD")]
    public DateTime DateCreated
    {
        get => _dateCreated;
        set
        {
            _dateCreated = value;
            _dateCreatedSet = true;
        }
    }

    [EntityElement("DTALTER")]
    public DateTime DateChanged
    {
        get => _dateChanged;
        set
        {
            _dateChanged = value;
            _dateChangedSet = true;
        }
    }

    [EntityIgnore]
    public bool SendFiscalInvoiceByEmail
    {
        get => _sendFiscalInvoiceByEmail;
        set
        {
            _sendFiscalInvoiceByEmail = value;
            _sendFiscalInvoiceByEmailSet = true;
        }
    }

    [EntityElement("EMAILDANFE")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SendFiscalInvoiceByEmailInternal
    {
        get => _sendFiscalInvoiceByEmail.ToString(@"S", @"N");
        set
        {
            _sendFiscalInvoiceByEmail = value.ToBoolean();
            _sendFiscalInvoiceByEmailSet = true;
        }
    }

    [EntityElement("GRUPOAUTOR")]
    public string AuthorizationGroup
    {
        get => _authorizationGroup;
        set
        {
            _authorizationGroup = value;
            _authorizationGroupSet = true;
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

    [EntityElement("OBSERVACOES")]
    public string Notes
    {
        get => _notes;
        set
        {
            _notes = value;
            _notesSet = true;
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

    [EntityReference]
    public PartnerComplement Complement
    {
        get => _complement;
        set
        {
            _complement = value;
            _complementSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCompanyName() => _companyNameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalType() => _fiscalTypeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalClassification() => _fiscalClassificationSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddressFiscalInvoice() => _emailAddressFiscalInvoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsClient() => _isClientSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSeller() => _isSellerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsUser() => _isUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSupplier() => _isSupplierSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocument() => _documentSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIdentity() => _identitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStateInscription() => _stateInscriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeZipCode() => _zipCodeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeAddress() => _codeAddressSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressNumber() => _addressNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressComplement() => _addressComplementSet;

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
    public bool ShouldSerializeTelephone() => _telephoneSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTelephoneExtensionLine() => _telephoneExtensionLineSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMobilePhone() => _mobilePhoneSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateCreated() => _dateCreatedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSendFiscalInvoiceByEmail() => _sendFiscalInvoiceByEmailSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAuthorizationGroup() => _authorizationGroupSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLatitude() => _latitudeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLongitude() => _longitudeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNotes() => _notesSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeComplement() => _complementSet;
}
