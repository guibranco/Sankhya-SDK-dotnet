// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityQueryOptions.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Helpers;

using System;
using Sankhya.Enums;

/// <summary>
/// Class EntityQueryOptions. This class cannot be inherited.
/// </summary>
public sealed class EntityQueryOptions
{
    /// <summary>
    /// The timeout
    /// </summary>
    private TimeSpan _timeout;

    /// <summary>
    /// Gets or sets the maximum results.
    /// </summary>
    /// <value>The maximum results.</value>

    public int? MaxResults { get; set; }

    /// <summary>
    /// Gets or sets the include references.
    /// </summary>
    /// <value>The include references.</value>

    public bool? IncludeReferences { get; set; }

    /// <summary>
    /// Gets or sets the maximum reference depth.
    /// </summary>
    /// <value>The maximum reference depth.</value>

    public ReferenceLevel? MaxReferenceDepth { get; set; }

    /// <summary>
    /// Gets or sets the include presentation fields.
    /// </summary>
    /// <value>The include presentation fields.</value>

    public bool? IncludePresentationFields { get; set; }

    /// <summary>
    /// Gets or sets the use wildcard fields.
    /// </summary>
    /// <value>The use wildcard fields.</value>

    public bool? UseWildcardFields { get; set; }

    /// <summary>
    /// Gets or sets the timeout.
    /// </summary>
    /// <value>The timeout.</value>
    public TimeSpan Timeout
    {
        get
        {
            if (_timeout == TimeSpan.Zero)
            {
                _timeout = new(0, 30, 0);
            }

            return _timeout;
        }
        set => _timeout = value;
    }
}
