namespace Sankhya.Enums;

using CrispyWaffle.Attributes;

/// <summary>
/// Enum ServiceEnvironment
/// </summary>
public enum ServiceEnvironment
{
    /// <summary>
    /// The none
    /// </summary>
    [InternalValue("0")]
    [HumanReadable("Nenhum")]
    None,

    /// <summary>
    /// The production
    /// </summary>
    [InternalValue("8180")]
    [HumanReadable("Produção")]
    Production,

    /// <summary>
    /// The sandbox
    /// </summary>
    [InternalValue("8280")]
    [HumanReadable("Sandbox")]
    Sandbox,

    /// <summary>
    /// The training
    /// </summary>
    [InternalValue("8380")]
    [HumanReadable("Treinamento")]
    Training
}