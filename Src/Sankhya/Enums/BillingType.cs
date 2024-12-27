using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the different types of billing.
/// </summary>
public enum BillingType
{
    /// <summary>
    /// No billing type.
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("")]
    None,

    /// <summary>
    /// Normal billing type.
    /// </summary>
    [HumanReadable("Faturamento normal")]
    [InternalValue("FaturamentoNormal")]
    Normal,

    /// <summary>
    /// Direct billing type.
    /// </summary>
    [HumanReadable("Faturamento direto")]
    [InternalValue("FaturamentoDireto")]
    Direct,
}
