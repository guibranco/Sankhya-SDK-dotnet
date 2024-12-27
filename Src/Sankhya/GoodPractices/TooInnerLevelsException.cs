using System;

namespace Sankhya.GoodPractices;

public class TooInnerLevelsException : Exception
{
    public TooInnerLevelsException(string entityName)
        : base($@"Service Request with too inner entity references on entity {entityName}") { }
}
