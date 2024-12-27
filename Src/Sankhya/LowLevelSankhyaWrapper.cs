using Sankhya.Enums;

namespace Sankhya;

internal sealed class LowLevelSankhyaWrapper : SankhyaWrapper
{
    public LowLevelSankhyaWrapper(string host, int port, ServiceRequestType requestType)
        : base(host, port, requestType) { }

    public LowLevelSankhyaWrapper(
        string host,
        int port,
        ServiceRequestType requestType,
        ServiceEnvironment environment,
        string databaseName = null
    )
        : base(host, port, requestType, environment, databaseName) { }
}
