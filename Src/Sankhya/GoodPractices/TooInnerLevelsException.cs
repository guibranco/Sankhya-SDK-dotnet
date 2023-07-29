namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;

[Serializable]
public class TooInnerLevelsException : Exception
{
    public TooInnerLevelsException(string entityName)
        : base($@"Service Request with too inner entity references on entity {entityName}") { }

    protected TooInnerLevelsException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
