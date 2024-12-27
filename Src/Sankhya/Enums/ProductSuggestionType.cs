using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ProductSuggestionType
{
    [HumanReadable("Nenhum")]
    None,

    [HumanReadable("Acessório")]
    [InternalValue("A")]
    Accessory,

    [HumanReadable("Sugestão")]
    [InternalValue("S")]
    Suggestion,

    [HumanReadable("Compre Junto")]
    [InternalValue("C")]
    BuyTogether,
}
