using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the reference level.
/// </summary>
public enum ReferenceLevel
{
    /// <summary>
    /// No reference level.
    /// </summary>
    [HumanReadable("None")]
    None,

    /// <summary>
    /// First reference level.
    /// </summary>
    [HumanReadable("First")]
    First,

    /// <summary>
    /// Second reference level.
    /// </summary>
    [HumanReadable("Second")]
    Second,

    /// <summary>
    /// Third reference level.
    /// </summary>
    [HumanReadable("Third")]
    Third,

    /// <summary>
    /// Fourth reference level.
    /// </summary>
    [HumanReadable("Fourth")]
    Fourth,

    /// <summary>
    /// Fifth reference level.
    /// </summary>
    [HumanReadable("Fifth")]
    Fifth,

    /// <summary>
    /// Sixth reference level.
    /// </summary>
    [HumanReadable("Sixth")]
    Sixth,
}
