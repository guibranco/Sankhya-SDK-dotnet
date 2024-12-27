using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the fiscal classification of an entity.
/// </summary>
public enum FiscalClassification
{
    /// <summary>
    /// Final customer (Consumidor Final).
    /// </summary>
    [HumanReadable("Consumidor Final")]
    [InternalValue("C")]
    FinalCustomer,

    /// <summary>
    /// ICMS-free entity (Isento de ICMS).
    /// </summary>
    [HumanReadable("Isento de ICMS")]
    [InternalValue("I")]
    IcmsFree,

    /// <summary>
    /// Rural producer (Produtor Rural).
    /// </summary>
    [HumanReadable("Produtor Rural")]
    [InternalValue("P")]
    RuralProducer,

    /// <summary>
    /// Retailer (Revendedor).
    /// </summary>
    [HumanReadable("Revendedor")]
    [InternalValue("R")]
    Retailer,

    /// <summary>
    /// Use the classification of the TOP (Usar a da TOP).
    /// </summary>
    [HumanReadable("Usar a da TOP")]
    [InternalValue("T")]
    UseTop,

    /// <summary>
    /// Taxpayer customer (Consumidor Contribuinte).
    /// </summary>
    [HumanReadable("Consumidor Contribuinte")]
    [InternalValue("X")]
    TaxpayerCustomer,
}
