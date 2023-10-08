// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="ConfirmInvoiceException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Service;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class ConfirmInvoiceException.
/// Implements the <see cref="ServiceRequestGeneralException" />.
/// </summary>
/// <seealso cref="ServiceRequestGeneralException" />
[Serializable]
public class ConfirmInvoiceException : ServiceRequestGeneralException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfirmInvoiceException"/> class.
    /// </summary>
    /// <param name="singleNumber">The single number.</param>
    /// <param name="request">The request.</param>
    /// <param name="innerException">The inner exception.</param>
    public ConfirmInvoiceException(
        int singleNumber,
        ServiceRequest request,
        Exception innerException
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                "Unable to confirm invoice with single number: {0}",
                singleNumber
            ),
            request,
            innerException
        ) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfirmInvoiceException"/> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    protected ConfirmInvoiceException(SerializationInfo info, StreamingContext context) { }
}
