// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Warnings.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Warnings. This class cannot be inherited.
/// </summary>
[XmlRoot("avisos")]
[Serializer]
public sealed class Warnings
{
    /// <summary>
    /// Gets or sets the warning.
    /// </summary>
    /// <value>The warning.</value>
    [XmlElement("aviso")]
    public Warning[] Warning { get; set; }
}
