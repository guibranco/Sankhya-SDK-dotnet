using Sankhya.Enums;
using Sankhya.GoodPractices;

namespace Sankhya.RequestHelpers;

/// <summary>
/// Class RequestExceptionHandler.
/// </summary>
public class RequestExceptionHandler : IRequestExceptionHandler
{
    /// <summary>
    /// The options.
    /// </summary>
    private readonly RequestBehaviorOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestExceptionHandler"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public RequestExceptionHandler(RequestBehaviorOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Handles the specified details.
    /// </summary>
    /// <param name="details">The details.</param>
    /// <param name="retryData">The retry data.</param>
    /// <returns>bool.</returns>
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

    /// <summary>
    /// Handles the internal.
    /// </summary>
    /// <param name="details">The details.</param>
    /// <param name="retryData">The retry data.</param>
    /// <returns>bool.</returns>
    /// <exception cref="NotImplementedException">Method not implemented.</exception>
    private bool HandleInternal(RequestExceptionDetails details, RequestRetryData retryData)
    {
        throw new NotImplementedException();
    }
}
