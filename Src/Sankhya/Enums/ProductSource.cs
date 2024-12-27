using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the source of a product.
/// </summary>
public enum ProductSource
{
    /// <summary>
    /// National, except those indicated in codes 3, 4, 5, and 8.
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8")]
    National,

    /// <summary>
    /// Foreign, direct import, except that indicated in code 6.
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("1 - Estrangeira, importação direta, exceto a indicada no código 6")]
    ForeignDirectImport,

    /// <summary>
    /// Foreign, acquired in the domestic market, except that indicated in code 7.
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("2 - Estrangeira, adquirada no mercado interno, exceto a indicada no código 7")]
    ForeignAcquiredDomesticMarket,

    /// <summary>
    /// National, goods or merchandise with import content greater than 40% and less than or equal to 70%.
    /// </summary>
    [InternalValue("3")]
    [HumanReadable(
        "3 - Nacional, mercadoria ou bem com conteúdo de importação superior a 40% e inferior ou igual a 70%"
    )]
    NationalForeignBetween40And70,

    /// <summary>
    /// National, whose production has been carried out in accordance with basic production processes.
    /// </summary>
    [InternalValue("4")]
    [HumanReadable(
        "4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos"
    )]
    NationalBasicProductionProcesses,

    /// <summary>
    /// National, goods or merchandise with import content less than or equal to 40%.
    /// </summary>
    [InternalValue("5")]
    [HumanReadable(
        "5 - Nacional, mercadoria ou bem com conteúdo de importação inferior ou igual a 40%"
    )]
    NationalForeignUnder40,

    /// <summary>
    /// Foreign, direct import, without national equivalent, listed by CAMEX.
    /// </summary>
    [InternalValue("6")]
    [HumanReadable(
        "6 - Estrangeira, importação direta, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignDirectImportCamex,

    /// <summary>
    /// Foreign, acquired in the domestic market, without national equivalent, listed by CAMEX.
    /// </summary>
    [InternalValue("7")]
    [HumanReadable(
        "7 - Estrangeira, adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignAcquiredDomesticMarketCamex,

    /// <summary>
    /// National, goods or merchandise with import content greater than 70%.
    /// </summary>
    [InternalValue("8")]
    [HumanReadable("8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%")]
    NationalForeignOver70,
}
