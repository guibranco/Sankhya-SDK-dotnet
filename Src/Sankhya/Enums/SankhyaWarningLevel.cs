// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="SankhyaWarningLevel.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum SankhyaWarningLevel
/// </summary>
public enum SankhyaWarningLevel
{
    /// <summary>
    /// The urgent
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Urgente")]
    Urgent = 0,

    /// <summary>
    /// The error
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("Erro")]
    Error = 1,

    /// <summary>
    /// The warning
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("Alerta")]
    Warning = 2,

    /// <summary>
    /// The information
    /// </summary>
    [InternalValue("3")]
    [HumanReadable("Informação")]
    Information = 3,
}
