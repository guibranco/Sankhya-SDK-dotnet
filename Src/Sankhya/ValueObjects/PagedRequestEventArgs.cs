// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="PagedRequestEventArgs.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Sankhya.ValueObjects;

/// <summary>
/// Class PagedRequestEventArgs. This class cannot be inherited.
/// </summary>
public sealed class PagedRequestEventArgs
{
    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>The type.</value>
    public Type Type { get; }

    /// <summary>
    /// Gets the quantity loaded.
    /// </summary>
    /// <value>The quantity loaded.</value>
    public int QuantityLoaded { get; }

    /// <summary>
    /// Gets the total loaded.
    /// </summary>
    /// <value>The total loaded.</value>
    public int TotalLoaded { get; }

    /// <summary>
    /// Gets the current page.
    /// </summary>
    /// <value>The current page.</value>
    public int CurrentPage { get; }

    /// <summary>
    /// Gets the total pages.
    /// </summary>
    /// <value>The total pages.</value>
    public int TotalPages { get; }

    /// <summary>
    /// Gets the exception.
    /// </summary>
    /// <value>The exception.</value>
    public Exception Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequestEventArgs" /> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="quantityLoaded">The quantity loaded.</param>
    /// <param name="totalLoaded">The total loaded.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="totalPages">The total pages.</param>
    public PagedRequestEventArgs(
        Type type,
        int quantityLoaded,
        int totalLoaded,
        int currentPage,
        int totalPages
    )
    {
        Type = type;
        QuantityLoaded = quantityLoaded;
        TotalLoaded = totalLoaded;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequestEventArgs" /> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="totalLoaded">The total loaded.</param>
    /// <param name="exception">The exception.</param>
    public PagedRequestEventArgs(Type type, int currentPage, int totalLoaded, Exception exception)
    {
        Type = type;
        CurrentPage = currentPage;
        TotalLoaded = totalLoaded;
        Exception = exception;
    }
}
