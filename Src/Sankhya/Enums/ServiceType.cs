namespace Sankhya.Enums;

/// <summary>
/// Represents the type of service.
/// </summary>
public enum ServiceType
{
    /// <summary>
    /// No service type.
    /// </summary>
    None = 0,

    /// <summary>
    /// Retrieve service type.
    /// </summary>
    Retrieve = 1,

    /// <summary>
    /// Non-transactional service type.
    /// </summary>
    NonTransactional = 2,

    /// <summary>
    /// Transactional service type.
    /// </summary>
    Transactional = 3,
}
