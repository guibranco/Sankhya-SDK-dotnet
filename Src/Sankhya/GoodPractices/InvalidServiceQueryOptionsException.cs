using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class InvalidServiceQueryOptionsException : Exception
{
    public InvalidServiceQueryOptionsException(ServiceName service)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceQueryOptionsException,
                service.GetHumanReadableValue()
            )
        ) { }
}
