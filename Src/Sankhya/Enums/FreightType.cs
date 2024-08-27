// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="FreightType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum FreightType
/// </summary>
public enum FreightType
{
    /// <summary>
    /// The cost insurance freight
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("CIF")]
    CostInsuranceFreight,

    /// <summary>
    /// The free on board
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("FOB")]
    FreeOnBoard,

    /// <summary>
    /// The no freight
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Sem Frete")]
    NoFreight,

    /// <summary>
    /// The third
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,
}
