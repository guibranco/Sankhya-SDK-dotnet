// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="UnlinkShippingException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class UnlinkShippingException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class UnlinkShippingException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlinkShippingException"/> class.
    /// </summary>
    /// <param name="financialNumber">The financial number.</param>
    /// <param name="request">The request.</param>
    /// <param name="innerException">The inner exception.</param>
    public UnlinkShippingException(
        int financialNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.UnlinkShippingException,
                financialNumber
            ),
            request,
            innerException
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnlinkShippingException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected UnlinkShippingException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
