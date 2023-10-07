using System;
using System.Runtime.Serialization;

namespace Sankhya.GoodPractices;

[Serializable]
public class CanceledOnDemandRequestWrapperException : Exception
{
    public CanceledOnDemandRequestWrapperException()
        : base("Cannot add new items to a cancelled on demand request wrapper instance") { }

    protected CanceledOnDemandRequestWrapperException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
