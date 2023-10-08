// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Params.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

/// <summary>
/// Class Params. This class cannot be inherited.
/// </summary>
public sealed class Params
{
    /// <summary>
    /// The single number
    /// </summary>
    private int _singleNumber;

    /// <summary>
    /// The single number set
    /// </summary>
    private bool _singleNumberSet;

    /// <summary>
    /// The code partner
    /// </summary>
    private int _codePartner;

    /// <summary>
    /// The code partner set
    /// </summary>
    private bool _codePartnerSet;

    /// <summary>
    /// The movement type
    /// </summary>
    private MovementType _movementType;

    /// <summary>
    /// The movement type set
    /// </summary>
    private bool _movementTypeSet;

    /// <summary>
    /// Gets or sets the single number.
    /// </summary>
    /// <value>The single number.</value>
    [XmlAttribute("nuNota")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code partner.
    /// </summary>
    /// <value>The code partner.</value>
    [XmlAttribute("codParc")]
    public int CodePartner
    {
        get => _codePartner;
        set
        {
            _codePartner = value;
            _codePartnerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type of the movement.
    /// </summary>
    /// <value>The type of the movement.</value>
    [XmlIgnore]
    public MovementType MovementType
    {
        get => _movementType;
        set
        {
            _movementType = value;
            _movementTypeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the movement type internal.
    /// </summary>
    /// <value>The movement type internal.</value>
    [XmlAttribute("tipMov")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string MovementTypeInternal
    {
        get => _movementType.GetInternalValue();
        set
        {
            _movementType = EnumExtensions.GetEnumByInternalValueAttribute<MovementType>(value);
            _movementTypeSet = true;
        }
    }

    /// <summary>
    /// Should the serialize single number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    /// <summary>
    /// Should the serialize code partner.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    /// <summary>
    /// Should the serialize movement type internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementTypeInternal() => _movementTypeSet;
}
