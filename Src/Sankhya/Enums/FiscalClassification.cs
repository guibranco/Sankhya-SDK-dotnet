using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum FiscalClassification
{
    [HumanReadable("Consumidor Final")]
    [InternalValue("C")]
    FinalCustomer,

    [HumanReadable("Isento de ICMS")]
    [InternalValue("I")]
    IcmsFree,

    [HumanReadable("Produtor Rural")]
    [InternalValue("P")]
    RuralProducer,

    [HumanReadable("Revendedor")]
    [InternalValue("R")]
    Retailer,

    [HumanReadable("Usar a da TOP")]
    [InternalValue("T")]
    UseTop,

    [HumanReadable("Consumidor Contribuinte")]
    [InternalValue("X")]
    TaxpayerCustomer,
}
