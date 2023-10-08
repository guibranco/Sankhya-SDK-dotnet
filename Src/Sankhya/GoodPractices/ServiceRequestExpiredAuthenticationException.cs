using System.Runtime.Serialization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestExpiredAuthenticationException : Exception
{
    public ServiceRequestExpiredAuthenticationException()
        : base(Resources.ServiceRequestExpiredAuthenticationException) { }

    protected ServiceRequestExpiredAuthenticationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
