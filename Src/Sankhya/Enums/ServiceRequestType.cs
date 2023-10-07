// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceRequestType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum ServiceRequestType
/// </summary>
public enum ServiceRequestType
{
    /// <summary>
    /// The default
    /// </summary>
    [HumanReadable("Default")]
    Default,

    /// <summary>
    /// The simple crud
    /// </summary>
    [HumanReadable("Simple CRUD")]
    SimpleCrud,

    /// <summary>
    /// The paged crud
    /// </summary>
    [HumanReadable("Paged CRUD (retrieve)")]
    PagedCrud,

    /// <summary>
    /// The queryable crud
    /// </summary>
    [HumanReadable("Queryable CRUD (retrieve)")]
    QueryableCrud,

    /// <summary>
    /// The on demand crud
    /// </summary>
    [HumanReadable("On demand CRUD (Create, Update, Delete)")]
    OnDemandCrud,

    /// <summary>
    /// The know services
    /// </summary>
    [HumanReadable("Know services")]
    KnowServices
}
