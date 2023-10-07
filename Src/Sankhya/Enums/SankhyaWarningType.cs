// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="SankhyaWarningType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum SankhyaWarningType
/// </summary>
public enum SankhyaWarningType
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None = 0,

    /// <summary>
    /// The user
    /// </summary>
    [InternalValue("usuario")]
    [HumanReadable("Usuário")]
    User = 1,

    /// <summary>
    /// The group
    /// </summary>
    [InternalValue("grupo")]
    [HumanReadable("Grupo")]
    Group = 2
}
