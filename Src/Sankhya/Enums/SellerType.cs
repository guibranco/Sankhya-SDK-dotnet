using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum SellerType
{
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    [HumanReadable("Comprador")]
    [InternalValue("C")]
    Buyer,

    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,

    [HumanReadable("Supervisor")]
    [InternalValue("S")]
    Supervisor,

    [HumanReadable("Gerente")]
    [InternalValue("G")]
    Manager,

    [HumanReadable("Executante")]
    [InternalValue("E")]
    Performer,

    [HumanReadable("Representante")]
    [InternalValue("R")]
    Representative,

    [HumanReadable("Técnico")]
    [InternalValue("T")]
    Technician,
}
