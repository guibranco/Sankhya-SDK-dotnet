namespace Sankhya;

public class RequestRetryData
{
    public string LockKey { get; set; }

    public int RetryCount { get; set; }

    public int RetryDelay { get; set; }
}
