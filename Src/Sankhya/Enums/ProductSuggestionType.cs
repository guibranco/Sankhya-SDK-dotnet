using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of product suggestion.
/// </summary>
public enum ProductSuggestionType
{
    /// <summary>
    /// No suggestion.
    /// </summary>
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// Accessory suggestion.
    /// </summary>
    [HumanReadable("Acessório")]
    [InternalValue("A")]
    Accessory,

    /// <summary>
    /// General suggestion.
    /// </summary>
    [HumanReadable("Sugestão")]
    [InternalValue("S")]
    Suggestion,

    /// <summary>
    /// Buy together suggestion.
    /// </summary>
    [HumanReadable("Compre Junto")]
    [InternalValue("C")]
    BuyTogether,
}
