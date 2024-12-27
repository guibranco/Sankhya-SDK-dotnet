using System;
using Sankhya.Enums;
using Sankhya.GoodPractices;

namespace Sankhya.RequestHelpers;

public class RequestExceptionHandler : IRequestExceptionHandler
{
    private readonly RequestBehaviorOptions _options;

    public RequestExceptionHandler(RequestBehaviorOptions options)
    {
        _options = options;
    }

    public bool Handle(RequestExceptionDetails details, RequestRetryData retryData)
    {
        if (retryData.RetryCount > _options.MaxRetryCount)
        {
            return false;
        }

        if (
            details.ServiceDetails.Type == ServiceType.Transactional
            && details.Exception
                is ServiceRequestCompetitionException
                    or ServiceRequestDeadlockException
                    or ServiceRequestTimeoutException
        )
        {
            return false;
        }

        return HandleInternal(details, retryData);
    }

    private bool HandleInternal(RequestExceptionDetails details, RequestRetryData retryData)
    {
        throw new NotImplementedException();
    }
}
