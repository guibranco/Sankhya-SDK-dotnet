// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="MarkAsPaymentPaidException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class MarkAsPaymentPaidException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class MarkAsPaymentPaidException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkAsPaymentPaidException"/> class.
    /// </summary>
    /// <param name="financialNumbers">The financial numbers.</param>
    /// <param name="request">The request.</param>
    /// <param name="innerException">The inner exception.</param>
    public MarkAsPaymentPaidException(
        IEnumerable<int> financialNumbers,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                "Unable to low payments for financial numbers {0}",
                string.Join(@",", financialNumbers)
            ),
            request,
            innerException
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkAsPaymentPaidException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected MarkAsPaymentPaidException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
