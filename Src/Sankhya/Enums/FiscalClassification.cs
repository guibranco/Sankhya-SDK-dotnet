// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="FiscalClassification.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;

    /// <summary>
    /// Enum FiscalClassification
    /// </summary>
    public enum FiscalClassification
    {
        /// <summary>
        /// The final customer
        /// </summary>
        [HumanReadable("Consumidor Final")]
        [InternalValue("C")]
        FinalCustomer,

        /// <summary>
        /// The icms free
        /// </summary>
        [HumanReadable("Isento de ICMS")]
        [InternalValue("I")]
        IcmsFree,

        /// <summary>
        /// The rural producer
        /// </summary>
        [HumanReadable("Produtor Rural")]
        [InternalValue("P")]
        RuralProducer,

        /// <summary>
        /// The retailer
        /// </summary>
        [HumanReadable("Revendedor")]
        [InternalValue("R")]
        Retailer,

        /// <summary>
        /// The use top
        /// </summary>
        [HumanReadable("Usar a da TOP")]
        [InternalValue("T")]
        UseTop,

        /// <summary>
        /// The taxpayer customer
        /// </summary>
        [HumanReadable("Consumidor Contribuinte")]
        [InternalValue("X")]
        TaxpayerCustomer
    }
}
