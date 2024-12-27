using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ParameterType
{
    [InternalValue("S")]
    [HumanReadable("String")]
    String,

    [InternalValue("I")]
    [HumanReadable("Integer")]
    Integer,

    [InternalValue("D")]
    [HumanReadable("Datetime")]
    Datetime,
}
