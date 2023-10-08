// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="CanceledOnDemandRequestWrapperException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class CanceledOnDemandRequestWrapperException.
/// Implements the <see cref="Exception" />.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class CanceledOnDemandRequestWrapperException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CanceledOnDemandRequestWrapperException"/> class.
    /// </summary>
    public CanceledOnDemandRequestWrapperException()
        : base("Cannot add new items to a cancelled on demand request wrapper instance") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanceledOnDemandRequestWrapperException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected CanceledOnDemandRequestWrapperException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
