// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-07-2023
// ***********************************************************************
// <copyright file="ServiceEnvironment.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum ServiceEnvironment
/// </summary>
public enum ServiceEnvironment
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// The production
    /// </summary>
    [InternalValue("8180")]
    [HumanReadable("Produção")]
    Production,

    /// <summary>
    /// The sandbox
    /// </summary>
    [InternalValue("8280")]
    [HumanReadable("Sandbox")]
    Sandbox,

    /// <summary>
    /// The training
    /// </summary>
    [InternalValue("8380")]
    [HumanReadable("Treinamento")]
    Training
}
