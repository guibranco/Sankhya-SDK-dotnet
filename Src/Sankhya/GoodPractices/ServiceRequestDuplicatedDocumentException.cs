namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestDuplicatedDocumentException : ServiceRequestGeneralException
{
    public ServiceRequestDuplicatedDocumentException(string name, ServiceRequest request, ServiceResponse response)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.ServiceRequestDuplicatedDocumentException, name), request, response)
    { }

    protected ServiceRequestDuplicatedDocumentException(SerializationInfo info, StreamingContext context)
    { }
}