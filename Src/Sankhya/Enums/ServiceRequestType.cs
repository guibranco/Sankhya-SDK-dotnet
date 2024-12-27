using CrispyWaffle.Attributes;

namespace Sankhya.Enums;

public enum ServiceRequestType
{
    [HumanReadable("Default")]
    Default,

    [HumanReadable("Simple CRUD")]
    SimpleCrud,

    [HumanReadable("Paged CRUD (retrieve)")]
    PagedCrud,

    [HumanReadable("Queryable CRUD (retrieve)")]
    QueryableCrud,

    [HumanReadable("On demand CRUD (Create, Update, Delete)")]
    OnDemandCrud,

    [HumanReadable("Know services")]
    KnowServices,
}
