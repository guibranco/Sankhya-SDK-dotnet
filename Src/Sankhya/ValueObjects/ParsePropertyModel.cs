// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ParsePropertyModel.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Sankhya.Attributes;

namespace Sankhya.ValueObjects;

/// <summary>
/// Class ParsePropertyModel. This class cannot be inherited.
/// </summary>
// TODO change public to internal after remove from Integração Service
public sealed class ParsePropertyModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParsePropertyModel" /> class.
    /// </summary>
    public ParsePropertyModel()
    {
        IsCriteria = true;
        CustomData = new();
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is ignored.
    /// </summary>
    /// <value><c>true</c> if this instance is ignored; otherwise, <c>false</c>.</value>
    public bool IsIgnored { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is criteria.
    /// </summary>
    /// <value><c>true</c> if this instance is criteria; otherwise, <c>false</c>.</value>
    public bool IsCriteria { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is entity key.
    /// </summary>
    /// <value><c>true</c> if this instance is entity key; otherwise, <c>false</c>.</value>
    public bool IsEntityKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is entity reference.
    /// </summary>
    /// <value><c>true</c> if this instance is entity reference; otherwise, <c>false</c>.</value>
    public bool IsEntityReference { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is entity reference inline.
    /// </summary>
    /// <value><c>true</c> if this instance is entity reference inline; otherwise, <c>false</c>.</value>
    public bool IsEntityReferenceInline { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [ignore entity reference inline].
    /// </summary>
    /// <value><c>true</c> if [ignore entity reference inline]; otherwise, <c>false</c>.</value>
    public bool IgnoreEntityReferenceInline { get; set; }

    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    /// <value>The name of the property.</value>
    public string PropertyName { get; set; }

    /// <summary>
    /// Gets or sets the name of the custom relation.
    /// </summary>
    /// <value>The name of the custom relation.</value>
    public string CustomRelationName { get; set; }

    /// <summary>
    /// Gets or sets the custom data.
    /// </summary>
    /// <value>The custom data.</value>
    public EntityCustomDataAttribute CustomData { get; set; }
}
