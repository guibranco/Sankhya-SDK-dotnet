using System;
using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class InvalidServiceRequestOperationException : Exception
{
    public InvalidServiceRequestOperationException(ServiceName service)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceRequestOperationException,
                service.GetHumanReadableValue()
            )
        ) { }
}
