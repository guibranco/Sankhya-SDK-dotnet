using System;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("UnidadeFederativa")]
public class State : IEntity, IEquatable<State>
{
    public bool Equals(State other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
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
                && _codeIbge == other._codeIbge
                && _codeIbgeSet.Equals(other._codeIbgeSet)
                && _codeRevenue == other._codeRevenue
                && _codeRevenueSet.Equals(other._codeRevenueSet)
                && _codeRevenueDetailing == other._codeRevenueDetailing
                && _codeRevenueDetailingSet.Equals(other._codeRevenueDetailingSet)
                && _codeProduct == other._codeProduct
                && _codeProductSet.Equals(other._codeProductSet)
                && string.Equals(_agreementProtocol, other._agreementProtocol)
                && _agreementProtocolSet.Equals(other._agreementProtocolSet)
            );
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

        var a = obj as State;
        return a != null && Equals(a);
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
            hashCode = (hashCode * 397) ^ (_initials?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _initialsSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_name?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeCountry;
            hashCode = (hashCode * 397) ^ _codeCountrySet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codePartnerSecretaryOfStateRevenue;
            hashCode = (hashCode * 397) ^ _codePartnerSecretaryOfStateRevenueSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeIbge;
            hashCode = (hashCode * 397) ^ _codeIbgeSet.GetHashCode();
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

    public static bool operator ==(State left, State right) => Equals(left, right);

    public static bool operator !=(State left, State right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _initials;

    private bool _initialsSet;

    private string _name;

    private bool _nameSet;

    private int _codeCountry;

    private bool _codeCountrySet;

    private int _codePartnerSecretaryOfStateRevenue;

    private bool _codePartnerSecretaryOfStateRevenueSet;

    private int _codeIbge;

    private bool _codeIbgeSet;

    private int _codeRevenue;

    private bool _codeRevenueSet;

    private int _codeRevenueDetailing;

    private bool _codeRevenueDetailingSet;

    private int _codeProduct;

    private bool _codeProductSet;

    private string _agreementProtocol;

    private bool _agreementProtocolSet;

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

    [EntityElement("CODIBGE")]
    public int CodeIbge
    {
        get => _codeIbge;
        set
        {
            _codeIbge = value;
            _codeIbgeSet = true;
        }
    }

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

    public bool ShouldSerializeCode() => _codeSet;

    public bool ShouldSerializeInitials() => _initialsSet;

    public bool ShouldSerializeName() => _nameSet;

    public bool ShouldSerializeCodeCountry() => _codeCountrySet;

    public bool ShouldSerializeCodePartnerSecretaryOfStateRevenue() =>
        _codePartnerSecretaryOfStateRevenueSet;

    public bool ShouldSerializeCodeIbge() => _codeIbgeSet;

    public bool ShouldSerializeCodeRevenue() => _codeRevenueSet;

    public bool ShouldSerializeCodeRevenueDetailing() => _codeRevenueDetailingSet;

    public bool ShouldSerializeCodeProduct() => _codeProductSet;

    public bool ShouldSerializeAgreementProtocol() => _agreementProtocolSet;
}
