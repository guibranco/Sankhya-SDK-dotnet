using System;

namespace Sankhya.GoodPractices;

public class TooInnerLevelsException(string entityName)
    : Exception($@"Service Request with too inner entity references on entity {entityName}");
