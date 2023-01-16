// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="EntityReferenceAttribute.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Attributes
{
    using System;

    /// <summary>
    /// Class EntityReferenceAttribute. This class cannot be inherited.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EntityReferenceAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityReferenceAttribute"/> class.
        /// </summary>
        public EntityReferenceAttribute() => CustomRelationName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityReferenceAttribute"/> class.
        /// </summary>
        /// <param name="customRelationName">Name of the custom relation.</param>
        public EntityReferenceAttribute(string customRelationName) => CustomRelationName = customRelationName;

        /// <summary>
        /// Gets the name of the custom relation.
        /// </summary>
        /// <value>The name of the custom relation.</value>
        public string CustomRelationName { get; private set; }
    }
}
