using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ServiceModule
{
    [InternalValue("none")]
    [HumanReadable("Test")]
    None = 0,

    [InternalValue("mge")]
    [HumanReadable("MGE")]
    Mge = 1,

    [InternalValue("mgecom")]
    [HumanReadable("MGECOM")]
    Mgecom = 2,

    [InternalValue("mgefin")]
    [HumanReadable("MGEFIN")]
    Mgefin = 3,
}
