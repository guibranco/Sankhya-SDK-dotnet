// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="SellerType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums;

using CrispyWaffle.Attributes;

/// <summary>
/// Enum SellerType
/// </summary>
public enum SellerType
{
    /// <summary>
    /// The none
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    /// <summary>
    /// The buyer
    /// </summary>
    [HumanReadable("Comprador")]
    [InternalValue("C")]
    Buyer,

    /// <summary>
    /// The seller
    /// </summary>
    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,

    /// <summary>
    /// The supervisor
    /// </summary>
    [HumanReadable("Supervisor")]
    [InternalValue("S")]
    Supervisor,

    /// <summary>
    /// The manager
    /// </summary>
    [HumanReadable("Gerente")]
    [InternalValue("G")]
    Manager,

    /// <summary>
    /// The performer
    /// </summary>
    [HumanReadable("Executante")]
    [InternalValue("E")]
    Performer,

    /// <summary>
    /// The representative
    /// </summary>
    [HumanReadable("Representante")]
    [InternalValue("R")]
    Representative,

    /// <summary>
    /// The technician
    /// </summary>
    [HumanReadable("Técnico")]
    [InternalValue("T")]
    Technician
}