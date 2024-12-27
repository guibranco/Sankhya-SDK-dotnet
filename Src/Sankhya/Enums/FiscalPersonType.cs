using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of a fiscal person.
/// </summary>
public enum FiscalPersonType
{
    /// <summary>
    /// An individual person.
    /// </summary>
    [HumanReadable("Pessoa física")]
    [InternalValue("F")]
    Individual,

    /// <summary>
    /// A corporate entity.
    /// </summary>
    [HumanReadable("Pessoa jurídica")]
    [InternalValue("J")]
    Corporation,
}
