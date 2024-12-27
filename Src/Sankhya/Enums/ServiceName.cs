using CrispyWaffle.Attributes;
using Sankhya.Attributes;

namespace Sankhya.Enums;

public enum ServiceName
{
    [InternalValue("test")]
    [HumanReadable("Test")]
    [Service(ServiceModule.None, ServiceCategory.None, ServiceType.None)]
    Test,

    [InternalValue("crud.find")]
    [HumanReadable("CRUD - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudFind,

    [InternalValue("crud.remove")]
    [HumanReadable("CRUD - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudRemove,

    [InternalValue("crud.save")]
    [HumanReadable("CRUD - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudSave,

    [InternalValue("CRUDServiceProvider.loadRecords")]
    [HumanReadable("CRUD Service Provider - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudServiceFind,

    [InternalValue("CRUDServiceProvider.removeRecord")]
    [HumanReadable("CRUD Service Provider - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudServiceRemove,

    [InternalValue("CRUDServiceProvider.saveRecord")]
    [HumanReadable("CRUD Service Provider - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudServiceSave,

    [InternalValue("MobileLoginSP.login")]
    [HumanReadable("Login")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Login,

    [InternalValue("MobileLoginSP.logout")]
    [HumanReadable("Logout")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Logout,

    [InternalValue("ServicosNfeSP.buscaProcessamentoLote")]
    [HumanReadable("NF-e - Get Authorization")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.Retrieve)]
    NfeGetAuthorization,

    [InternalValue("ServicosNfeSP.gerarLote")]
    [HumanReadable("NF-e - Generate Lot")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.NonTransactional)]
    NfeGenerateLot,

    [InternalValue("CACSP.incluirNota")]
    [HumanReadable("Include Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceInclude,

    [InternalValue("CACSP.incluirAlterarCabecalhoNota")]
    [HumanReadable("Include/Change Invoice Header")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceHeaderInclude,

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

    [InternalValue("BaixaAutomaticaSP.baixar")]
    [HumanReadable("Automatic Low")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceAutomaticLow,

    [InternalValue("CACSP.confirmarNota")]
    [HumanReadable("Invoice Confirmation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceConfirm,

    [InternalValue("CACSP.cancelarNota")]
    [HumanReadable("Invoice Cancellation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceCancel,

    [InternalValue("CACSP.duplicarNota")]
    [HumanReadable("Invoice Duplication")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceDuplicate,

    [InternalValue("CACSP.excluirNotas")]
    [HumanReadable("Exclude/Remove Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceRemove,

    [InternalValue("CACSP.excluirItemNota")]
    [HumanReadable("Exclude/Remove Invoice Item")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceItemRemove,

    [InternalValue("CACSP.ligarPedidoNota")]
    [HumanReadable("Bind Invoice With Order")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceBindWithOrder,

    [InternalValue("CACSP.marcarPedidosComoNaoPendentes")]
    [HumanReadable("Flag orders as not pending")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceFlagAsNotPending,

    [InternalValue("BaixaFinanceiroSP.estornarTitulo")]
    [HumanReadable("Financial Reversal")]
    [Service(ServiceModule.Mge, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    FinancialReversal,

    [InternalValue("AvisoSistemaSP.getNovosAvisos")]
    [HumanReadable("Receive Warnings")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Retrieve)]
    WarningReceive,

    [InternalValue("AvisoSistemaSP.enviarAviso")]
    [HumanReadable("Send Warning")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    WarningSend,

    [InternalValue("AvisoSistemaSP.enviarMensagem")]
    [HumanReadable("Send Message")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    MessageSend,

    [InternalValue("RepositorioArquivoSP.abreArquivo")]
    [HumanReadable("File Repository - Open File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.Retrieve)]
    FileOpen,

    [InternalValue("ImportacaoImagemSP.deletaArquivos")]
    [HumanReadable("File Repository - Delete File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.NonTransactional)]
    FileDelete,

    [InternalValue("SessionManagerSP.getCoreSessions")]
    [HumanReadable("Get Core Sessions")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionGetAll,

    [InternalValue("SessionManagerSP.killSession")]
    [HumanReadable("Kill Session")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionKill,

    [InternalValue("MovimentacaoFinanceiraSP.desvincularRemessa")]
    [HumanReadable("Unlink shipping")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.Transactional)]
    UnlinkShipping,
}
