// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="PaymentStatus.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;


    /// <summary>
    /// Enum PaymentStatus
    /// </summary>
    public enum PaymentStatus
    {

        /// <summary>
        /// The pending
        /// </summary>
        [InternalValue("P")]
        [HumanReadable("Pendente")]
        Pending,


        /// <summary>
        /// The paid
        /// </summary>
        [InternalValue("E")]
        [HumanReadable("Efetuado")]
        Paid,

        /// <summary>
        /// The reversal
        /// </summary>
        [InternalValue("R")]
        [HumanReadable("Estornado")]
        Reversal,

        /// <summary>
        /// The billed
        /// </summary>
        [InternalValue("F")]
        [HumanReadable("Faturado")]
        Billed,
    }
}
