// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ProductUse.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums;

using CrispyWaffle.Attributes;


/// <summary>
/// Enum ProductUse
/// </summary>
public enum ProductUse
{
    /// <summary>
    /// The by product
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("SubProduto")]
    ByProduct,

    /// <summary>
    /// The product intermediate
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("Prod.Intermediário")]
    ProdIntermediate,

    /// <summary>
    /// The gift
    /// </summary>
    [InternalValue("B")]
    [HumanReadable("Brinde")]
    Gift,

    /// <summary>
    /// The consumption
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Consumo")]
    Consumption,

    /// <summary>
    /// The resale by formula
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Revenda (por fórmula)")]
    ResaleByFormula,

    /// <summary>
    /// The package
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Embalagem")]
    Package,

    /// <summary>
    /// The gift fiscal invoice
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Brinde (NF)")]
    GiftFiscalInvoice,

    /// <summary>
    /// The property
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Imobilizado")]
    Property,

    /// <summary>
    /// The feedstock
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Matéria prima")]
    Feedstock,

    /// <summary>
    /// The other inputs
    /// </summary>
    [InternalValue("O")]
    [HumanReadable("Outros insumos")]
    OtherInputs,

    /// <summary>
    /// The in process
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Em processo")]
    InProcess,


    /// <summary>
    /// The resale
    /// </summary>
    [InternalValue("R")]
    [HumanReadable("Revenda")]
    Resale,

    /// <summary>
    /// The service
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Serviço")]
    Service,

    /// <summary>
    /// The third
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,

    /// <summary>
    /// The sale own manufacturing
    /// </summary>
    [InternalValue("V")]
    [HumanReadable("Venda (fabricação própria)")]
    SaleOwnManufacturing
}