using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Specifies the different uses for a product.
/// </summary>
public enum ProductUse
{
    /// <summary>
    /// By-product.
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("SubProduto")]
    ByProduct,

    /// <summary>
    /// Intermediate product.
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("Prod.Intermediário")]
    ProdIntermediate,

    /// <summary>
    /// Gift.
    /// </summary>
    [InternalValue("B")]
    [HumanReadable("Brinde")]
    Gift,

    /// <summary>
    /// Consumption.
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Consumo")]
    Consumption,

    /// <summary>
    /// Resale by formula.
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Revenda (por fórmula)")]
    ResaleByFormula,

    /// <summary>
    /// Package.
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Embalagem")]
    Package,

    /// <summary>
    /// Gift for fiscal invoice.
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Brinde (NF)")]
    GiftFiscalInvoice,

    /// <summary>
    /// Property.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Imobilizado")]
    Property,

    /// <summary>
    /// Feedstock.
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Matéria prima")]
    Feedstock,

    /// <summary>
    /// Other inputs.
    /// </summary>
    [InternalValue("O")]
    [HumanReadable("Outros insumos")]
    OtherInputs,

    /// <summary>
    /// In process.
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Em processo")]
    InProcess,

    /// <summary>
    /// Resale.
    /// </summary>
    [InternalValue("R")]
    [HumanReadable("Revenda")]
    Resale,

    /// <summary>
    /// Service.
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Serviço")]
    Service,

    /// <summary>
    /// Third-party.
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,

    /// <summary>
    /// Sale of own manufacturing.
    /// </summary>
    [InternalValue("V")]
    [HumanReadable("Venda (fabricação própria)")]
    SaleOwnManufacturing,
}
