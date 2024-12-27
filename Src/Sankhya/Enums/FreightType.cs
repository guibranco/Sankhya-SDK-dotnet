using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of freight.
/// </summary>
public enum FreightType
{
    /// <summary>
    /// Cost, Insurance, and Freight.
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("CIF")]
    CostInsuranceFreight,

    /// <summary>
    /// Free on Board.
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("FOB")]
    FreeOnBoard,

    /// <summary>
    /// No freight.
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Sem Frete")]
    NoFreight,

    /// <summary>
    /// Third-party freight.
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Terceiros")]
    Third,
}
