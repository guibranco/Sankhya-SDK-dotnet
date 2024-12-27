using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies that a property should be ignored by the entity framework.
/// </summary>
/// <remarks>
/// This attribute can be applied to properties to indicate that they should not be included in the entity mapping.
/// </remarks>
/// <example>
/// <code>
/// [EntityIgnore]
/// public string IgnoredProperty { get; set; }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class EntityIgnoreAttribute : Attribute { }
