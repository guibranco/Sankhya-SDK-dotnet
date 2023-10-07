// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Key.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Key. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot("chave")]
public sealed class Key
{
    #region Private Members

    /// <summary>
    /// The value
    /// </summary>
    private string _value;

    /// <summary>
    /// The value set
    /// </summary>
    private bool _valueSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    [XmlAttribute(AttributeName = "valor")]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize value.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializeValue() => _valueSet;

    #endregion
}
