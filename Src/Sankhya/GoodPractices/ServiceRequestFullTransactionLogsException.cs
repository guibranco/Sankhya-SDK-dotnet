namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class ServiceRequestFullTransactionLogsException : ServiceRequestGeneralException
{
    public ServiceRequestFullTransactionLogsException(
        string database,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestFullTransactionLogsException,
                database
            ),
            request,
            response
        ) => Database = database;

    protected ServiceRequestFullTransactionLogsException(
        SerializationInfo info,
        StreamingContext context
    ) { }

    public string Database { get; }
}
