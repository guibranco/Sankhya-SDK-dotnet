using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

/// <summary>
/// Represents the type of service request.
/// </summary>
public enum ServiceRequestType
{
    /// <summary>
    /// Default service request.
    /// </summary>
    [HumanReadable("Default")]
    Default,

    /// <summary>
    /// Simple CRUD service request.
    /// </summary>
    [HumanReadable("Simple CRUD")]
    SimpleCrud,

    /// <summary>
    /// Paged CRUD (retrieve) service request.
    /// </summary>
    [HumanReadable("Paged CRUD (retrieve)")]
    PagedCrud,

    /// <summary>
    /// Queryable CRUD (retrieve) service request.
    /// </summary>
    [HumanReadable("Queryable CRUD")]
    QueryableCrud,

    /// <summary>
    /// On demand CRUD (Create, Update, Delete) service request.
    /// </summary>
    [HumanReadable("On demand CRUD (Create, Update, Delete)")]
    OnDemandCrud,

    /// <summary>
    /// Know services request.
    /// </summary>
    [HumanReadable("Know services")]
    KnowServices,
}
