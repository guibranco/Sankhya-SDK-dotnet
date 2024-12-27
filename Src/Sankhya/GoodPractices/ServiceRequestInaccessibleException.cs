using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a service request is inaccessible.
/// </summary>
/// <param name="host">The host of the service.</param>
/// <param name="port">The port of the service.</param>
/// <param name="request">The service request that was attempted.</param>
/// <param name="innerException">The exception that caused the current exception.</param>
public class ServiceRequestInaccessibleException(
    string host,
    int port,
    ServiceRequest request,
    Exception innerException
)
    : ServiceRequestTemporarilyException(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.ServiceRequestInaccessibleException,
            host,
            port
        ),
        request,
        innerException
    );
