namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestPropertyValueException : ServiceRequestGeneralException
{
    public ServiceRequestPropertyValueException(string propertyName, ServiceRequest request)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyValueException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity
            ),
            request
        ) => PropertyName = propertyName;

    protected ServiceRequestPropertyValueException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public string PropertyName { get; private set; }
}
