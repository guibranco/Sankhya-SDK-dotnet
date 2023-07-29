// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="State.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Transport;

using CrispyWaffle.Serialization;

using System;
using Sankhya.Attributes;

/// <summary>
/// Class State. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Serializer]
[Entity("UnidadeFederativa")]
public class State : IEntity, IEquatable<State>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(State other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || _code == other._code
                && _codeSet.Equals(other._codeSet)
                && string.Equals(_initials, other._initials)
                && _initialsSet.Equals(other._initialsSet)
                && string.Equals(_name, other._name)
                && _nameSet.Equals(other._nameSet)
                && _codeCountry == other._codeCountry
                && _codeCountrySet.Equals(other._codeCountrySet)
                && _codePartnerSecretaryOfStateRevenue == other._codePartnerSecretaryOfStateRevenue
                && _codePartnerSecretaryOfStateRevenueSet.Equals(
                    other._codePartnerSecretaryOfStateRevenueSet
                )
                && _codeIBGE == other._codeIBGE
                && _codeIBGESet.Equals(other._codeIBGESet)
                && _codeRevenue == other._codeRevenue
                && _codeRevenueSet.Equals(other._codeRevenueSet)
                && _codeRevenueDetailing == other._codeRevenueDetailing
                && _codeRevenueDetailingSet.Equals(other._codeRevenueDetailingSet)
                && _codeProduct == other._codeProduct
                && _codeProductSet.Equals(other._codeProductSet)
                && string.Equals(_agreementProtocol, other._agreementProtocol)
                && _agreementProtocolSet.Equals(other._agreementProtocolSet);
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

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        var a = obj as State;
        return a != null && Equals(a);
    }

    /// <summary>
    /// Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Object" />.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _code;
            hashCode = (hashCode * 397) ^ _codeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_initials?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _initialsSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_name?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCountry;
            hashCode = (hashCode * 397) ^ _codeCountrySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartnerSecretaryOfStateRevenue;
            hashCode = (hashCode * 397) ^ _codePartnerSecretaryOfStateRevenueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeIBGE;
            hashCode = (hashCode * 397) ^ _codeIBGESet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRevenue;
            hashCode = (hashCode * 397) ^ _codeRevenueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeRevenueDetailing;
            hashCode = (hashCode * 397) ^ _codeRevenueDetailingSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeProduct;
            hashCode = (hashCode * 397) ^ _codeProductSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_agreementProtocol?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _agreementProtocolSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(State left, State right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(State left, State right) => !Equals(left, right);

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
    /// The initials
    /// </summary>
    private string _initials;

    /// <summary>
    /// The initials set
    /// </summary>
    private bool _initialsSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The code country
    /// </summary>
    private int _codeCountry;

    /// <summary>
    /// The code country set
    /// </summary>
    private bool _codeCountrySet;

    /// <summary>
    /// The code partner secretary of state revenue
    /// </summary>
    private int _codePartnerSecretaryOfStateRevenue;

    /// <summary>
    /// The code partner secretary of state revenue set
    /// </summary>
    private bool _codePartnerSecretaryOfStateRevenueSet;

    /// <summary>
    /// The code ibge
    /// </summary>
    private int _codeIBGE;

    /// <summary>
    /// The code ibge set
    /// </summary>
    private bool _codeIBGESet;

    /// <summary>
    /// The code revenue
    /// </summary>
    private int _codeRevenue;

    /// <summary>
    /// The code revenue set
    /// </summary>
    private bool _codeRevenueSet;

    /// <summary>
    /// The code revenue detailing
    /// </summary>
    private int _codeRevenueDetailing;

    /// <summary>
    /// The code revenue detailing set
    /// </summary>
    private bool _codeRevenueDetailingSet;

    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// The agreement protocol
    /// </summary>
    private string _agreementProtocol;

    /// <summary>
    /// The agreement protocol set
    /// </summary>
    private bool _agreementProtocolSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [EntityKey]
    [EntityElement("CODUF")]
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
    /// Gets or sets the initials.
    /// </summary>
    /// <value>The initials.</value>
    [EntityElement("UF")]
    public string Initials
    {
        get => _initials;
        set
        {
            _initials = value;
            _initialsSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [EntityElement("DESCRICAO")]
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
    /// Gets or sets the code country.
    /// </summary>
    /// <value>The code country.</value>
    [EntityElement("CODPAIS")]
    public int CodeCountry
    {
        get => _codeCountry;
        set
        {
            _codeCountry = value;
            _codeCountrySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner secretary of state revenue.
    /// </summary>
    /// <value>The code partner secretary of state revenue.</value>
    [EntityElement("CODPARCSECRECEST")]
    public int CodePartnerSecretaryOfStateRevenue
    {
        get => _codePartnerSecretaryOfStateRevenue;
        set
        {
            _codePartnerSecretaryOfStateRevenue = value;
            _codePartnerSecretaryOfStateRevenueSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code ibge.
    /// </summary>
    /// <value>The code ibge.</value>
    [EntityElement("CODIBGE")]
    public int CodeIBGE
    {
        get => _codeIBGE;
        set
        {
            _codeIBGE = value;
            _codeIBGESet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code revenue.
    /// </summary>
    /// <value>The code revenue.</value>
    [EntityElement("CODSTGNRE")]
    public int CodeRevenue
    {
        get => _codeRevenue;
        set
        {
            _codeRevenue = value;
            _codeRevenueSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code revenue detailing.
    /// </summary>
    /// <value>The code revenue detailing.</value>
    [EntityElement("CODDETGNRE")]
    public int CodeRevenueDetailing
    {
        get => _codeRevenueDetailing;
        set
        {
            _codeRevenueDetailing = value;
            _codeRevenueDetailingSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code product.
    /// </summary>
    /// <value>The code product.</value>
    [EntityElement("CODPRODGNRE")]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the agreement protocol.
    /// </summary>
    /// <value>The agreement protocol.</value>
    [EntityElement("PROTOCOLOCONVENIO")]
    public string AgreementProtocol
    {
        get => _agreementProtocol;
        set
        {
            _agreementProtocol = value;
            _agreementProtocolSet = true;
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
    /// Should the serialize initials.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeInitials() => _initialsSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize code country.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeCountry() => _codeCountrySet;

    /// <summary>
    /// Should the serialize code partner secretary of state revenue.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodePartnerSecretaryOfStateRevenue() =>
        _codePartnerSecretaryOfStateRevenueSet;

    /// <summary>
    /// Should the serialize code IBGE.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeIBGE() => _codeIBGESet;

    /// <summary>
    /// Should the serialize code revenue.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeRevenue() => _codeRevenueSet;

    /// <summary>
    /// Should the serialize code revenue detailing.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeRevenueDetailing() => _codeRevenueDetailingSet;

    /// <summary>
    /// Should the serialize code product.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    /// <summary>
    /// Should the serialize agreement protocol.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeAgreementProtocol() => _agreementProtocolSet;

    #endregion
}
