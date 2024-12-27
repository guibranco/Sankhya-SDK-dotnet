namespace Sankhya.RequestHelpers;

public static class RequestRetryDelay
{
    public const int Free = 10;

    public const int Stable = 15;

    public const int Unstable = 30;

    public const int Breakdown = 90;
}
