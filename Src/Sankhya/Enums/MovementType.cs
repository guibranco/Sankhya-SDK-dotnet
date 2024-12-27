using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum MovementType
{
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    [InternalValue("1")]
    [HumanReadable("NF Depósito")]
    Deposit,

    [InternalValue("2")]
    [HumanReadable("PD Devol. / Procuração / Warrant")]
    Warrant,

    [InternalValue("3")]
    [HumanReadable("Saídas")]
    Output,

    [InternalValue("4")]
    [HumanReadable("Faturamento")]
    Billing,

    [InternalValue("8")]
    [HumanReadable("RD8")]
    Rd8,

    [InternalValue("B")]
    [HumanReadable("Movimento bancário")]
    BankMovement,

    [InternalValue("C")]
    [HumanReadable("Compra")]
    Purchase,

    [InternalValue("D")]
    [HumanReadable("Devolução de venda")]
    SalesReturn,

    [InternalValue("E")]
    [HumanReadable("Devolução de compra")]
    PurchaseReturn,

    [InternalValue("F")]
    [HumanReadable("Produção")]
    Production,

    [InternalValue("G")]
    [HumanReadable("Pagamento")]
    Payment,

    [InternalValue("I")]
    [HumanReadable("Financeiro")]
    Financial,

    [InternalValue("J")]
    [HumanReadable("Pedido de Requisição")]
    RequestOrder,

    [InternalValue("K")]
    [HumanReadable("Pedido de Transferência")]
    TransferOrder,

    [InternalValue("L")]
    [HumanReadable("Devolução de Requisição")]
    RequestReturn,

    [InternalValue("M")]
    [HumanReadable("Devolução de Transferência")]
    TransferReturn,

    [InternalValue("N")]
    [HumanReadable("Entradas")]
    Input,

    [InternalValue("O")]
    [HumanReadable("Pedido de compra")]
    PurchaseOrder,

    [InternalValue("P")]
    [HumanReadable("Pedido de venda")]
    SalesOrder,

    [InternalValue("Q")]
    [HumanReadable("Requisição")]
    Request,

    [InternalValue("R")]
    [HumanReadable("Recebimento")]
    Receipt,

    [InternalValue("T")]
    [HumanReadable("Transferência")]
    Transfer,

    [InternalValue("V")]
    [HumanReadable("Venda")]
    Sales,

    [InternalValue("Z")]
    [HumanReadable("Modelo")]
    Model,
}
