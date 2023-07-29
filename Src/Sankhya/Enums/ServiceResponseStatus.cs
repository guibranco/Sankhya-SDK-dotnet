// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceResponseStatus.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums;

/// <summary>
/// Enum ServiceResponseStatus
/// </summary>
public enum ServiceResponseStatus
{
    /// <summary>
    /// The error
    /// </summary>
    Error = 0,

    /// <summary>
    /// The ok
    /// </summary>
    Ok = 1,

    /// <summary>
    /// The information
    /// </summary>
    Info = 2,

    /// <summary>
    /// The timeout
    /// </summary>
    Timeout = 3,

    /// <summary>
    /// The service canceled
    /// </summary>
    ServiceCanceled = 4
}
