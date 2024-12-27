using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies custom data attributes for an entity class or property.
/// </summary>
/// <remarks>
/// This attribute can be applied to classes and properties, and it allows multiple instances on the same element.
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
public sealed class EntityCustomDataAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the maximum length of the custom data.
    /// </summary>
    public int MaxLength { get; set; }
}
