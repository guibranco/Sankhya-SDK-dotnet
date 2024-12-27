using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the warning levels in Sankhya.
/// </summary>
public enum SankhyaWarningLevel
{
    /// <summary>
    /// Urgent warning level.
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Urgente")]
    Urgent = 0,

    /// <summary>
    /// Error warning level.
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("Erro")]
    Error = 1,

    /// <summary>
    /// Warning level.
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("Alerta")]
    Warning = 2,

    /// <summary>
    /// Information warning level.
    /// </summary>
    [InternalValue("3")]
    [HumanReadable("Informação")]
    Information = 3,
}
