using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ServiceEnvironment
{
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None,

    [InternalValue("8180")]
    [HumanReadable("Produção")]
    Production,

    [InternalValue("8280")]
    [HumanReadable("Sandbox")]
    Sandbox,

    [InternalValue("8380")]
    [HumanReadable("Treinamento")]
    Training,
}
