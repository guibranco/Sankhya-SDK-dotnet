// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Event.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Event. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot("Event")]
public sealed class Event
{
    /// <summary>
    /// The code product
    /// </summary>
    private int _codeProduct;

    /// <summary>
    /// The code product set
    /// </summary>
    private bool _codeProductSet;

    /// <summary>
    /// Gets or sets the code product.
    /// </summary>
    /// <value>The code product.</value>
    [XmlAttribute(AttributeName = "codProd")]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    /// <summary>
    /// Shoulds the serialize code product.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public bool ShouldSerializeCodeProduct() => _codeProductSet;
}
