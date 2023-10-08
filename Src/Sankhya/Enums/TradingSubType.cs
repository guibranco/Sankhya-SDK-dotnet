// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="TradingSubType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum TradingSubType
/// </summary>
public enum TradingSubType
{
    /// <summary>
    /// The none
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    /// <summary>
    /// The in cash
    /// </summary>
    [HumanReadable("A vista")]
    [InternalValue("1")]
    InCash,

    /// <summary>
    /// The deferred
    /// </summary>
    [HumanReadable("A prazo")]
    [InternalValue("2")]
    Deferred,

    /// <summary>
    /// The parceled out
    /// </summary>
    [HumanReadable("Parcelada")]
    [InternalValue("3")]
    ParceledOut,

    /// <summary>
    /// The postdated check
    /// </summary>
    [HumanReadable("Cheque pré-datado")]
    [InternalValue("4")]
    PostdatedCheck,

    /// <summary>
    /// The installment credit
    /// </summary>
    [HumanReadable("Crediário")]
    [InternalValue("5")]
    InstallmentCredit,

    /// <summary>
    /// The financial
    /// </summary>
    [HumanReadable("Financeira")]
    [InternalValue("6")]
    Financial,

    /// <summary>
    /// The credit card
    /// </summary>
    [HumanReadable("Cartão de crédito")]
    [InternalValue("7")]
    CreditCard,

    /// <summary>
    /// The debit card
    /// </summary>
    [HumanReadable("Cartão de débito")]
    [InternalValue("8")]
    DebitCard
}
