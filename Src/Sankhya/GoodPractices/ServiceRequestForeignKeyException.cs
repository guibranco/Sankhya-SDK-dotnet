namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestForeignKeyException : ServiceRequestGeneralException
{
    public ServiceRequestForeignKeyException(
        string table,
        string column,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestForeignKeyException,
                table,
                column
            ),
            request,
            response
        ) { }

    protected ServiceRequestForeignKeyException(SerializationInfo info, StreamingContext context)
    { }
}
