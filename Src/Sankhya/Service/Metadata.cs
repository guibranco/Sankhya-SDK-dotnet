// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Metadata.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Metadata. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "metadata")]
public sealed class Metadata
{
    /// <summary>
    /// Gets or sets the fields.
    /// </summary>
    /// <value>The fields.</value>
    [XmlArray("fields")]
    [XmlArrayItem("field")]
    public Field[] Fields { get; set; }
}
