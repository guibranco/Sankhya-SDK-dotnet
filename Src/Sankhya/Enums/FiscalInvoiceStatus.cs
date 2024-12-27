using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the status of a fiscal invoice.
/// </summary>
public enum FiscalInvoiceStatus
{
    /// <summary>
    /// The invoice has been sent.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Enviada")]
    Sent,

    /// <summary>
    /// The invoice has been denied.
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Denegada")]
    Denied,

    /// <summary>
    /// The invoice has been approved.
    /// </summary>
    [InternalValue("A")]
    [HumanReadable("Aprovada")]
    Approved,

    /// <summary>
    /// The invoice is waiting for authorization.
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Aguardando autorização")]
    WaitingAuthorization,

    /// <summary>
    /// The invoice is waiting for correction.
    /// </summary>
    [InternalValue("R")]
    [HumanReadable("Aguardando correção")]
    WaitingCorrection,

    /// <summary>
    /// The invoice has a validation error.
    /// </summary>
    [InternalValue("V")]
    [HumanReadable("Com erro de validação")]
    ValidationError,

    /// <summary>
    /// The invoice is pending return.
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Pendente de retorno")]
    PendingReturn,

    /// <summary>
    /// The invoice has been sent via DPEC.
    /// </summary>
    [InternalValue("S")]
    [HumanReadable("Enviada DPEC")]
    SentDpec,

    /// <summary>
    /// The invoice is not an NF-e.
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Não é NF-e")]
    NotNfe,

    /// <summary>
    /// The invoice is not an NFS-e.
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Não é NFS-e")]
    NotNfse,

    /// <summary>
    /// The invoice is a third-party NF-e.
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("NF-e terceiro")]
    NfeThird,
}
