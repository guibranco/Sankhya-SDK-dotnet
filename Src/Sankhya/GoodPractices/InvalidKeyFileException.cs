// ***********************************************************************
// Assembly         : Sankhya
// Author           : GuilhermeStracini
// Created          : 10-07-2023
//
// Last Modified By : GuilhermeStracini
// Last Modified On : 10-08-2023
// ***********************************************************************
// <copyright file="InvalidKeyFileException.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Class InvalidKeyFileException.
/// Implements the <see cref="System.Exception" />
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public class InvalidKeyFileException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidKeyFileException"/> class.
    /// </summary>
    /// <param name="key">The key.</param>
    public InvalidKeyFileException(string key)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.InvalidKeyFileException, key))
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidKeyFileException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected InvalidKeyFileException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
