// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityCustomDataAttribute.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Sankhya.Attributes;

/// <summary>
/// Class EntityCustomDataAttribute. This class cannot be inherited.
/// Implements the <see cref="Attribute" />
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
public sealed class EntityCustomDataAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the maximum length.
    /// </summary>
    /// <value>The maximum length.</value>
    public int MaxLength { get; set; }
}
