using System;
using Sankhya.Enums;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies the service attribute for a field, including the module, category, and type of the service.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class ServiceAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceAttribute"/> class with the specified module, category, and type.
    /// </summary>
    /// <param name="module">The module of the service.</param>
    /// <param name="category">The category of the service.</param>
    /// <param name="type">The type of the service.</param>
    public ServiceAttribute(ServiceModule module, ServiceCategory category, ServiceType type)
    {
        Type = type;
        Category = category;
        Module = module;
    }

    /// <summary>
    /// Gets the category of the service.
    /// </summary>
    public ServiceCategory Category { get; }

    /// <summary>
    /// Gets the module of the service.
    /// </summary>
    public ServiceModule Module { get; }

    /// <summary>
    /// Gets the type of the service.
    /// </summary>
    public ServiceType Type { get; }
}
