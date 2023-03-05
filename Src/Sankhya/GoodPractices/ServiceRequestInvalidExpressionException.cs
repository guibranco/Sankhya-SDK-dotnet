namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestInvalidExpressionException : ServiceRequestGeneralException
{
    public ServiceRequestInvalidExpressionException(ServiceRequest request,
        ServiceResponse response)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.ServiceRequestInvalidExpressionException, request?.Service == ServiceName.CrudServiceFind ? request.RequestBody.DataSet.LiteralCriteria.Expression : request?.RequestBody.Entity.LiteralCriteria.Expression), request, response)
    { }

    protected ServiceRequestInvalidExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}