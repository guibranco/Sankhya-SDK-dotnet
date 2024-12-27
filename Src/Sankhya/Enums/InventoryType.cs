using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum InventoryType
{
    [HumanReadable("Próprio")]
    [InternalValue("P")]
    Own,

    [HumanReadable("Terceiro")]
    [InternalValue("T")]
    Third,
}
