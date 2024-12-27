using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum InvoiceFollowUpReference
{
    [HumanReadable("Contato")]
    [InternalValue("C")]
    Contact,

    [HumanReadable("Empresa")]
    [InternalValue("E")]
    Company,

    [HumanReadable("Frete")]
    [InternalValue("F")]
    Freight,

    [HumanReadable("Veículo")]
    [InternalValue("I")]
    Vehicle,

    [HumanReadable("Nota")]
    [InternalValue("N")]
    Invoice,

    [HumanReadable("Parceiro")]
    [InternalValue("P")]
    Partner,

    [HumanReadable("Produto")]
    [InternalValue("R")]
    Product,

    [HumanReadable("Transportadora")]
    [InternalValue("T")]
    Carrier,

    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,
}
