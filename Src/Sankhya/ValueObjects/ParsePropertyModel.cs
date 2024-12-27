using Sankhya.Attributes;

namespace Sankhya.ValueObjects;

/// <summary>
/// Represents a model for parsing properties with various attributes.
/// </summary>
public sealed class ParsePropertyModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParsePropertyModel"/> class.
    /// </summary>
    public ParsePropertyModel()
    {
        IsCriteria = true;
        CustomData = new();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the property is ignored.
    /// </summary>
    public bool IsIgnored { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property is a criteria.
    /// </summary>
    public bool IsCriteria { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property is an entity key.
    /// </summary>
    public bool IsEntityKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property is an entity reference.
    /// </summary>
    public bool IsEntityReference { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property is an inline entity reference.
    /// </summary>
    public bool IsEntityReferenceInline { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to ignore inline entity references.
    /// </summary>
    public bool IgnoreEntityReferenceInline { get; set; }

    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Gets or sets the custom relation name for the property.
    /// </summary>
    public string CustomRelationName { get; set; }

    /// <summary>
    /// Gets or sets the custom data attribute for the property.
    /// </summary>
    public EntityCustomDataAttribute CustomData { get; set; }
}
