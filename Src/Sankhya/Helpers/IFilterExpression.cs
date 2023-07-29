// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="IFilterExpression.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Helpers;

//TODO issue #68 (Integração Service)
/// <summary>
/// Interface IFilterExpression
/// </summary>
public interface IFilterExpression
{
    /// <summary>
    /// Builds the expression
    /// </summary>
    /// <returns>System.String.</returns>
    string BuildExpression();
}
