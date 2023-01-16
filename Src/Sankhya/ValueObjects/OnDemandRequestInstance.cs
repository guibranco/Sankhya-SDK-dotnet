// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="OnDemandRequestInstance.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.ValueObjects
{
    using System;
    using Sankhya.Enums;
    using Sankhya.RequestWrappers;

    /// <summary>
    /// Class OnDemandRequestInstance. This class cannot be inherited.
    /// </summary>
    // TODO change public to internal after remove from Integração Service
    public sealed class OnDemandRequestInstance
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>

        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>

        public ServiceName Service { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>

        public Type Type { get; set; }
        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>

        public IOnDemandRequestWrapper Instance { get; set; }

    }
}
