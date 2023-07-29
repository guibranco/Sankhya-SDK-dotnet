namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

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
