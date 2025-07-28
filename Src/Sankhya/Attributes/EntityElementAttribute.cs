using System;

namespace Sankhya.Attributes;

/// <summary>
/// Specifies that a property is an entity element with a given name and an option to ignore inline references.
/// </summary>
/// <remarks>This attribute can be applied to properties and allows multiple instances on the same property.</remarks>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class EntityElementAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityElementAttribute" /> class.
    /// </summary>
    /// <param name="elementName">The name of the entity element.</param>
    /// <param name="ignoreInlineReference">Indicates whether to ignore inline references. Default is false.</param>
    public EntityElementAttribute(string elementName, bool ignoreInlineReference = false)
    {
        ElementName = elementName;
        IgnoreInlineReference = ignoreInlineReference;
    }

    /// <summary>
    /// Gets the name of the entity element.
    /// </summary>
    /// <value>The name of the element.</value>
    public string ElementName { get; }

    /// <summary>
    /// Gets a value indicating whether to ignore inline references.
    /// </summary>
    /// <value><c>true</c> if [ignore inline reference]; otherwise, <c>false</c>.</value>
    public bool IgnoreInlineReference { get; }
}
