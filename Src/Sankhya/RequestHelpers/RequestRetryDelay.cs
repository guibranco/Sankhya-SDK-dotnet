namespace Sankhya.RequestHelpers;

/// <summary>
/// Class RequestRetryDelay.
/// </summary>
public static class RequestRetryDelay
{
    /// <summary>
    /// The free.
    /// </summary>
    public const int Free = 10;

    /// <summary>
    /// The stable.
    /// </summary>
    public const int Stable = 15;

    /// <summary>
    /// The unstable.
    /// </summary>
    public const int Unstable = 30;

    /// <summary>
    /// The breakdown.
    /// </summary>
    public const int Breakdown = 90;
}
