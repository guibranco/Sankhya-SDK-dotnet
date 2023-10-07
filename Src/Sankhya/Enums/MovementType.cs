// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="MovementType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Enum MovementType
/// </summary>
public enum MovementType
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// The deposit
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("NF Depósito")]
    Deposit,

    /// <summary>
    /// The warrant
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("PD Devol. / Procuração / Warrant")]
    Warrant,

    /// <summary>
    /// The output
    /// </summary>
    [InternalValue("3")]
    [HumanReadable("Saídas")]
    Output,

    /// <summary>
    /// The billing
    /// </summary>
    [InternalValue("4")]
    [HumanReadable("Faturamento")]
    Billing,

    /// <summary>
    /// The RD8
    /// </summary>
    [InternalValue("8")]
    [HumanReadable("RD8")]
    Rd8,

    /// <summary>
    /// The bank movement
    /// </summary>
    [InternalValue("B")]
    [HumanReadable("Movimento bancário")]
    BankMovement,

    /// <summary>
    /// The purchase
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Compra")]
    Purchase,

    /// <summary>
    /// The sales return
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Devolução de venda")]
    SalesReturn,

    /// <summary>
    /// The purchase return
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Devolução de compra")]
    PurchaseReturn,

    /// <summary>
    /// The production
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Produção")]
    Production,

    /// <summary>
    /// The payment
    /// </summary>
    [InternalValue("G")]
    [HumanReadable("Pagamento")]
    Payment,

    /// <summary>
    /// The financial
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Financeiro")]
    Financial,

    /// <summary>
    /// The request order
    /// </summary>
    [InternalValue("J")]
    [HumanReadable("Pedido de Requisição")]
    RequestOrder,

    /// <summary>
    /// The transfer order
    /// </summary>
    [InternalValue("K")]
    [HumanReadable("Pedido de Transferência")]
    TransferOrder,

    /// <summary>
    /// The request return
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Devolução de Requisição")]
    RequestReturn,

    /// <summary>
    /// The transfer return
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Devolução de Transferência")]
    TransferReturn,

    /// <summary>
    /// The input
    /// </summary>
    [InternalValue("N")]
    [HumanReadable("Entradas")]
    Input,

    /// <summary>
    /// The purchase order
    /// </summary>
    [InternalValue("O")]
    [HumanReadable("Pedido de compra")]
    PurchaseOrder,

    /// <summary>
    /// The sales order
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Pedido de venda")]
    SalesOrder,

    /// <summary>
    /// The request
    /// </summary>
    [InternalValue("Q")]
    [HumanReadable("Requisição")]
    Request,

    /// <summary>
    /// The receipt
    /// </summary>
    [InternalValue("R")]
    [HumanReadable("Recebimento")]
    Receipt,

    /// <summary>
    /// The transfer
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Transferência")]
    Transfer,

    /// <summary>
    /// The sales
    /// </summary>
    [InternalValue("V")]
    [HumanReadable("Venda")]
    Sales,

    /// <summary>
    /// The model
    /// </summary>
    [InternalValue("Z")]
    [HumanReadable("Modelo")]
    Model
}
