using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum BillingType
{
    [HumanReadable("Nenhum")]
    [InternalValue("")]
    None,

    [HumanReadable("Faturamento normal")]
    [InternalValue("FaturamentoNormal")]
    Normal,

    [HumanReadable("Faturamento direto")]
    [InternalValue("FaturamentoDireto")]
    Direct,
}
