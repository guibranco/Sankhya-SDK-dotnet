using System;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Serialization;
using Sankhya.Attributes;

namespace Sankhya.Transport;

[Serializer]
[Entity("Bairro")]
public class Neighborhood : IEntity, IEquatable<Neighborhood>
{
    public bool Equals(Neighborhood other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                _code == other._code
                && _codeSet.Equals(other._codeSet)
                && string.Equals(_name, other._name)
                && _nameSet.Equals(other._nameSet)
                && string.Equals(_descriptionCorreios, other._descriptionCorreios)
                && _descriptionCorreiosSet.Equals(other._descriptionCorreiosSet)
                && _dateChanged.Equals(other._dateChanged)
                && _dateChangedSet.Equals(other._dateChangedSet)
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj)
            || (obj is Neighborhood neighborhood && Equals(neighborhood));
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
            hashCode = (hashCode * 397) ^ (_name?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_descriptionCorreios?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ _descriptionCorreiosSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChanged.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateChangedSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(Neighborhood left, Neighborhood right) => Equals(left, right);

    public static bool operator !=(Neighborhood left, Neighborhood right) => !Equals(left, right);

    private int _code;

    private bool _codeSet;

    private string _name;

    private bool _nameSet;

    private string _descriptionCorreios;

    private bool _descriptionCorreiosSet;

    private DateTime _dateChanged;

    private bool _dateChangedSet;

    [EntityKey]
    [EntityElement("CODBAI")]
    public int Code
    {
        get => _code;
        set
        {
            _code = value;
            _codeSet = true;
        }
    }

    [EntityElement("NOMEBAI")]
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

    public bool ShouldSerializeName() => _nameSet;

    public bool ShouldSerializeDescriptionCorreios() => _descriptionCorreiosSet;

    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
