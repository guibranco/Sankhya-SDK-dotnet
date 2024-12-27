using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ProductSource
{
    [InternalValue("0")]
    [HumanReadable("0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8")]
    National,

    [InternalValue("1")]
    [HumanReadable("1 - Estrangeira, importação direta, exceto a indicada no código 6")]
    ForeignDirectImport,

    [InternalValue("2")]
    [HumanReadable("2 - Estrangeira, adquirada no mercado interno, exceto a indicada no código 7")]
    ForeignAcquiredDomesticMarket,

    [InternalValue("3")]
    [HumanReadable(
        "3 - Nacional, mercadoria ou bem com conteúdo de importação superior a 40% e inferior ou igual a 70%"
    )]
    NationalForeignBetween40And70,

    [InternalValue("4")]
    [HumanReadable(
        "4  -Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos"
    )]
    NationalBasicProductionProcesses,

    [InternalValue("5")]
    [HumanReadable(
        "5  -Nacional, mercadoria ou bem com conteúdo de importação inferior ou igual a 40%"
    )]
    NationalForeignUnder40,

    [InternalValue("6")]
    [HumanReadable(
        "6 - Estrangeira, importação direta, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignDirectImportCamex,

    [InternalValue("7")]
    [HumanReadable(
        "7 - Estrangeira, adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX"
    )]
    ForeignAcquiredDomesticMarketCamex,

    [InternalValue("8")]
    [HumanReadable("8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%")]
    NationalForeignOver70,
}
