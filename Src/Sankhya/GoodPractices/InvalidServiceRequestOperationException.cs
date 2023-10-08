// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="InvalidServiceRequestOperationException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Globalization;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class InvalidServiceRequestOperationException.
/// Implements the <see cref="System.Exception" />.
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public class InvalidServiceRequestOperationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidServiceRequestOperationException"/> class.
    /// </summary>
    /// <param name="service">The service.</param>
    public InvalidServiceRequestOperationException(ServiceName service)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.InvalidServiceRequestOperationException,
                service.GetHumanReadableValue()
            )
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidServiceRequestOperationException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected InvalidServiceRequestOperationException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
