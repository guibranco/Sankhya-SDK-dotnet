// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Users.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service;

using CrispyWaffle.Serialization;
using System.Xml.Serialization;

/// <summary>
/// Class Users. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "usuarios")]
public sealed class Users
{
    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    [XmlElement(ElementName = "usuario")]
    public User[] User { get; set; }
}