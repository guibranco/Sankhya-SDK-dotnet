namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

[Serializable]
public class InvalidServiceRequestOperationException : Exception
{
    public InvalidServiceRequestOperationException(ServiceName service)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.InvalidServiceRequestOperationException, service.GetHumanReadableValue()))
    { }

    protected InvalidServiceRequestOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}