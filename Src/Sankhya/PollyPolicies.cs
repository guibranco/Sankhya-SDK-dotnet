using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;
using System;

namespace Sankhya
{
    public static class PollyPolicies
    {
        public static RetryPolicy GetRetryPolicy()
        {
            return Policy
                .Handle<Exception>()
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static TimeoutPolicy GetTimeoutPolicy()
        {
            return Policy.Timeout(10); // 10 seconds timeout
        }

        public static CircuitBreakerPolicy GetCircuitBreakerPolicy()
        {
            return Policy
                .Handle<Exception>()
                .CircuitBreaker(2, TimeSpan.FromMinutes(1));
        }
    }
}
