namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestInvalidRelationException : ServiceRequestGeneralException
{
    public ServiceRequestInvalidRelationException(string missingRelation, string entity, ServiceRequest request)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.ServiceRequestInvalidRelationException, missingRelation, entity), request)
    { }

}