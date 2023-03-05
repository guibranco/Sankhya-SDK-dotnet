namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestPartnerStateInscriptionException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerStateInscriptionException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerStateInscriptionException, request)
    { }

    protected ServiceRequestPartnerStateInscriptionException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}