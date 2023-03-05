// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="User.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service;

using System.Xml.Serialization;

/// <summary>
/// Class User. This class cannot be inherited.
/// </summary>
[XmlType("usuario")]
public sealed class User
{
    /// <summary>
    /// Gets or sets the logged user code.
    /// </summary>
    /// <value>The logged user code.</value>
    [XmlAttribute(AttributeName = "codUsuLogado")]
    public int LoggedUserCode { get; set; }
}