// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="TooInnerLevelsException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class TooInnerLevelsException.
/// Implements the <see cref="Exception" />.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class TooInnerLevelsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TooInnerLevelsException"/> class.
    /// </summary>
    /// <param name="entityName">Name of the entity.</param>
    public TooInnerLevelsException(string entityName)
        : base($@"Service Request with too inner entity references on entity {entityName}") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TooInnerLevelsException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected TooInnerLevelsException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
