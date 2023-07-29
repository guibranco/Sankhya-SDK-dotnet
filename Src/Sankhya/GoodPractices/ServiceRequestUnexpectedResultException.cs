namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestUnexpectedResultException : ServiceRequestGeneralException
{
    private static string GetServiceName(ServiceRequest request)
    {
        var serviceName = request.Service.GetHumanReadableValue();
        var entity = request.RequestBody.DataSet?.RootEntity;
        if (!string.IsNullOrWhiteSpace(entity))
        {
            serviceName += $@" ({entity})";
        }

        return serviceName;
    }

    public ServiceRequestUnexpectedResultException(ServiceRequest request, ServiceResponse response)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestUnexpectedResultException,
                GetServiceName(request)
            ),
            request,
            response
        ) => ErrorMessage = string.Empty;

    public ServiceRequestUnexpectedResultException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestUnexpectedResultException_Uncaught,
                GetServiceName(request),
                message
            ),
            request,
            response
        ) => ErrorMessage = message;

    protected ServiceRequestUnexpectedResultException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }

    public string ErrorMessage { get; }
}
