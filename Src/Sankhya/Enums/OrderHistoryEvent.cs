using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the events in the order history.
/// </summary>
public enum OrderHistoryEvent
{
    /// <summary>
    /// No event.
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// Change event.
    /// </summary>
    [InternalValue("A")]
    [HumanReadable("Alteração")]
    Change,

    /// <summary>
    /// Confirmation event.
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Confirmação")]
    Confirmation,

    /// <summary>
    /// Exclusion event.
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Exclusão")]
    Exclusion,

    /// <summary>
    /// Inclusion event.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Inclusão")]
    Inclusion,
}
