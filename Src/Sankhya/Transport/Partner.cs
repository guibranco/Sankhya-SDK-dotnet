// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Partner.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Transport;

using System;
using System.ComponentModel;
using CrispyWaffle.Extensions;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;
using Sankhya.Enums;

/// <summary>
/// Class Partner.
/// </summary>
/// <seealso cref="IEntity" />
[Serializer]
[Entity("Parceiro")]
public class Partner : IEntity, IEquatable<Partner>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once CyclomaticComplexity
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
            && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(
                _companyName,
                other._companyName,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _companyNameSet == other._companyNameSet
            && _fiscalType == other._fiscalType
            && _fiscalTypeSet == other._fiscalTypeSet
            && _fiscalClassification == other._fiscalClassification
            && _fiscalClassificationSet == other._fiscalClassificationSet
            && string.Equals(
                _emailAddress,
                other._emailAddress,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _emailAddressSet == other._emailAddressSet
            && string.Equals(
                _emailAddressFiscalInvoice,
                other._emailAddressFiscalInvoice,
                StringComparison.InvariantCultureIgnoreCase
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
            && string.Equals(
                _document,
                other._document,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _documentSet == other._documentSet
            && string.Equals(
                _identity,
                other._identity,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _identitySet == other._identitySet
            && string.Equals(
                _stateInscription,
                other._stateInscription,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _stateInscriptionSet == other._stateInscriptionSet
            && string.Equals(_zipCode, other._zipCode, StringComparison.InvariantCultureIgnoreCase)
            && _zipCodeSet == other._zipCodeSet
            && _codeAddress == other._codeAddress
            && _codeAddressSet == other._codeAddressSet
            && string.Equals(
                _addressNumber,
                other._addressNumber,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _addressNumberSet == other._addressNumberSet
            && string.Equals(
                _addressComplement,
                other._addressComplement,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _addressComplementSet == other._addressComplementSet
            && _codeNeighborhood == other._codeNeighborhood
            && _codeNeighborhoodSet == other._codeNeighborhoodSet
            && _codeCity == other._codeCity
            && _codeCitySet == other._codeCitySet
            && _codeRegion == other._codeRegion
            && _codeRegionSet == other._codeRegionSet
            && string.Equals(
                _telephone,
                other._telephone,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _telephoneSet == other._telephoneSet
            && string.Equals(
                _telephoneExtensionLine,
                other._telephoneExtensionLine,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _telephoneExtensionLineSet == other._telephoneExtensionLineSet
            && string.Equals(
                _mobilePhone,
                other._mobilePhone,
                StringComparison.InvariantCultureIgnoreCase
            )
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
                StringComparison.InvariantCultureIgnoreCase
            )
            && _authorizationGroupSet == other._authorizationGroupSet
            && string.Equals(
                _latitude,
                other._latitude,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _latitudeSet == other._latitudeSet
            && string.Equals(
                _longitude,
                other._longitude,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _longitudeSet == other._longitudeSet
            && string.Equals(_notes, other._notes, StringComparison.InvariantCultureIgnoreCase)
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

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Partner)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    // ReSharper disable once FunctionComplexityOverflow
    // ReSharper disable once CyclomaticComplexity
    // ReSharper disable once MethodTooLong
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Partner left, Partner right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Partner left, Partner right) => !Equals(left, right);

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
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The company name
    /// </summary>
    private string _companyName;

    /// <summary>
    /// The company name set
    /// </summary>
    private bool _companyNameSet;

    /// <summary>
    /// The fiscal type
    /// </summary>
    private FiscalPersonType _fiscalType;

    /// <summary>
    /// The fiscal type set
    /// </summary>
    private bool _fiscalTypeSet;

    /// <summary>
    /// The fiscal classification
    /// </summary>
    private FiscalClassification _fiscalClassification;

    /// <summary>
    /// The fiscal classification set
    /// </summary>
    private bool _fiscalClassificationSet;

    /// <summary>
    /// The email address
    /// </summary>
    private string _emailAddress;

    /// <summary>
    /// The email address set
    /// </summary>
    private bool _emailAddressSet;

    /// <summary>
    /// The email address fiscal invoice
    /// </summary>
    private string _emailAddressFiscalInvoice;

    /// <summary>
    /// The email address fiscal invoice set
    /// </summary>
    private bool _emailAddressFiscalInvoiceSet;

    /// <summary>
    /// The is active
    /// </summary>
    private bool _isActive;

    /// <summary>
    /// The is active set
    /// </summary>
    private bool _isActiveSet;

    /// <summary>
    /// The is client
    /// </summary>
    private bool _isClient;

    /// <summary>
    /// The is client set
    /// </summary>
    private bool _isClientSet;

    /// <summary>
    /// The is seller
    /// </summary>
    private bool _isSeller;

    /// <summary>
    /// The is seller set
    /// </summary>
    private bool _isSellerSet;

    /// <summary>
    /// The is user
    /// </summary>
    private bool _isUser;

    /// <summary>
    /// The is user set
    /// </summary>
    private bool _isUserSet;

    /// <summary>
    /// The is supplier
    /// </summary>
    private bool _isSupplier;

    /// <summary>
    /// The is supplier set
    /// </summary>
    private bool _isSupplierSet;

    /// <summary>
    /// The document
    /// </summary>
    private string _document;

    /// <summary>
    /// The document set
    /// </summary>
    private bool _documentSet;

    /// <summary>
    /// The identity
    /// </summary>
    private string _identity;

    /// <summary>
    /// The identity set
    /// </summary>
    private bool _identitySet;

    /// <summary>
    /// The state inscription
    /// </summary>
    private string _stateInscription;

    /// <summary>
    /// The state inscription set
    /// </summary>
    private bool _stateInscriptionSet;

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
    /// The address number
    /// </summary>
    private string _addressNumber;

    /// <summary>
    /// The address number set
    /// </summary>
    private bool _addressNumberSet;

    /// <summary>
    /// The address complement
    /// </summary>
    private string _addressComplement;

    /// <summary>
    /// The address complement set
    /// </summary>
    private bool _addressComplementSet;

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
    /// The telephone
    /// </summary>
    private string _telephone;

    /// <summary>
    /// The telephone set
    /// </summary>
    private bool _telephoneSet;

    /// <summary>
    /// The telephone extension line
    /// </summary>
    private string _telephoneExtensionLine;

    /// <summary>
    /// The telephone extension line set
    /// </summary>
    private bool _telephoneExtensionLineSet;

    /// <summary>
    /// The mobile phone
    /// </summary>
    private string _mobilePhone;

    /// <summary>
    /// The mobile phone set
    /// </summary>
    private bool _mobilePhoneSet;

    /// <summary>
    /// The date created
    /// </summary>
    private DateTime _dateCreated;

    /// <summary>
    /// The date created set
    /// </summary>
    private bool _dateCreatedSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// The send fiscal invoice by email
    /// </summary>
    private bool _sendFiscalInvoiceByEmail;

    /// <summary>
    /// The send fiscal invoice by email set
    /// </summary>
    private bool _sendFiscalInvoiceByEmailSet;

    /// <summary>
    /// The authorization group
    /// </summary>
    private string _authorizationGroup;

    /// <summary>
    /// The authorization group set
    /// </summary>
    private bool _authorizationGroupSet;

    /// <summary>
    /// The latitude
    /// </summary>
    private string _latitude;

    /// <summary>
    /// The latitude set
    /// </summary>
    private bool _latitudeSet;

    /// <summary>
    /// The longitude
    /// </summary>
    private string _longitude;

    /// <summary>
    /// The longitude set
    /// </summary>
    private bool _longitudeSet;

    /// <summary>
    /// The notes
    /// </summary>
    private string _notes;

    /// <summary>
    /// The notes set
    /// </summary>
    private bool _notesSet;

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
    /// The complement
    /// </summary>
    private PartnerComplement _complement;

    /// <summary>
    /// The complement set
    /// </summary>
    private bool _complementSet;

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
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
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

    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    /// <value>The name of the company.</value>
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

    /// <summary>
    /// Gets or sets the type of the fiscal.
    /// </summary>
    /// <value>The type of the fiscal.</value>
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

    /// <summary>
    /// Gets or sets the fiscal type internal.
    /// </summary>
    /// <value>The fiscal type internal.</value>
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

    /// <summary>
    /// Gets or sets the fiscal classification.
    /// </summary>
    /// <value>The fiscal classification.</value>
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

    /// <summary>
    /// Gets or sets the fiscal classification internal.
    /// </summary>
    /// <value>The fiscal classification internal.</value>
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

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <value>The email address.</value>
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

    /// <summary>
    /// Gets or sets the email address fiscal invoice.
    /// </summary>
    /// <value>The email address fiscal invoice.</value>
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

    /// <summary>
    /// Gets or sets the is active.
    /// </summary>
    /// <value>The is active.</value>
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

    /// <summary>
    /// Gets or sets the is active internal.
    /// </summary>
    /// <value>The is active internal.</value>
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

    /// <summary>
    /// Gets or sets the is client.
    /// </summary>
    /// <value>The is client.</value>
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

    /// <summary>
    /// Gets or sets the is client internal.
    /// </summary>
    /// <value>The is client internal.</value>
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

    /// <summary>
    /// Gets or sets the is seller.
    /// </summary>
    /// <value>The is seller.</value>
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

    /// <summary>
    /// Gets or sets the is seller internal.
    /// </summary>
    /// <value>The is seller internal.</value>
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

    /// <summary>
    /// Gets or sets the is user.
    /// </summary>
    /// <value>The is user.</value>
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

    /// <summary>
    /// Gets or sets the is user internal.
    /// </summary>
    /// <value>The is user internal.</value>
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

    /// <summary>
    /// Gets or sets the is supplier.
    /// </summary>
    /// <value>The is supplier.</value>
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

    /// <summary>
    /// Gets or sets the is supplier internal.
    /// </summary>
    /// <value>The is supplier internal.</value>
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

    /// <summary>
    /// Gets or sets the document.
    /// </summary>
    /// <value>The document.</value>
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

    /// <summary>
    /// Gets or sets the identity.
    /// </summary>
    /// <value>The identity.</value>
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

    /// <summary>
    /// Gets or sets the state inscription.
    /// </summary>
    /// <value>The state inscription.</value>
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
    /// Gets or sets the address number.
    /// </summary>
    /// <value>The address number.</value>
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
    /// Gets or sets the telephone.
    /// </summary>
    /// <value>The telephone.</value>
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

    /// <summary>
    /// Gets or sets the telephone extension line.
    /// </summary>
    /// <value>The telephone extension line.</value>
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

    /// <summary>
    /// Gets or sets the mobile phone.
    /// </summary>
    /// <value>The mobile phone.</value>
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

    /// <summary>
    /// Gets or sets the date created.
    /// </summary>
    /// <value>The date created.</value>
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

    /// <summary>
    /// Gets or sets the date changed.
    /// </summary>
    /// <value>The date changed.</value>
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

    /// <summary>
    /// Gets or sets the send fiscal invoice by email.
    /// </summary>
    /// <value>The send fiscal invoice by email.</value>
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

    /// <summary>
    /// Gets or sets the send fiscal invoice by email internal.
    /// </summary>
    /// <value>The send fiscal invoice by email internal.</value>
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

    /// <summary>
    /// Gets or sets the authorization group.
    /// </summary>
    /// <value>The authorization group.</value>
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

    /// <summary>
    /// Gets or sets the latitude
    /// </summary>
    /// <value>The latitude.</value>
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

    /// <summary>
    /// Gets or sets the longitude
    /// </summary>
    /// <value>The longitude.</value>
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

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
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
    /// Gets or sets the complement.
    /// </summary>
    /// <value>The complement.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the name of the serialize company.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCompanyName() => _companyNameSet;

    /// <summary>
    /// Should the type of the serialize fiscal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalType() => _fiscalTypeSet;

    /// <summary>
    /// Should the serialize fiscal classification.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFiscalClassification() => _fiscalClassificationSet;

    /// <summary>
    /// Should the serialize email address.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddress() => _emailAddressSet;

    /// <summary>
    /// Should the serialize email address fiscal invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmailAddressFiscalInvoice() => _emailAddressFiscalInvoiceSet;

    /// <summary>
    /// Should the serialize is active.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsActive() => _isActiveSet;

    /// <summary>
    /// Should the serialize is client.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsClient() => _isClientSet;

    /// <summary>
    /// Should the serialize is seller.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSeller() => _isSellerSet;

    /// <summary>
    /// Should the serialize is user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsUser() => _isUserSet;

    /// <summary>
    /// Should the serialize is supplier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsSupplier() => _isSupplierSet;

    /// <summary>
    /// Should the serialize document.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDocument() => _documentSet;

    /// <summary>
    /// Should the serialize identity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIdentity() => _identitySet;

    /// <summary>
    /// Should the serialize state inscription.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStateInscription() => _stateInscriptionSet;

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
    /// Should the serialize address number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressNumber() => _addressNumberSet;

    /// <summary>
    /// Should the serialize address complement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAddressComplement() => _addressComplementSet;

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
    /// Should the serialize telephone.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTelephone() => _telephoneSet;

    /// <summary>
    /// Should the serialize telephone extension line.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTelephoneExtensionLine() => _telephoneExtensionLineSet;

    /// <summary>
    /// Should the serialize mobile phone.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMobilePhone() => _mobilePhoneSet;

    /// <summary>
    /// Should the serialize date created.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateCreated() => _dateCreatedSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDateChanged() => _dateChangedSet;

    /// <summary>
    /// Should the serialize send fiscal invoice by email.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSendFiscalInvoiceByEmail() => _sendFiscalInvoiceByEmailSet;

    /// <summary>
    /// Should the serialize authorization group.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAuthorizationGroup() => _authorizationGroupSet;

    /// <summary>
    /// The should serialize latitude serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLatitude() => _latitudeSet;

    /// <summary>
    /// The should serialize longitude serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLongitude() => _longitudeSet;

    /// <summary>
    /// The should serialize notes serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNotes() => _notesSet;

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

    /// <summary>
    /// Should the serialize complement.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeComplement() => _complementSet;

    #endregion
}
