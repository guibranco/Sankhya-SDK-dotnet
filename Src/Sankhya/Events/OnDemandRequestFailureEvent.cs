using System;
using CrispyWaffle.Events;
using Sankhya.Transport;

namespace Sankhya.Events;

/// <summary>
/// Represents an event that occurs when an on-demand request fails.
/// </summary>
public class OnDemandRequestFailureEvent : IEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OnDemandRequestFailureEvent" /> class.
    /// </summary>
    /// <param name="entity">The entity associated with the request.</param>
    /// <param name="isUpdate">Indicates whether the request was an update operation.</param>
    /// <param name="exception">The exception that caused the failure.</param>
    public OnDemandRequestFailureEvent(IEntity entity, bool isUpdate, Exception exception)
    {
        Entity = entity;
        Exception = exception;
        IsUpdate = isUpdate;
    }

    /// <summary>
    /// Gets the entity associated with the request.
    /// </summary>
    /// <value>The entity.</value>
    public IEntity Entity { get; }

    /// <summary>
    /// Gets the exception that caused the failure.
    /// </summary>
    /// <value>The exception.</value>
    public Exception Exception { get; }

    /// <summary>
    /// Gets a value indicating whether the request was an update operation.
    /// </summary>
    /// <value><c>true</c> if this instance is update; otherwise, <c>false</c>.</value>
    public bool IsUpdate { get; }
}
