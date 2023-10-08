// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="ServiceRequestUnbalancedDelimiterException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ServiceRequestUnbalancedDelimiterException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class ServiceRequestUnbalancedDelimiterException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnbalancedDelimiterException"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    public ServiceRequestUnbalancedDelimiterException(ServiceRequest request)
        : base(Resources.ServiceRequestUnbalancedDelimiterException, request) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceRequestUnbalancedDelimiterException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected ServiceRequestUnbalancedDelimiterException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
