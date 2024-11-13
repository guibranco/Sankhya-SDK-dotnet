// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 18/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 18/01/2023
// ***********************************************************************
// <copyright file="OnDemandRequestFailureEvent.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CrispyWaffle.Events;
using Sankhya.Transport;

namespace Sankhya.Events;

/// <summary>
/// The on demand request failure event class.
/// </summary>
/// <seealso cref="IEvent" />
public class OnDemandRequestFailureEvent : IEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OnDemandRequestFailureEvent" /> class.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <param name="isUpdate">if set to <c>true</c> [is update].</param>
    /// <param name="exception">The exception.</param>
    public OnDemandRequestFailureEvent(IEntity entity, bool isUpdate, Exception exception)
    {
        Entity = entity;
        Exception = exception;
        IsUpdate = isUpdate;
    }

    /// <summary>
    /// Gets the entity.
    /// </summary>
    /// <value>The entity.</value>
    public IEntity Entity { get; }

    /// <summary>
    /// Gets the exception.
    /// </summary>
    /// <value>The exception.</value>
    public Exception Exception { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is update.
    /// </summary>
    /// <value><c>true</c> if this instance is update; otherwise, <c>false</c>.</value>
    public bool IsUpdate { get; }
}
