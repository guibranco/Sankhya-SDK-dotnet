// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="InvoiceFreightType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum InvoiceFreightType
/// </summary>
public enum InvoiceFreightType
{
    /// <summary>
    /// The extra invoice
    /// </summary>
    [InternalValue("N")]
    [HumanReadable("Extra nota")]
    ExtraInvoice,

    /// <summary>
    /// The included
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Incluso")]
    Included,
}
