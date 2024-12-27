using System;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request contains too many inner entity references.
/// </summary>
/// <param name="entityName">The name of the entity that has too many inner references.</param>
public class TooInnerLevelsException(string entityName)
    : Exception($@"Service Request with too inner entity references on entity {entityName}");
