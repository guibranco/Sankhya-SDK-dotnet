// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceName.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;
using Sankhya.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum ServiceName
/// </summary>
public enum ServiceName
{
    /// <summary>
    /// The test
    /// </summary>
    [InternalValue("test")]
    [HumanReadable("Test")]
    [Service(ServiceModule.None, ServiceCategory.None, ServiceType.None)]
    Test,

    /// <summary>
    /// The crud find
    /// </summary>
    [InternalValue("crud.find")]
    [HumanReadable("CRUD - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudFind,

    /// <summary>
    /// The crud remove
    /// </summary>
    [InternalValue("crud.remove")]
    [HumanReadable("CRUD - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudRemove,

    /// <summary>
    /// The crud save
    /// </summary>
    [InternalValue("crud.save")]
    [HumanReadable("CRUD - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudSave,

    /// <summary>
    /// The crud service find
    /// </summary>
    [InternalValue("CRUDServiceProvider.loadRecords")]
    [HumanReadable("CRUD Service Provider - Retrieve")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Retrieve)]
    CrudServiceFind,

    /// <summary>
    /// The crud service remove
    /// </summary>
    [InternalValue("CRUDServiceProvider.removeRecord")]
    [HumanReadable("CRUD Service Provider - Remove")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.NonTransactional)]
    CrudServiceRemove,

    /// <summary>
    /// The crud service save
    /// </summary>
    [InternalValue("CRUDServiceProvider.saveRecord")]
    [HumanReadable("CRUD Service Provider - Create/Update")]
    [Service(ServiceModule.Mge, ServiceCategory.Crud, ServiceType.Transactional)]
    CrudServiceSave,

    /// <summary>
    /// The login
    /// </summary>
    [InternalValue("MobileLoginSP.login")]
    [HumanReadable("Login")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Login,

    /// <summary>
    /// The logout
    /// </summary>
    [InternalValue("MobileLoginSP.logout")]
    [HumanReadable("Logout")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    Logout,

    /// <summary>
    /// The nfe get authorization
    /// </summary>
    [InternalValue("ServicosNfeSP.buscaProcessamentoLote")]
    [HumanReadable("NF-e - Get Authorization")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.Retrieve)]
    NfeGetAuthorization,

    /// <summary>
    /// The nfe generate lot
    /// </summary>
    [InternalValue("ServicosNfeSP.gerarLote")]
    [HumanReadable("NF-e - Generate Lot")]
    [Service(ServiceModule.Mgecom, ServiceCategory.FiscalInvoice, ServiceType.NonTransactional)]
    NfeGenerateLot,

    /// <summary>
    /// The invoice include
    /// </summary>
    [InternalValue("CACSP.incluirNota")]
    [HumanReadable("Include Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceInclude,

    /// <summary>
    /// The invoice header include
    /// </summary>
    [InternalValue("CACSP.incluirAlterarCabecalhoNota")]
    [HumanReadable("Include/Change Invoice Header")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceHeaderInclude,

    /// <summary>
    /// The invoice item include
    /// </summary>
    [InternalValue("CACSP.incluirAlterarItemNota")]
    [HumanReadable("Include/Change Invoice Item")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceItemInclude,

    /// <summary>
    /// The invoice bill
    /// </summary>
    [InternalValue("SelecaoDocumentoSP.faturar")]
    [HumanReadable("Bill Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceBill,

    /// <summary>
    /// The invoice accompaniments
    /// </summary>
    [InternalValue("ServicosNfeSP.getAcompanhamentosNota")]
    [HumanReadable("Invoice Accompaniment")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Retrieve)]
    InvoiceAccompaniments,

    /// <summary>
    /// The invoice automatic low
    /// </summary>
    [InternalValue("BaixaAutomaticaSP.baixar")]
    [HumanReadable("Automatic Low")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceAutomaticLow,

    /// <summary>
    /// The invoice confirm
    /// </summary>
    [InternalValue("CACSP.confirmarNota")]
    [HumanReadable("Invoice Confirmation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceConfirm,

    /// <summary>
    /// The invoice cancel
    /// </summary>
    [InternalValue("CACSP.cancelarNota")]
    [HumanReadable("Invoice Cancellation")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceCancel,

    /// <summary>
    /// The invoice duplicate
    /// </summary>
    [InternalValue("CACSP.duplicarNota")]
    [HumanReadable("Invoice Duplication")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.Transactional)]
    InvoiceDuplicate,

    /// <summary>
    /// The invoice remove
    /// </summary>
    [InternalValue("CACSP.excluirNotas")]
    [HumanReadable("Exclude/Remove Invoice")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceRemove,

    /// <summary>
    /// The invoice item remove
    /// </summary>
    [InternalValue("CACSP.excluirItemNota")]
    [HumanReadable("Exclude/Remove Invoice Item")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceItemRemove,

    /// <summary>
    /// The invoice bind with order
    /// </summary>
    [InternalValue("CACSP.ligarPedidoNota")]
    [HumanReadable("Bind Invoice With Order")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceBindWithOrder,

    /// <summary>
    /// The invoice flag as not pending
    /// </summary>
    [InternalValue("CACSP.marcarPedidosComoNaoPendentes")]
    [HumanReadable("Flag orders as not pending")]
    [Service(ServiceModule.Mgecom, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    InvoiceFlagAsNotPending,

    /// <summary>
    /// The financial reversal
    /// </summary>
    [InternalValue("BaixaFinanceiroSP.estornarTitulo")]
    [HumanReadable("Financial Reversal")]
    [Service(ServiceModule.Mge, ServiceCategory.Invoice, ServiceType.NonTransactional)]
    FinancialReversal,

    /// <summary>
    /// The warning receive
    /// </summary>
    [InternalValue("AvisoSistemaSP.getNovosAvisos")]
    [HumanReadable("Receive Warnings")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Retrieve)]
    WarningReceive,

    /// <summary>
    /// The warning send
    /// </summary>
    [InternalValue("AvisoSistemaSP.enviarAviso")]
    [HumanReadable("Send Warning")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    WarningSend,

    /// <summary>
    /// The message send
    /// </summary>
    [InternalValue("AvisoSistemaSP.enviarMensagem")]
    [HumanReadable("Send Message")]
    [Service(ServiceModule.Mge, ServiceCategory.Communication, ServiceType.Transactional)]
    MessageSend,

    /// <summary>
    /// The file open
    /// </summary>
    [InternalValue("RepositorioArquivoSP.abreArquivo")]
    [HumanReadable("File Repository - Open File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.Retrieve)]
    FileOpen,

    /// <summary>
    /// The file delete
    /// </summary>
    [InternalValue("ImportacaoImagemSP.deletaArquivos")]
    [HumanReadable("File Repository - Delete File")]
    [Service(ServiceModule.Mge, ServiceCategory.File, ServiceType.NonTransactional)]
    FileDelete,

    /// <summary>
    /// The session get all
    /// </summary>
    [InternalValue("SessionManagerSP.getCoreSessions")]
    [HumanReadable("Get Core Sessions")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionGetAll,

    /// <summary>
    /// The session kill
    /// </summary>
    [InternalValue("SessionManagerSP.killSession")]
    [HumanReadable("Kill Session")]
    [Service(ServiceModule.Mge, ServiceCategory.Authorization, ServiceType.Retrieve)]
    SessionKill,

    /// <summary>
    /// The unlink shipping
    /// </summary>
    [InternalValue("MovimentacaoFinanceiraSP.desvincularRemessa")]
    [HumanReadable("Unlink shipping")]
    [Service(ServiceModule.Mgefin, ServiceCategory.Invoice, ServiceType.Transactional)]
    UnlinkShipping,
}
