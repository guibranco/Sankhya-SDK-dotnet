﻿// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Address.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using Sankhya.Attributes;

namespace Sankhya.Transport;

/// <summary>
/// Class Address. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("Endereco")]
public class Address : IEntity, IEquatable<Address>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
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
            && string.Equals(_type, other._type, StringComparison.InvariantCultureIgnoreCase)
            && _typeSet == other._typeSet
            && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase)
            && _nameSet == other._nameSet
            && string.Equals(
                _descriptionCorreios,
                other._descriptionCorreios,
                StringComparison.InvariantCultureIgnoreCase
            )
            && _descriptionCorreiosSet == other._descriptionCorreiosSet
            && _dateChanged.Equals(other._dateChanged)
            && _dateChangedSet == other._dateChangedSet;
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

        return obj.GetType() == GetType() && Equals((Address)obj);
    }

    /// <summary>
    /// Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Object" />.</returns>
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

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Address left, Address right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Address left, Address right) => !Equals(left, right);

    /// <summary>
    /// The code
    /// </summary>
    private int _code;

    /// <summary>
    /// The code set
    /// </summary>
    private bool _codeSet;

    /// <summary>
    /// The type
    /// </summary>
    private string _type;

    /// <summary>
    /// The type set
    /// </summary>
    private bool _typeSet;

    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The description correios
    /// </summary>
    private string _descriptionCorreios;

    /// <summary>
    /// The description correios set
    /// </summary>
    private bool _descriptionCorreiosSet;

    /// <summary>
    /// The date changed
    /// </summary>
    private DateTime _dateChanged;

    /// <summary>
    /// The date changed set
    /// </summary>
    private bool _dateChangedSet;

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
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

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
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

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
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

    /// <summary>
    /// Gets or sets the description correios.
    /// </summary>
    /// <value>The description correios.</value>
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
    /// Should the serialize code.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeCode() => _codeSet;

    /// <summary>
    /// Should the type of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeType() => _typeSet;

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize description correios.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeDescriptionCorreios() => _descriptionCorreiosSet;

    /// <summary>
    /// Should the serialize date changed.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeDateChanged() => _dateChangedSet;
}
