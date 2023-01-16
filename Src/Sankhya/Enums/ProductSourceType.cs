// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ProductSourceType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;

    /// <summary>
    /// Enum ProductSourceType
    /// </summary>
    public enum ProductSourceType
    {
        /// <summary>
        /// The none
        /// </summary>
        [HumanReadable("None")]
        None,

        /// <summary>
        /// The group
        /// </summary>
        [HumanReadable("Group of product")]
        [InternalValue("G")]
        Group,

        /// <summary>
        /// The product
        /// </summary>
        [HumanReadable("Product")]
        [InternalValue("P")]
        Product
    }
}
