﻿// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceModule.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum ServiceModule
/// </summary>
public enum ServiceModule
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("none")]
    [HumanReadable("Test")]
    None = 0,

    /// <summary>
    /// The mge
    /// </summary>
    [InternalValue("mge")]
    [HumanReadable("MGE")]
    Mge = 1,

    /// <summary>
    /// The mgecom
    /// </summary>
    [InternalValue("mgecom")]
    [HumanReadable("MGECOM")]
    Mgecom = 2,

    /// <summary>
    /// The mgefin
    /// </summary>
    [InternalValue("mgefin")]
    [HumanReadable("MGEFIN")]
    Mgefin = 3
}
