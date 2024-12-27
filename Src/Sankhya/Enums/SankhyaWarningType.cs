using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the types of warnings in Sankhya.
/// </summary>
public enum SankhyaWarningType
{
    /// <summary>
    /// No warning type.
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None = 0,

    /// <summary>
    /// User warning type.
    /// </summary>
    [InternalValue("usuario")]
    [HumanReadable("Usuário")]
    User = 1,

    /// <summary>
    /// Group warning type.
    /// </summary>
    [InternalValue("grupo")]
    [HumanReadable("Grupo")]
    Group = 2,
}
