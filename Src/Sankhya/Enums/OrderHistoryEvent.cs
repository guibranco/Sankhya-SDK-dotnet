using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum OrderHistoryEvent
{
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    [InternalValue("A")]
    [HumanReadable("Alteração")]
    Change,

    [InternalValue("C")]
    [HumanReadable("Confirmação")]
    Confirmation,

    [InternalValue("E")]
    [HumanReadable("Exclusão")]
    Exclusion,

    [InternalValue("I")]
    [HumanReadable("Inclusão")]
    Inclusion,
}
