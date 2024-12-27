using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

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

    public string PropertyName { get; private set; }
}
