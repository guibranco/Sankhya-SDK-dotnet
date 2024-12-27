using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request contains an invalid relation.
/// </summary>
/// <param name="missingRelation">The missing relation that caused the exception.</param>
/// <param name="entity">The entity associated with the missing relation.</param>
/// <param name="request">The service request that caused the exception.</param>
public class ServiceRequestInvalidRelationException(
    string missingRelation,
    string entity,
    ServiceRequest request
)
    : ServiceRequestGeneralException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestInvalidRelationException,
            missingRelation,
            entity
        ),
        request
    );
