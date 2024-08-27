// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="OrderHistoryEvent.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum OrderHistoryEvent
/// </summary>
public enum OrderHistoryEvent
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// The change
    /// </summary>
    [InternalValue("A")]
    [HumanReadable("Alteração")]
    Change,

    /// <summary>
    /// The confirmation
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Confirmação")]
    Confirmation,

    /// <summary>
    /// The exclusion
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Exclusão")]
    Exclusion,

    /// <summary>
    /// The inclusion
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Inclusão")]
    Inclusion,
}
