// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ProductSource.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum ProductSource
/// </summary>
public enum ProductSource
{
    /// <summary>
    /// The national
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8")]
    National,

    /// <summary>
    /// The foreign direct import
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("1 - Estrangeira, importação direta, exceto a indicada no código 6")]
    ForeignDirectImport,

    /// <summary>
    /// The foreign acquired domestic market
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("2 - Estrangeira, adquirada no mercado interno, exceto a indicada no código 7")]
    ForeignAcquiredDomesticMarket,

    /// <summary>
    /// The national foreign between40 and70
    /// </summary>
    [InternalValue("3")]
    [HumanReadable(
        "3 - Nacional, mercadoria ou bem com conteúdo de importação superior a 40% e inferior ou igual a 70%"
    )]
    NationalForeignBetween40And70,

    /// <summary>
    /// The national basic production processes
    /// </summary>
    [InternalValue("4")]
    [HumanReadable(
        "4  -Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos"
    )]
    NationalBasicProductionProcesses,

    /// <summary>
    /// The national foreign under40
    /// </summary>
    [InternalValue("5")]
    [HumanReadable(
        "5  -Nacional, mercadoria ou bem com conteúdo de importação inferior ou igual a 40%"
    )]
    NationalForeignUnder40,

    /// <summary>
    /// The foreign direct import camex
    /// </summary>
    [InternalValue("6")]
    [HumanReadable(
        "6 - Estrangeira, importação direta, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignDirectImportCamex,

    /// <summary>
    /// The foreign acquired domestic market camex
    /// </summary>
    [InternalValue("7")]
    [HumanReadable(
        "7 - Estrangeira, adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignAcquiredDomesticMarketCamex,

    /// <summary>
    /// The national foreign over70
    /// </summary>
    [InternalValue("8")]
    [HumanReadable("8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%")]
    NationalForeignOver70,
}
