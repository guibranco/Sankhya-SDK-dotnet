using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of a system parameter.
/// </summary>
public enum SystemParameterType
{
    /// <summary>
    /// No parameter type.
    /// </summary>
    [InternalValue("")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// Text parameter type.
    /// </summary>
    [InternalValue("T")]
    [HumanReadable("Texto")]
    Text,

    /// <summary>
    /// Date parameter type.
    /// </summary>
    [InternalValue("D")]
    [HumanReadable("Data")]
    Date,

    /// <summary>
    /// Decimal number parameter type.
    /// </summary>
    [InternalValue("F")]
    [HumanReadable("Número Decimal")]
    Decimal,

    /// <summary>
    /// Logical parameter type.
    /// </summary>
    [InternalValue("L")]
    [HumanReadable("Lógico")]
    Logical,

    /// <summary>
    /// List parameter type.
    /// </summary>
    [InternalValue("C")]
    [HumanReadable("List")]
    List,

    /// <summary>
    /// Integer number parameter type.
    /// </summary>
    [InternalValue("I")]
    [HumanReadable("Número Inteiro")]
    Integer,
}
