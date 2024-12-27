using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum FiscalPersonType
{
    [HumanReadable("Pessoa física")]
    [InternalValue("F")]
    Individual,

    [HumanReadable("Pessoa jurídica")]
    [InternalValue("J")]
    Corporation,
}
