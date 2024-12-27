using System.Collections.Generic;
using Sankhya.Service;

namespace Sankhya.ValueObjects;

/// <summary>
/// Represents the result of resolving an entity.
/// </summary>
public sealed class EntityResolverResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityResolverResult"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    public EntityResolverResult(string name)
    {
        Name = name;
        FieldValues = new();
        Keys = new();
        Criteria = new();
        Fields = new();
        References = new();
        LiteralCriteria = new();
    }

    /// <summary>
    /// Gets the name of the entity.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the list of field values for the entity.
    /// </summary>
    public List<FieldValue> FieldValues { get; }

    /// <summary>
    /// Gets the list of key field values for the entity.
    /// </summary>
    public List<FieldValue> Keys { get; }

    /// <summary>
    /// Gets the list of criteria for the entity.
    /// </summary>
    public List<Criteria> Criteria { get; }

    /// <summary>
    /// Gets the list of fields for the entity.
    /// </summary>
    public List<Field> Fields { get; }

    /// <summary>
    /// Gets the dictionary of references for the entity.
    /// </summary>
    public Dictionary<string, List<Field>> References { get; }

    /// <summary>
    /// Gets the literal criteria for the entity.
    /// </summary>
    public LiteralCriteria LiteralCriteria { get; }
}
