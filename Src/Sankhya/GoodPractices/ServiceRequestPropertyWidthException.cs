using System.Globalization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

public class ServiceRequestPropertyWidthException(
    string propertyName,
    ServiceRequest request,
    int widthAllowed,
    int currentWidth
)
    : ServiceRequestGeneralException(
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
    public string PropertyName { get; } = propertyName;

    public int AllowedWidth { get; } = widthAllowed;
}
