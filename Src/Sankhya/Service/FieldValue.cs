using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class FieldValue : IEquatable<FieldValue>
{
    public bool Equals(FieldValue other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase)
            && _valueSet == other._valueSet;
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

        return obj is FieldValue other && Equals(other);
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
            var hashCode =
                _name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_name) : 0;
            hashCode = (hashCode * 397) ^ _nameSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _value != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _valueSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(FieldValue left, FieldValue right) => Equals(left, right);

    public static bool operator !=(FieldValue left, FieldValue right) => !Equals(left, right);

    private string _name;

    private bool _nameSet;

    private string _value;

    private bool _valueSet;

    [XmlAttribute(AttributeName = "nome")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [XmlText]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    public bool ShouldSerializeName() => _nameSet;

    public bool ShouldSerializeValue() => _valueSet;
}
