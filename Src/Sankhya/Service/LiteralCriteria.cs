// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="LiteralCriteria.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// A literal criteria.
/// </summary>
/// <seealso cref="ILiteralCriteria" />
public sealed class LiteralCriteria : ILiteralCriteria
{
    #region Public properties

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    /// <value>The expression.</value>

    [XmlElement(ElementName = "expression")]
    [Localizable(false)]
    public string Expression { get; set; }

    /// <summary>
    /// Gets or sets the parameters.
    /// </summary>
    /// <value>The parameters.</value>
    [XmlElement(ElementName = "parameter")]
    public Parameter[] Parameters { get; set; }

    #endregion

    #region ~Ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="LiteralCriteria" /> class.
    /// </summary>
    public LiteralCriteria() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LiteralCriteria" /> class.
    /// </summary>
    /// <param name="expression">The expression.</param>
    public LiteralCriteria([Localizable(false)] string expression) => Expression = expression;

    /// <summary>
    /// Initializes a new instance of the <see cref="LiteralCriteria" /> class.
    /// </summary>
    /// <param name="expressionBuilder">The expression builder.</param>
    /// <exception cref="System.ArgumentNullException">expressionBuilder</exception>
    public LiteralCriteria(StringBuilder expressionBuilder)
    {
        if (expressionBuilder == null)
        {
            throw new ArgumentNullException(nameof(expressionBuilder));
        }

        Expression = expressionBuilder.ToString();
    }

    #endregion
}
