using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception that is thrown when an invalid service request operation is encountered.
/// </summary>
/// <param name="service">The service name that caused the exception.</param>
public class InvalidServiceRequestOperationException(ServiceName service)
    : Exception(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.InvalidServiceRequestOperationException,
            service.GetHumanReadableValue()
        )
    );
