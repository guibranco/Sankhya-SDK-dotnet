// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceAttribute.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Attributes
{
    using System;
    using Sankhya.Enums;

    /// <summary>
    /// Class ServiceAttribute. This class cannot be inherited.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAttribute"/> class.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="category">The category.</param>
        /// <param name="type">The type.</param>
        public ServiceAttribute(ServiceModule module, ServiceCategory category, ServiceType type)
        {
            Type = type;
            Category = category;
            Module = module;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        public ServiceCategory Category { get; }

        /// <summary>
        /// Gets the module.
        /// </summary>
        /// <value>The module.</value>
        public ServiceModule Module { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public ServiceType Type { get; }

    }
}
