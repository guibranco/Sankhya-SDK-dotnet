using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum SankhyaWarningType
{
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None = 0,

    [InternalValue("usuario")]
    [HumanReadable("Usuário")]
    User = 1,

    [InternalValue("grupo")]
    [HumanReadable("Grupo")]
    Group = 2,
}
