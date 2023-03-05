// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Parameter.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service;

using CrispyWaffle.Extensions;
using System.ComponentModel;
using System.Xml.Serialization;
using Sankhya.Enums;

/// <summary>
/// Class Parameter. This class cannot be inherited.
/// </summary>
public sealed class Parameter
{

    /// <summary>
    /// Gets or sets the type internal.
    /// </summary>
    /// <value>The parameter type.</value>
    [XmlAttribute(AttributeName = "type")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => Type.GetInternalValue();
        set => Type = EnumExtensions.GetEnumByInternalValueAttribute<ParameterType>(value);
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [XmlIgnore]

    public ParameterType Type { get; set; }


    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    [XmlText]
    public string Value { get; set; }
}