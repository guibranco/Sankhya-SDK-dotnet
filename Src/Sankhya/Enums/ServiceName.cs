using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the names of services.
/// </summary>
public enum ServiceName
{
    /// <summary>
    /// Test.
    /// </summary>
    [InternalValue("test")]
    [HumanReadable("Test")]
    [Service(ServiceModule.None, ServiceCategory.None, ServiceType.None)]
    Test,

    /// <summary>
    /// CRUD - Find.
    /// </summary>
    [InternalValue("crud.find")]
    [HumanReadable("CRUD - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudFind,

    /// <summary>
    /// CRUD - Remove.
    /// </summary>
    [InternalValue("crud.remove")]
    [HumanReadable("CRUD - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudRemove,

    /// <summary>
    /// CRUD - Create/Update.
    /// </summary>
    [InternalValue("crud.save")]
    [HumanReadable("CRUD - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudSave,

    /// <summary>
    /// CRUD Service Provider - Retrieve.
    /// </summary>
    [InternalValue("CRUDServiceProvider.loadRecords")]
    [HumanReadable("CRUD Service Provider - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudServiceFind,

    /// <summary>
    /// CRUD Service Provider - Remove.
    /// </summary>
    [InternalValue("CRUDServiceProvider.removeRecord")]
    [HumanReadable("CRUD Service Provider - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudServiceRemove,

    /// <summary>
    /// CRUD Service Provider - Create/Update.
    /// </summary>
    [InternalValue("CRUDServiceProvider.saveRecord")]
    [HumanReadable("CRUD Service Provider - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudServiceSave,

    /// <summary>
    /// Login.
    /// </summary>
    [InternalValue("MobileLoginSP.login")]
    [HumanReadable("Login")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Login,

    /// <summary>
    /// Logout.
    /// </summary>
    [InternalValue("MobileLoginSP.logout")]
    [HumanReadable("Logout")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Logout,

    /// <summary>
    /// NF-e - Get Authorization.
    /// </summary>
    [InternalValue("ServicosNfeSP.buscaProcessamentoLote")]
    [HumanReadable("NF-e - Get Authorization")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.Retrieve)]
    NfeGetAuthorization,

    /// <summary>
    /// NF-e - Generate Lot.
    /// </summary>
    [InternalValue("ServicosNfeSP.gerarLote")]
    [HumanReadable("NF-e - Generate Lot")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.NonTransactional)]
    NfeGenerateLot,

    /// <summary>
    /// Include Invoice.
    /// </summary>
    [InternalValue("CACSP.incluirNota")]
    [HumanReadable("Include Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceInclude,

    /// <summary>
    /// Include/Change Invoice Header.
    /// </summary>
    [InternalValue("CACSP.incluirAlterarCabecalhoNota")]
    [HumanReadable("Include/Change Invoice Header")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceHeaderInclude,

    /// <summary>
    /// Include/Change Invoice Item.
    /// </summary>
    [InternalValue("CACSP.incluirAlterarItemNota")]
    [HumanReadable("Include/Change Invoice Item")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceItemInclude,

    [InternalValue("SelecaoDocumentoSP.faturar")]
    [HumanReadable("Bill Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceBill,

    [InternalValue("ServicosNfeSP.getAcompanhamentosNota")]
    [HumanReadable("Invoice Accompaniment")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Retrieve)]
    InvoiceAccompaniments,

    /// <summary>
    /// Invoice - Get Invoice.
    /// </summary>
    [InternalValue("BaixaAutomaticaSP.baixar")]
    [HumanReadable("Automatic Low")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceAutomaticLow,

    /// <summary>
    /// Invoice - Confirm Invoice.
    /// </summary>
    [InternalValue("CACSP.confirmarNota")]
    [HumanReadable("Invoice Confirmation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceConfirm,

    /// <summary>
    /// Invoice - Cancel Invoice.
    /// </summary>
    [InternalValue("CACSP.cancelarNota")]
    [HumanReadable("Invoice Cancellation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceCancel,

    /// <summary>
    /// Invoice - Duplicate Invoice.
    /// </summary>
    [InternalValue("CACSP.duplicarNota")]
    [HumanReadable("Invoice Duplication")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceDuplicate,

    /// <summary>
    /// Invoice - Exclude/Remove Invoice.
    /// </summary>
    [InternalValue("CACSP.excluirNotas")]
    [HumanReadable("Exclude/Remove Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceRemove,

    /// <summary>
    /// Invoice - Exclude/Remove Invoice Item.
    /// </summary>
    [InternalValue("CACSP.excluirItemNota")]
    [HumanReadable("Exclude/Remove Invoice Item")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceItemRemove,

    /// <summary>
    /// Invoice - Bind Invoice With Order.
    /// </summary>
    [InternalValue("CACSP.ligarPedidoNota")]
    [HumanReadable("Bind Invoice With Order")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceBindWithOrder,

    /// <summary>
    /// Invoice - Flag orders as not pending.
    /// </summary>
    [InternalValue("CACSP.marcarPedidosComoNaoPendentes")]
    [HumanReadable("Flag orders as not pending")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceFlagAsNotPending,

    /// <summary>
    /// Invoice - Get Invoice.
    /// </summary>
    [InternalValue("BaixaFinanceiroSP.estornarTitulo")]
    [HumanReadable("Financial Reversal")]
    [Service(ServiceModule.Mge, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    FinancialReversal,

    /// <summary>
    /// Receive Warnings.
    /// </summary>
    [InternalValue("AvisoSistemaSP.getNovosAvisos")]
    [HumanReadable("Receive Warnings")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Retrieve)]
    WarningReceive,

    /// <summary>
    /// Send Warning.
    /// </summary>
    [InternalValue("AvisoSistemaSP.enviarAviso")]
    [HumanReadable("Send Warning")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    WarningSend,

    /// <summary>
    /// Send Message.
    /// </summary>
    [InternalValue("AvisoSistemaSP.enviarMensagem")]
    [HumanReadable("Send Message")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    MessageSend,

    /// <summary>
    /// File Repository - Open File.
    /// </summary>
    [InternalValue("RepositorioArquivoSP.abreArquivo")]
    [HumanReadable("File Repository - Open File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.Retrieve)]
    FileOpen,

    /// <summary>
    /// File Repository - Save File.
    /// </summary>
    [InternalValue("ImportacaoImagemSP.deletaArquivos")]
    [HumanReadable("File Repository - Delete File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.NonTransactional)]
    FileDelete,

    /// <summary>
    /// Get Core Sessions.
    /// </summary>
    [InternalValue("SessionManagerSP.getCoreSessions")]
    [HumanReadable("Get Core Sessions")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionGetAll,

    /// <summary>
    /// Kill Session.
    /// </summary>
    [InternalValue("SessionManagerSP.killSession")]
    [HumanReadable("Kill Session")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionKill,

    /// <summary>
    /// Unlink shipping.
    /// </summary>
    [InternalValue("MovimentacaoFinanceiraSP.desvincularRemessa")]
    [HumanReadable("Unlink shipping")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.Transactional)]
    UnlinkShipping,
}
