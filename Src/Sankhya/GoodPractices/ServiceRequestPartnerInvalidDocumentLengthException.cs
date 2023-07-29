﻿namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestPartnerInvalidDocumentLengthException : ServiceRequestGeneralException
{
    public ServiceRequestPartnerInvalidDocumentLengthException(ServiceRequest request)
        : base(Resources.ServiceRequestPartnerInvalidDocumentLengthException, request) { }

    protected ServiceRequestPartnerInvalidDocumentLengthException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
