using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the service environments.
/// </summary>
public enum ServiceEnvironment
{
    /// <summary>
    /// No environment.
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// Production environment.
    /// </summary>
    [InternalValue("8180")]
    [HumanReadable("Produção")]
    Production,

    /// <summary>
    /// Sandbox environment.
    /// </summary>
    [InternalValue("8280")]
    [HumanReadable("Sandbox")]
    Sandbox,

    /// <summary>
    /// Training environment.
    /// </summary>
    [InternalValue("8380")]
    [HumanReadable("Treinamento")]
    Training,
}
