// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="SystemParameterType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums;

using CrispyWaffle.Attributes;

/// <summary>
/// Enum SystemParameterType
/// </summary>
public enum SystemParameterType
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// The text
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Texto")]
    Text,

    /// <summary>
    /// The date
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Data")]
    Date,

    /// <summary>
    /// The decimal
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Número Decimal")]
    Decimal,

    /// <summary>
    /// The logical
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Lógico")]
    Logical,

    /// <summary>
    /// The list
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("List")]
    List,

    /// <summary>
    /// The integer
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Número Inteiro")]
    Integer,
}
