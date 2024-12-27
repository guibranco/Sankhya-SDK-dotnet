using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of a seller.
/// </summary>
public enum SellerType
{
    /// <summary>
    /// No seller type.
    /// </summary>
    [HumanReadable("Nenhum")]
    [InternalValue("0")]
    None,

    /// <summary>
    /// Buyer.
    /// </summary>
    [HumanReadable("Comprador")]
    [InternalValue("C")]
    Buyer,

    /// <summary>
    /// Seller.
    /// </summary>
    [HumanReadable("Vendedor")]
    [InternalValue("V")]
    Seller,

    /// <summary>
    /// Supervisor.
    /// </summary>
    [HumanReadable("Supervisor")]
    [InternalValue("S")]
    Supervisor,

    /// <summary>
    /// Manager.
    /// </summary>
    [HumanReadable("Gerente")]
    [InternalValue("G")]
    Manager,

    /// <summary>
    /// Performer.
    /// </summary>
    [HumanReadable("Executante")]
    [InternalValue("E")]
    Performer,

    /// <summary>
    /// Representative.
    /// </summary>
    [HumanReadable("Representante")]
    [InternalValue("R")]
    Representative,

    /// <summary>
    /// Technician.
    /// </summary>
    [HumanReadable("Técnico")]
    [InternalValue("T")]
    Technician,
}
