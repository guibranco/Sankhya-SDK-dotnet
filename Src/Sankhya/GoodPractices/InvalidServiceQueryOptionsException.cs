// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="InvalidServiceQueryOptionsException.cs" company="Guilherme Branco Stracini">
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

namespace Sankhya.GoodPractices;

/// <summary>
/// Class InvalidServiceQueryOptionsException.
/// Implements the <see cref="System.Exception" />.
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public class InvalidServiceQueryOptionsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidServiceQueryOptionsException"/> class.
    /// </summary>
    /// <param name="service">The service.</param>
    public InvalidServiceQueryOptionsException(ServiceName service)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceQueryOptionsException,
                service.GetHumanReadableValue()
            )
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidServiceQueryOptionsException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected InvalidServiceQueryOptionsException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
