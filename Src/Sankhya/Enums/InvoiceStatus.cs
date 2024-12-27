using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum InvoiceStatus
{
    [InternalValue("A")]
    [HumanReadable("Atendimento")]
    Service,

    [InternalValue("L")]
    [HumanReadable("Liberada")]
    Released,

    [InternalValue("P")]
    [HumanReadable("Pendente")]
    Pending,
}
