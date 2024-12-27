using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the source type of a product.
/// </summary>
public enum ProductSourceType
{
    /// <summary>
    /// No source type.
    /// </summary>
    [HumanReadable("None")]
    None,

    /// <summary>
    /// Group of product.
    /// </summary>
    [HumanReadable("Group of product")]
    [InternalValue("G")]
    Group,

    /// <summary>
    /// Individual product.
    /// </summary>
    [HumanReadable("Product")]
    [InternalValue("P")]
    Product,
}
