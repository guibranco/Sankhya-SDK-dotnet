using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum SankhyaWarningLevel
{
    [InternalValue("0")]
    [HumanReadable("Urgente")]
    Urgent = 0,

    [InternalValue("1")]
    [HumanReadable("Erro")]
    Error = 1,

    [InternalValue("2")]
    [HumanReadable("Alerta")]
    Warning = 2,

    [InternalValue("3")]
    [HumanReadable("Informação")]
    Information = 3,
}
