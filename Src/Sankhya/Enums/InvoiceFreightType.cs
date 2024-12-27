using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of freight for an invoice.
/// </summary>
public enum InvoiceFreightType
{
    /// <summary>
    /// Freight is extra to the invoice.
    /// </summary>
    [InternalValue("N")]
    [HumanReadable("Extra nota")]
    ExtraInvoice,

    /// <summary>
    /// Freight is included in the invoice.
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Incluso")]
    Included,
}
