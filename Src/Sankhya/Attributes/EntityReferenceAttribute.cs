using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies that a property is an entity reference.
/// </summary>
/// <remarks>This attribute can be applied to properties to indicate that they reference another entity.</remarks>
[AttributeUsage(AttributeTargets.Property)]
public sealed class EntityReferenceAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityReferenceAttribute" /> class with an empty custom relation name.
    /// </summary>
    public EntityReferenceAttribute() => CustomRelationName = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityReferenceAttribute" /> class with a specified custom relation name.
    /// </summary>
    /// <param name="customRelationName">The custom relation name for the entity reference.</param>
    public EntityReferenceAttribute(string customRelationName) =>
        CustomRelationName = customRelationName;

    /// <summary>
    /// Gets the custom relation name for the entity reference.
    /// </summary>
    /// <value>The name of the custom relation.</value>
    public string CustomRelationName { get; }
}
