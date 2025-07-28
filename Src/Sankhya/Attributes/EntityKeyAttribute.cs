using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies that a property is an entity key.
/// </summary>
/// <remarks>This attribute is used to mark properties that represent the key of an entity.</remarks>
[AttributeUsage(AttributeTargets.Property)]
public sealed class EntityKeyAttribute : Attribute { }
