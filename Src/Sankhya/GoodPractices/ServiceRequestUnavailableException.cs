// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="ServiceRequestUnavailableException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ServiceRequestUnavailableException.
/// Implements the <see cref="ServiceRequestTemporarilyException" />.
/// </summary>
/// <seealso cref="ServiceRequestTemporarilyException" />
[Serializable]
public class ServiceRequestUnavailableException : ServiceRequestTemporarilyException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnavailableException"/> class.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    public ServiceRequestUnavailableException(
        ServiceName service,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestUnavailableException,
                service.GetHumanReadableValue()
            ),
            request,
            response
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnavailableException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected ServiceRequestUnavailableException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
