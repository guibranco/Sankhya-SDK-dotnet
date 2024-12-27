using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum FreightType
{
    [InternalValue("C")]
    [HumanReadable("CIF")]
    CostInsuranceFreight,

    [InternalValue("F")]
    [HumanReadable("FOB")]
    FreeOnBoard,

    [InternalValue("S")]
    [HumanReadable("Sem Frete")]
    NoFreight,

    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,
}
