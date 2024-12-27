using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the reference for invoice follow-up.
/// </summary>
public enum InvoiceFollowUpReference
{
    /// <summary>
    /// Contact reference.
    /// </summary>
    [HumanReadable("Contato")]
    [InternalValue("C")]
    Contact,

    /// <summary>
    /// Company reference.
    /// </summary>
    [HumanReadable("Empresa")]
    [InternalValue("E")]
    Company,

    /// <summary>
    /// Freight reference.
    /// </summary>
    [HumanReadable("Frete")]
    [InternalValue("F")]
    Freight,

    /// <summary>
    /// Vehicle reference.
    /// </summary>
    [HumanReadable("Veículo")]
    [InternalValue("I")]
    Vehicle,

    /// <summary>
    /// Invoice reference.
    /// </summary>
    [HumanReadable("Nota")]
    [InternalValue("N")]
    Invoice,

    /// <summary>
    /// Partner reference.
    /// </summary>
    [HumanReadable("Parceiro")]
    [InternalValue("P")]
    Partner,

    /// <summary>
    /// Product reference.
    /// </summary>
    [HumanReadable("Produto")]
    [InternalValue("R")]
    Product,

    /// <summary>
    /// Carrier reference.
    /// </summary>
    [HumanReadable("Transportadora")]
    [InternalValue("T")]
    Carrier,

    /// <summary>
    /// Seller reference.
    /// </summary>
    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,
}
