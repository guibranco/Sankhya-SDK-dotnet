using System;
using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Entity("Endereco")]
public class Address : IEntity, IEquatable<Address>
{
    public bool Equals(Address other)
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
            && string.Equals(_type, other._type, StringComparison.OrdinalIgnoreCase)
            && _typeSet == other._typeSet
            && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(
                _descriptionCorreios,
                other._descriptionCorreios,
                StringComparison.OrdinalIgnoreCase
            )
            && _descriptionCorreiosSet == other._descriptionCorreiosSet
            && _dateChanged.Equals(other._dateChanged)
            && _dateChangedSet == other._dateChangedSet;
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

        return obj.GetType() == GetType() && Equals((Address)obj);
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
                    _type != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_type) : 0
                );
            hashCode = (hashCode * 397) ^ _typeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0
                );
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _descriptionCorreios != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(
                            _descriptionCorreios
                        )
                        : 0
                );
            hashCode = (hashCode * 397) ^ _descriptionCorreiosSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(Address left, Address right) => Equals(left, right);

    public static bool operator !=(Address left, Address right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _type;

    private bool _typeSet;

    private string _name;

    private bool _nameSet;

    private string _descriptionCorreios;

    private bool _descriptionCorreiosSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    [EntityKey]
    [EntityElement("CODEND")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("TIPO")]
    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            _typeSet = true;
        }
    }

    [EntityElement("NOMEEND")]
    [EntityCustomData(MaxLength = 60)]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [EntityElement("DESCRICAOCORREIO")]
    public string DescriptionCorreios
    {
        get => _descriptionCorreios;
        set
        {
            _descriptionCorreios = value;
            _descriptionCorreiosSet = true;
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

    public bool ShouldSerializeCode() => _codeSet;

    public bool ShouldSerializeType() => _typeSet;

    public bool ShouldSerializeName() => _nameSet;

    public bool ShouldSerializeDescriptionCorreios() => _descriptionCorreiosSet;

    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
