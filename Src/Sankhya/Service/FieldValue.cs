// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="FieldValue.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class FieldValue. This class cannot be inherited.
/// Implements the <see cref="IEquatable{IFieldValue}" />
/// </summary>
/// <seealso cref="IEquatable{FieldValue}" />
public sealed class FieldValue : IEquatable<FieldValue>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
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

        return string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase)
            && _valueSet == other._valueSet;
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

        return obj is FieldValue other && Equals(other);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(FieldValue left, FieldValue right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(FieldValue left, FieldValue right) => !Equals(left, right);

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The value
    /// </summary>
    private string _value;

    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
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

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
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

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize value.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeValue() => _valueSet;
}
