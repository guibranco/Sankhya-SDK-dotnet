using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

[Serializable]
public class ServiceRequestPartnerFiscalClassificationException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerFiscalClassificationException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerFiscalClassificationException, request) { }

    protected ServiceRequestPartnerFiscalClassificationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
