// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ProductSuggestionType.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Enums
{
    using CrispyWaffle.Attributes;

    /// <summary>
    /// Enum ProductSuggestionType
    /// </summary>
    public enum ProductSuggestionType
    {

        /// <summary>
        /// The none
        /// </summary>
        [HumanReadable("Nenhum")]
        None,

        /// <summary>
        /// The accessory
        /// </summary>
        [HumanReadable("Acessório")]
        [InternalValue("A")]
        Accessory,

        /// <summary>
        /// The suggestion
        /// </summary>
        [HumanReadable("Sugestão")]
        [InternalValue("S")]
        Suggestion,

        /// <summary>
        /// The buy together
        /// </summary>
        [HumanReadable("Compre Junto")]
        [InternalValue("C")]
        BuyTogether
    }
}
