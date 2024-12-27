using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the subtypes of trading.
/// </summary>
public enum TradingSubType
{
    /// <summary>
    /// No subtype.
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    /// <summary>
    /// In cash.
    /// </summary>
    [HumanReadable("A vista")]
    [InternalValue("1")]
    InCash,

    /// <summary>
    /// Deferred.
    /// </summary>
    [HumanReadable("A prazo")]
    [InternalValue("2")]
    Deferred,

    /// <summary>
    /// Parceled out.
    /// </summary>
    [HumanReadable("Parcelada")]
    [InternalValue("3")]
    ParceledOut,

    /// <summary>
    /// Postdated check.
    /// </summary>
    [HumanReadable("Cheque pré-datado")]
    [InternalValue("4")]
    PostdatedCheck,

    /// <summary>
    /// Installment credit.
    /// </summary>
    [HumanReadable("Crediário")]
    [InternalValue("5")]
    InstallmentCredit,

    /// <summary>
    /// Financial.
    /// </summary>
    [HumanReadable("Financeira")]
    [InternalValue("6")]
    Financial,

    /// <summary>
    /// Credit card.
    /// </summary>
    [HumanReadable("Cartão de crédito")]
    [InternalValue("7")]
    CreditCard,

    /// <summary>
    /// Debit card.
    /// </summary>
    [HumanReadable("Cartão de débito")]
    [InternalValue("8")]
    DebitCard,
}
