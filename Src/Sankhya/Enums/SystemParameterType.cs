using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum SystemParameterType
{
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    [InternalValue("T")]
    [HumanReadable("Texto")]
    Text,

    [InternalValue("D")]
    [HumanReadable("Data")]
    Date,

    [InternalValue("F")]
    [HumanReadable("Número Decimal")]
    Decimal,

    [InternalValue("L")]
    [HumanReadable("Lógico")]
    Logical,

    [InternalValue("C")]
    [HumanReadable("List")]
    List,

    [InternalValue("I")]
    [HumanReadable("Número Inteiro")]
    Integer,
}
