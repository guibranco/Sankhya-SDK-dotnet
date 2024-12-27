using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ReferenceLevel
{
    [HumanReadable("None")]
    None,

    [HumanReadable("First")]
    First,

    [HumanReadable("Second")]
    Second,

    [HumanReadable("Third")]
    Third,

    [HumanReadable("Fourth")]
    Fourth,

    [HumanReadable("Fifth")]
    Fifth,

    [HumanReadable("Sixth")]
    Sixth,
}
