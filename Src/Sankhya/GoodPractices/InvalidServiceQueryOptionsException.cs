using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when invalid query options are provided for a service.
/// </summary>
/// <param name="service">The service name for which the invalid query options were provided.</param>
public class InvalidServiceQueryOptionsException(ServiceName service)
    : Exception(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.InvalidServiceQueryOptionsException,
            service.GetHumanReadableValue()
        )
    );
