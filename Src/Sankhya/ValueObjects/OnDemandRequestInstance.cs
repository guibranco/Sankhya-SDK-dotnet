using System;
using Sankhya.Enums;
using Sankhya.RequestWrappers;

namespace Sankhya.ValueObjects;

/// <summary>
/// Represents an instance of an on-demand request.
/// </summary>
public sealed class OnDemandRequestInstance
{
    /// <summary>
    /// Gets or sets the unique key for the request instance.
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    /// Gets or sets the service name for the request.
    /// </summary>
    public ServiceName Service { get; set; }

    /// <summary>
    /// Gets or sets the type of the request.
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// Gets or sets the instance of the request wrapper.
    /// </summary>
    public IOnDemandRequestWrapper Instance { get; set; }
}
