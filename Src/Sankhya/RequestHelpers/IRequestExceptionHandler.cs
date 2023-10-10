namespace Sankhya.RequestHelpers;

internal interface IRequestExceptionHandler
{
    bool Handle(RequestExceptionDetails details, RequestRetryData retryOptions);
}
