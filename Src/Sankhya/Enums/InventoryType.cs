using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of inventory.
/// </summary>
public enum InventoryType
{
    /// <summary>
    /// Own inventory.
    /// </summary>
    [HumanReadable("Próprio")]
    [InternalValue("P")]
    Own,

    /// <summary>
    /// Third-party inventory.
    /// </summary>
    [HumanReadable("Terceiro")]
    [InternalValue("T")]
    Third,
}
