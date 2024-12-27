using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum FiscalInvoiceStatus
{
    [InternalValue("I")]
    [HumanReadable("Enviada")]
    Sent,

    [InternalValue("D")]
    [HumanReadable("Denegada")]
    Denied,

    [InternalValue("A")]
    [HumanReadable("Aprovada")]
    Approved,

    [InternalValue("E")]
    [HumanReadable("Aguardando autorização")]
    WaitingAuthorization,

    [InternalValue("R")]
    [HumanReadable("Aguardando correção")]
    WaitingCorrection,

    [InternalValue("V")]
    [HumanReadable("Com erro de validação")]
    ValidationError,

    [InternalValue("P")]
    [HumanReadable("Pendente de retorno")]
    PendingReturn,

    [InternalValue("S")]
    [HumanReadable("Enviada DPEC")]
    SentDpec,

    [InternalValue("M")]
    [HumanReadable("Não é NF-e")]
    NotNfe,

    [InternalValue("M")]
    [HumanReadable("Não é NFS-e")]
    NotNfse,

    [InternalValue("T")]
    [HumanReadable("NF-e terceiro")]
    NfeThird,
}
