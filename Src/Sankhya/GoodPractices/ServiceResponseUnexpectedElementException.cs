// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="ServiceResponseUnexpectedElementException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ServiceResponseUnexpectedElementException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class ServiceResponseUnexpectedElementException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceResponseUnexpectedElementException"/> class.
    /// </summary>
    /// <param name="elementName">Name of the element.</param>
    /// <param name="serviceName">Name of the service.</param>
    /// <param name="response">The response.</param>
    public ServiceResponseUnexpectedElementException(
        string elementName,
        string serviceName,
        ServiceResponse response
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.ServiceResponseUnexpectedElementException,
                elementName,
                serviceName
            ),
            null,
            response
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceResponseUnexpectedElementException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected ServiceResponseUnexpectedElementException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
