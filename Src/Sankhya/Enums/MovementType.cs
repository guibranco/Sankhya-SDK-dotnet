using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of movement.
/// </summary>
public enum MovementType
{
    /// <summary>
    /// No movement.
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// Deposit invoice.
    /// </summary>
    [InternalValue("1")]
    [HumanReadable("NF Depósito")]
    Deposit,

    /// <summary>
    /// Return / Proxy / Warrant.
    /// </summary>
    [InternalValue("2")]
    [HumanReadable("PD Devol. / Procuração / Warrant")]
    Warrant,

    /// <summary>
    /// Outputs.
    /// </summary>
    [InternalValue("3")]
    [HumanReadable("Saídas")]
    Output,

    /// <summary>
    /// Billing.
    /// </summary>
    [InternalValue("4")]
    [HumanReadable("Faturamento")]
    Billing,

    /// <summary>
    /// RD8.
    /// </summary>
    [InternalValue("8")]
    [HumanReadable("RD8")]
    Rd8,

    /// <summary>
    /// Bank movement.
    /// </summary>
    [InternalValue("B")]
    [HumanReadable("Movimento bancário")]
    BankMovement,

    /// <summary>
    /// Purchase.
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("Compra")]
    Purchase,

    /// <summary>
    /// Sales return.
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Devolução de venda")]
    SalesReturn,

    /// <summary>
    /// Purchase return.
    /// </summary>
    [InternalValue("E")]
    [HumanReadable("Devolução de compra")]
    PurchaseReturn,

    /// <summary>
    /// Production.
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Produção")]
    Production,

    /// <summary>
    /// Payment.
    /// </summary>
    [InternalValue("G")]
    [HumanReadable("Pagamento")]
    Payment,

    /// <summary>
    /// Financial.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Financeiro")]
    Financial,

    /// <summary>
    /// Request order.
    /// </summary>
    [InternalValue("J")]
    [HumanReadable("Pedido de Requisição")]
    RequestOrder,

    /// <summary>
    /// Transfer order.
    /// </summary>
    [InternalValue("K")]
    [HumanReadable("Pedido de Transferência")]
    TransferOrder,

    /// <summary>
    /// Request return.
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Devolução de Requisição")]
    RequestReturn,

    /// <summary>
    /// Transfer return.
    /// </summary>
    [InternalValue("M")]
    [HumanReadable("Devolução de Transferência")]
    TransferReturn,

    /// <summary>
    /// Input.
    /// </summary>
    [InternalValue("N")]
    [HumanReadable("Entradas")]
    Input,

    /// <summary>
    /// Purchase order.
    /// </summary>
    [InternalValue("O")]
    [HumanReadable("Pedido de compra")]
    PurchaseOrder,

    /// <summary>
    /// Sales order.
    /// </summary>
    [InternalValue("P")]
    [HumanReadable("Pedido de venda")]
    SalesOrder,

    /// <summary>
    /// Request.
    /// </summary>
    [InternalValue("Q")]
    [HumanReadable("Requisição")]
    Request,

    /// <summary>
    /// Receipt.
    /// </summary>
    [InternalValue("R")]
    [HumanReadable("Recebimento")]
    Receipt,

    /// <summary>
    /// Transfer.
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Transferência")]
    Transfer,

    /// <summary>
    /// Sales.
    /// </summary>
    [InternalValue("V")]
    [HumanReadable("Venda")]
    Sales,

    /// <summary>
    /// Model.
    /// </summary>
    [InternalValue("Z")]
    [HumanReadable("Modelo")]
    Model,
}
