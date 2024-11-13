// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityElementAttribute.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Sankhya.Attributes;

/// <summary>
/// Class EntityElementAttribute. This class cannot be inherited.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class EntityElementAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityElementAttribute" /> class.
    /// </summary>
    /// <param name="elementName">Name of the element.</param>
    /// <param name="ignoreInlineReference">if set to <c>true</c> [ignore inline reference].</param>
    public EntityElementAttribute(string elementName, bool ignoreInlineReference = false)
    {
        ElementName = elementName;
        IgnoreInlineReference = ignoreInlineReference;
    }

    /// <summary>
    /// Gets the name of the element.
    /// </summary>
    /// <value>The name of the element.</value>
    public string ElementName { get; }

    /// <summary>
    /// Gets a value indicating whether [ignore inline reference].
    /// </summary>
    /// <value><c>true</c> if [ignore inline reference]; otherwise, <c>false</c>.</value>
    public bool IgnoreInlineReference { get; }
}
