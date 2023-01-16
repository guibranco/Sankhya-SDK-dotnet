// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityAttribute.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Attributes
{
    using System;

    /// <summary>
    /// Class EntityAttribute. This class cannot be inherited.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class EntityAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityAttribute(string name) => Name = name;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }
    }
}
