using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when a service request returns an unexpected result.
/// </summary>
public class ServiceRequestUnexpectedResultException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnexpectedResultException"/> class with the specified service request and response.
    /// </summary>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response that caused the exception.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnexpectedResultException"/> class with the specified error message, service request, and response.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="request">The service request that caused the exception.</param>
    /// <param name="response">The service response that caused the exception.</param>
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

    /// <summary>
    /// Gets the error message that explains the reason for the exception.
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    /// Gets the human-readable service name from the specified service request.
    /// </summary>
    /// <param name="request">The service request to get the service name from.</param>
    /// <returns>The human-readable service name.</returns>
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
}
