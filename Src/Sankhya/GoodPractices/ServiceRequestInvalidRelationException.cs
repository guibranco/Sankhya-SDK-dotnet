using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
