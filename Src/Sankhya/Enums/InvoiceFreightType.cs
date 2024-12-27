using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum InvoiceFreightType
{
    [InternalValue("N")]
    [HumanReadable("Extra nota")]
    ExtraInvoice,

    [InternalValue("S")]
    [HumanReadable("Incluso")]
    Included,
}
