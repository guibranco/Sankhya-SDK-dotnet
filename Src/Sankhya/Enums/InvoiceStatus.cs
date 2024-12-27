using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the status of an invoice.
/// </summary>
public enum InvoiceStatus
{
    /// <summary>
    /// The invoice is in service.
    /// </summary>
    [InternalValue("A")]
    [HumanReadable("Atendimento")]
    Service,

    /// <summary>
    /// The invoice is released.
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Liberada")]
    Released,

    /// <summary>
    /// The invoice is pending.
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Pendente")]
    Pending,
}
