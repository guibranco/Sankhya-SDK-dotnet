using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the service modules.
/// </summary>
public enum ServiceModule
{
    /// <summary>
    /// Test module.
    /// </summary>
    [InternalValue("none")]
    [HumanReadable("Test")]
    None = 0,

    /// <summary>
    /// MGE module.
    /// </summary>
    [InternalValue("mge")]
    [HumanReadable("MGE")]
    Mge = 1,

    /// <summary>
    /// MGECOM module.
    /// </summary>
    [InternalValue("mgecom")]
    [HumanReadable("MGECOM")]
    Mgecom = 2,

    /// <summary>
    /// MGEFIN module.
    /// </summary>
    [InternalValue("mgefin")]
    [HumanReadable("MGEFIN")]
    Mgefin = 3,
}
