// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{

    /// <summary>
    /// Enum ServiceType
    /// </summary>
    public enum ServiceType
    {

        /// <summary>
        /// The none
        /// </summary>
        None = 0,


        /// <summary>
        /// The retrieve
        /// </summary>
        Retrieve = 1,


        /// <summary>
        /// The non transactional
        /// </summary>
        NonTransactional = 2,


        /// <summary>
        /// The transactional
        /// </summary>
        Transactional = 3
    }
}
