using System;
using Sankhya.Enums;

namespace Sankhya;

/// <summary>
/// The low level sankhya wrapper class.
/// </summary>
/// <seealso cref="SankhyaWrapper" />
internal sealed class LowLevelSankhyaWrapper : SankhyaWrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SankhyaWrapper" /> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="port">The port.</param>
    /// <param name="requestType">Type of the request.</param>
    public LowLevelSankhyaWrapper(string host, int port, ServiceRequestType requestType)
        : base(host, port, requestType) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SankhyaWrapper"/> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="port">The port.</param>
    /// <param name="requestType">Type of the request.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="databaseName">Name of the database.</param>
    /// <exception cref="ArgumentOutOfRangeException">environment - null</exception>
    public LowLevelSankhyaWrapper(
        string host,
        int port,
        ServiceRequestType requestType,
        ServiceEnvironment environment,
        string databaseName = null
    )
        : base(host, port, requestType, environment, databaseName) { }
}
