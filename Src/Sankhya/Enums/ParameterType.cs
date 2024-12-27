using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of a parameter.
/// </summary>
public enum ParameterType
{
    /// <summary>
    /// String parameter.
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("String")]
    String,

    /// <summary>
    /// Integer parameter.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Integer")]
    Integer,

    /// <summary>
    /// Datetime parameter.
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Datetime")]
    Datetime,
}
