using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum TradingSubType
{
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    [HumanReadable("A vista")]
    [InternalValue("1")]
    InCash,

    [HumanReadable("A prazo")]
    [InternalValue("2")]
    Deferred,

    [HumanReadable("Parcelada")]
    [InternalValue("3")]
    ParceledOut,

    [HumanReadable("Cheque pré-datado")]
    [InternalValue("4")]
    PostdatedCheck,

    [HumanReadable("Crediário")]
    [InternalValue("5")]
    InstallmentCredit,

    [HumanReadable("Financeira")]
    [InternalValue("6")]
    Financial,

    [HumanReadable("Cartão de crédito")]
    [InternalValue("7")]
    CreditCard,

    [HumanReadable("Cartão de débito")]
    [InternalValue("8")]
    DebitCard,
}
