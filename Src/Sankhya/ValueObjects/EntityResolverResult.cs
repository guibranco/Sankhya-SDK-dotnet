// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityResolverResult.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Sankhya.Service;

namespace Sankhya.ValueObjects;

/// <summary>
/// Class EntityResolverResult. This class cannot be inherited.
/// </summary>
public sealed class EntityResolverResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityResolverResult" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
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
    /// The name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The field values
    /// </summary>
    public List<FieldValue> FieldValues { get; }

    /// <summary>
    /// The keys
    /// </summary>
    public List<FieldValue> Keys { get; }

    /// <summary>
    /// The criteria
    /// </summary>
    public List<Criteria> Criteria { get; }

    /// <summary>
    /// The fields
    /// </summary>
    public List<Field> Fields { get; }

    /// <summary>
    /// The references
    /// </summary>
    public Dictionary<string, List<Field>> References { get; }

    /// <summary>
    /// The literal criteria
    /// </summary>
    public LiteralCriteria LiteralCriteria { get; }
}
