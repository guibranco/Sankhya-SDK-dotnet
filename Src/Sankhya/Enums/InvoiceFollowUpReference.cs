// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="InvoiceFollowUpReference.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum InvoiceFollowUpReference
/// </summary>
public enum InvoiceFollowUpReference
{
    /// <summary>
    /// The contact
    /// </summary>
    [HumanReadable("Contato")]
    [InternalValue("C")]
    Contact,

    /// <summary>
    /// The company
    /// </summary>
    [HumanReadable("Empresa")]
    [InternalValue("E")]
    Company,

    /// <summary>
    /// The freight
    /// </summary>
    [HumanReadable("Frete")]
    [InternalValue("F")]
    Freight,

    /// <summary>
    /// The vehicle
    /// </summary>
    [HumanReadable("Veículo")]
    [InternalValue("I")]
    Vehicle,

    /// <summary>
    /// The invoice
    /// </summary>
    [HumanReadable("Nota")]
    [InternalValue("N")]
    Invoice,

    /// <summary>
    /// The partner
    /// </summary>
    [HumanReadable("Parceiro")]
    [InternalValue("P")]
    Partner,

    /// <summary>
    /// The product
    /// </summary>
    [HumanReadable("Produto")]
    [InternalValue("R")]
    Product,

    /// <summary>
    /// The carrier
    /// </summary>
    [HumanReadable("Transportadora")]
    [InternalValue("T")]
    Carrier,

    /// <summary>
    /// The seller
    /// </summary>
    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,
}
