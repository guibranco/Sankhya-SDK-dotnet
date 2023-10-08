// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="InvoiceStatus.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum InvoiceStatus
/// </summary>
public enum InvoiceStatus
{
    /// <summary>
    /// The service
    /// </summary>
    [InternalValue("A")]
    [HumanReadable("Atendimento")]
    Service,

    /// <summary>
    /// The released
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Liberada")]
    Released,

    /// <summary>
    /// The pending
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Pendente")]
    Pending
}
