// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ParameterType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;

    /// <summary>
    /// Enum ParameterType
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// The string
        /// </summary>
        [InternalValue("S")]
        [HumanReadable("String")]
        String,

        /// <summary>
        /// The integer
        /// </summary>
        [InternalValue("I")]
        [HumanReadable("Integer")]
        Integer,

        /// <summary>
        /// The datetime
        /// </summary>
        [InternalValue("D")]
        [HumanReadable("Datetime")]
        Datetime
    }
}
