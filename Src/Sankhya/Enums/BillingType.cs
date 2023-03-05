// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="BillingType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums;

using CrispyWaffle.Attributes;

/// <summary>
/// Enum BillingType
/// </summary>
public enum BillingType
{

    /// <summary>
    /// The none
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("")]
    None,

    /// <summary>
    /// The normal
    /// </summary>
    [HumanReadable("Faturamento normal")]
    [InternalValue("FaturamentoNormal")]
    Normal,

    /// <summary>
    /// The direct
    /// </summary>
    [HumanReadable("Faturamento direto")]
    [InternalValue("FaturamentoDireto")]
    Direct
}