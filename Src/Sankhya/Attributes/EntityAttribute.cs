using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies that a class represents an entity with a given name.
/// </summary>
/// <remarks>
/// This attribute is used to mark classes that represent entities in the Sankhya SDK.
/// </remarks>
/// <example>
/// <code>
/// [Entity("Customer")]
/// public class Customer
/// {
///     // Class implementation
/// }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class EntityAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityAttribute"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    public EntityAttribute(string name) => Name = name;

    /// <summary>
    /// Gets the name of the entity.
    /// </summary>
    public string Name { get; }
}
