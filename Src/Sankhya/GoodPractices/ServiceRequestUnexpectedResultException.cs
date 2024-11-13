// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="ServiceRequestUnexpectedResultException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ServiceRequestUnexpectedResultException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class ServiceRequestUnexpectedResultException : ServiceRequestGeneralException
{
    /// <summary>
    /// Gets the name of the service.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>System.String.</returns>
    private static string GetServiceName(ServiceRequest request)
    {
        var serviceName = request.Service.GetHumanReadableValue();
        var entity = request.RequestBody.DataSet?.RootEntity;
        if (!string.IsNullOrWhiteSpace(entity))
        {
            serviceName += $@" ({entity})";
        }

        return serviceName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnexpectedResultException"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    public ServiceRequestUnexpectedResultException(ServiceRequest request, ServiceResponse response)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestUnexpectedResultException,
                GetServiceName(request)
            ),
            request,
            response
        ) => ErrorMessage = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnexpectedResultException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="request">The request.</param>
    /// <param name="response">The response.</param>
    public ServiceRequestUnexpectedResultException(
        string message,
        ServiceRequest request,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceRequestUnexpectedResultException_Uncaught,
                GetServiceName(request),
                message
            ),
            request,
            response
        ) => ErrorMessage = message;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnexpectedResultException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected ServiceRequestUnexpectedResultException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    public string ErrorMessage { get; }
}
