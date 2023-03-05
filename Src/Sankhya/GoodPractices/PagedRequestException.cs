namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

[Serializable]
public class PagedRequestException : ServiceRequestGeneralException
{
    public PagedRequestException(ServiceRequest request, Exception innerException)
        : base(Resources.PagedRequestException, request, innerException)
    { }

    protected PagedRequestException(SerializationInfo info, StreamingContext context)
    { }
}