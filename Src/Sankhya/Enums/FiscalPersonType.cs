// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="FiscalPersonType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;




    /// <summary>
    /// Enum FiscalPersonType
    /// </summary>
    public enum FiscalPersonType
    {
        /// <summary>
        /// The individual
        /// </summary>
        [HumanReadable("Pessoa física")]
        [InternalValue("F")]
        Individual,

        /// <summary>
        /// The corporation
        /// </summary>
        [HumanReadable("Pessoa jurídica")]
        [InternalValue("J")]
        Corporation
    }
}
