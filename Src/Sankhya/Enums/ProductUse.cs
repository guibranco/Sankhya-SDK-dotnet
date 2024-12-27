using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ProductUse
{
    [InternalValue("1")]
    [HumanReadable("SubProduto")]
    ByProduct,

    [InternalValue("2")]
    [HumanReadable("Prod.Intermediário")]
    ProdIntermediate,

    [InternalValue("B")]
    [HumanReadable("Brinde")]
    Gift,

    [InternalValue("C")]
    [HumanReadable("Consumo")]
    Consumption,

    [InternalValue("D")]
    [HumanReadable("Revenda (por fórmula)")]
    ResaleByFormula,

    [InternalValue("E")]
    [HumanReadable("Embalagem")]
    Package,

    [InternalValue("F")]
    [HumanReadable("Brinde (NF)")]
    GiftFiscalInvoice,

    [InternalValue("I")]
    [HumanReadable("Imobilizado")]
    Property,

    [InternalValue("M")]
    [HumanReadable("Matéria prima")]
    Feedstock,

    [InternalValue("O")]
    [HumanReadable("Outros insumos")]
    OtherInputs,

    [InternalValue("P")]
    [HumanReadable("Em processo")]
    InProcess,

    [InternalValue("R")]
    [HumanReadable("Revenda")]
    Resale,

    [InternalValue("S")]
    [HumanReadable("Serviço")]
    Service,

    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,

    [InternalValue("V")]
    [HumanReadable("Venda (fabricação própria)")]
    SaleOwnManufacturing,
}
