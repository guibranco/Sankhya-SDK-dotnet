using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPropertyWidthException : ServiceRequestGeneralException
{
    public ServiceRequestPropertyWidthException(
        string propertyName,
        ServiceRequest request,
        int widthAllowed,
        int currentWidth
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestPropertyWidthException,
                request?.Service.GetHumanReadableValue(),
                propertyName,
                request?.RequestBody.Entity?.Name
                    ?? request?.RequestBody.Entity?.RootEntity
                    ?? request?.RequestBody.DataSet.RootEntity,
                currentWidth,
                widthAllowed
            ),
            request
        )
    {
        PropertyName = propertyName;
        AllowedWidth = widthAllowed;
    }

    public string PropertyName { get; }

    public int AllowedWidth { get; }
}
