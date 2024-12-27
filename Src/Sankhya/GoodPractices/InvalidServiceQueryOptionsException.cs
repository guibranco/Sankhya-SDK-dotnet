using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class InvalidServiceQueryOptionsException(ServiceName service)
    : Exception(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.InvalidServiceQueryOptionsException,
            service.GetHumanReadableValue()
        )
    );
