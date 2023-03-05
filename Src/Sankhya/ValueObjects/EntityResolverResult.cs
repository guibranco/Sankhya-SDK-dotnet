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
namespace Sankhya.ValueObjects;

using System.Collections.Generic;
using Sankhya.Service;

/// <summary>
/// Class EntityResolverResult. This class cannot be inherited.
/// </summary>
public sealed class EntityResolverResult
{
    /// <summary>
    /// The name
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The field values
    /// </summary>
    public readonly List<FieldValue> FieldValues;

    /// <summary>
    /// The keys
    /// </summary>
    public readonly List<FieldValue> Keys;

    /// <summary>
    /// The criteria
    /// </summary>
    public readonly List<Criteria> Criteria;

    /// <summary>
    /// The fields
    /// </summary>
    public readonly List<Field> Fields;

    /// <summary>
    /// The references
    /// </summary>
    public readonly Dictionary<string, List<Field>> References;

    /// <summary>
    /// The literal criteria
    /// </summary>
    public readonly LiteralCriteria LiteralCriteria;

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
}