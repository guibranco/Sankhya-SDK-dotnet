// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="LiteralCriteriaSql.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service;

using System.Xml.Serialization;

/// <summary>
/// Class LiteralCriteriaSql. This class cannot be inherited.
/// </summary>
/// <seealso cref="ILiteralCriteria" />
public sealed class LiteralCriteriaSql : ILiteralCriteria
{
    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    /// <value>The expression.</value>
    [XmlElement(ElementName = "expressao")]
    public string Expression { get; set; }
}
