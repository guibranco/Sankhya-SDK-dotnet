using System;

namespace Sankhya.ValueObjects;

/// <summary>
/// Represents the event arguments for a paged request.
/// </summary>
public sealed class PagedRequestEventArgs
{
    /// <summary>
    /// Gets the type of the request.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Gets the quantity of items loaded in the current request.
    /// </summary>
    public int QuantityLoaded { get; }

    /// <summary>
    /// Gets the total quantity of items loaded so far.
    /// </summary>
    public int TotalLoaded { get; }

    /// <summary>
    /// Gets the current page number.
    /// </summary>
    public int CurrentPage { get; }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    /// Gets the exception that occurred during the request, if any.
    /// </summary>
    public Exception Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedRequestEventArgs"/> class with the specified parameters.
    /// </summary>
    /// <param name="type">The type of the request.</param>
    /// <param name="quantityLoaded">The quantity of items loaded in the current request.</param>
    /// <param name="totalLoaded">The total quantity of items loaded so far.</param>
    /// <param name="currentPage">The current page number.</param>
    /// <param name="totalPages">The total number of pages.</param>
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
    /// Initializes a new instance of the <see cref="PagedRequestEventArgs"/> class with the specified parameters.
    /// </summary>
    /// <param name="type">The type of the request.</param>
    /// <param name="currentPage">The current page number.</param>
    /// <param name="totalLoaded">The total quantity of items loaded so far.</param>
    /// <param name="exception">The exception that occurred during the request.</param>
    public PagedRequestEventArgs(Type type, int currentPage, int totalLoaded, Exception exception)
    {
        Type = type;
        CurrentPage = currentPage;
        TotalLoaded = totalLoaded;
        Exception = exception;
    }
}
