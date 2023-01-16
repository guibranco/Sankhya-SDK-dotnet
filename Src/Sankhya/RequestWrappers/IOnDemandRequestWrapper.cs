// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="IOnDemandRequestWrapper.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.RequestWrappers
{
    using System;
    using Sankhya.Transport;

    /// <summary>
    /// Interface IOnDemandRequestWrapper
    /// Implements the <see cref="IDisposable" />
    /// </summary>
    /// <seealso cref="IDisposable" />
    //TODO issue #69 (Integração Service)
    public interface IOnDemandRequestWrapper : IDisposable
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(IEntity entity);

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();
    }
}
