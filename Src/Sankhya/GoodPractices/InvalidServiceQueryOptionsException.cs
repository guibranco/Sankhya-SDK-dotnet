namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

[Serializable]
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

    protected InvalidServiceQueryOptionsException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
