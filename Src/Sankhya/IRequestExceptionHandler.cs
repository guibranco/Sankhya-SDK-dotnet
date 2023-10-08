using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Service;

namespace Sankhya;

internal interface IRequestExceptionHandler
{
    bool Handle(RequestExceptionDetails details, RequestRetryData retryOptions);
}
