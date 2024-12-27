using System;
using System.Globalization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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
