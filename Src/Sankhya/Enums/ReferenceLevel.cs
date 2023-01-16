// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ReferenceLevel.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;
    /// <summary>
    /// Enum ReferenceLevel
    /// </summary>
    public enum ReferenceLevel
    {

        /// <summary>
        /// The none
        /// </summary>
        [HumanReadable("None")]
        None,

        /// <summary>
        /// The first
        /// </summary>
        [HumanReadable("First")]
        First,

        /// <summary>
        /// The second
        /// </summary>
        [HumanReadable("Second")]
        Second,

        /// <summary>
        /// The third
        /// </summary>
        [HumanReadable("Third")]
        Third,

        /// <summary>
        /// The fourth
        /// </summary>
        [HumanReadable("Fourth")]
        Fourth,

        /// <summary>
        /// The fifth
        /// </summary>
        [HumanReadable("Fifth")]
        Fifth,

        /// <summary>
        /// The sixth
        /// </summary>
        [HumanReadable("Sixth")]
        Sixth,
    }
}