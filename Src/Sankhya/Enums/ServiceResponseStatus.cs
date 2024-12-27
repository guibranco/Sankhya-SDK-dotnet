namespace Sankhya.Enums;

/// <summary>
/// Represents the status of a service response.
/// </summary>
public enum ServiceResponseStatus
{
    /// <summary>
    /// Indicates an error in the service response.
    /// </summary>
    Error = 0,

    /// <summary>
    /// Indicates a successful service response.
    /// </summary>
    Ok = 1,

    /// <summary>
    /// Indicates an informational service response.
    /// </summary>
    Info = 2,

    /// <summary>
    /// Indicates a timeout in the service response.
    /// </summary>
    Timeout = 3,

    /// <summary>
    /// Indicates that the service was canceled.
    /// </summary>
    ServiceCanceled = 4,
}
