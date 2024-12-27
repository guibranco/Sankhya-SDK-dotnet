using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ProductSourceType
{
    [HumanReadable("None")]
    None,

    [HumanReadable("Group of product")]
    [InternalValue("G")]
    Group,

    [HumanReadable("Product")]
    [InternalValue("P")]
    Product,
}
