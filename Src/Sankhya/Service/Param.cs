// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Param.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Param. This class cannot be inherited.
/// </summary>
public sealed class Param
{
    #region Private Members

    /// <summary>
    /// The financial number
    /// </summary>
    private int _financialNumber;

    /// <summary>
    /// The financial number set
    /// </summary>
    private bool _financialNumberSet;

    /// <summary>
    /// The financial number upper case
    /// </summary>
    private int _financialNumberUpperCase;

    /// <summary>
    /// The financial number upper case set
    /// </summary>
    private bool _financialNumberUpperCaseSet;

    /// <summary>
    /// The bank number
    /// </summary>
    private int _bankNumber;

    /// <summary>
    /// The bank number set
    /// </summary>
    private bool _bankNumberSet;

    /// <summary>
    /// The recompose
    /// </summary>
    private string _recompose;

    /// <summary>
    /// The recompose set
    /// </summary>
    private bool _recomposeSet;

    /// <summary>
    /// The revert all anticipation
    /// </summary>
    private string _revertAllAnticipation;

    /// <summary>
    /// The revert all anticipation set
    /// </summary>
    private bool _revertAllAnticipationSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the financial number.
    /// </summary>
    /// <value>The financial number.</value>
    [XmlAttribute(AttributeName = "nuFin")]
    public int FinancialNumber
    {
        get => _financialNumber;
        set
        {
            _financialNumber = value;
            _financialNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the financial number upper case.
    /// </summary>
    /// <value>The financial number upper case.</value>
    [XmlAttribute(AttributeName = "NUFIN")]
    public int FinancialNumberUpperCase
    {
        get => _financialNumberUpperCase;
        set
        {
            _financialNumberUpperCase = value;
            _financialNumberUpperCaseSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the bank number.
    /// </summary>
    /// <value>The bank number.</value>
    [XmlAttribute(AttributeName = "nuBco")]
    public int BankNumber
    {
        get => _bankNumber;
        set
        {
            _bankNumber = value;
            _bankNumberSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the recompose.
    /// </summary>
    /// <value>The recompose.</value>
    [XmlAttribute(AttributeName = "recompoe")]
    public string Recompose
    {
        get => _recompose;
        set
        {
            _recompose = value;
            _recomposeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the revert all anticipation.
    /// </summary>
    /// <value>The revert all anticipation.</value>
    [XmlAttribute(AttributeName = "estornarTodosAntecipacao")]
    public string RevertAllAnticipation
    {
        get => _revertAllAnticipation;
        set
        {
            _revertAllAnticipation = value;
            _revertAllAnticipationSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize financial number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumber() => _financialNumberSet;

    /// <summary>
    /// The should serialize financial number upper case serialization helper method
    /// </summary>
    /// <returns>Returns <c>true</c> when the field should be serialized, false otherwise</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumberUpperCase() => _financialNumberUpperCaseSet;

    /// <summary>
    /// Should the serialize bank number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeBankNumber() => _bankNumberSet;

    /// <summary>
    /// Should the serialize recompose.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRecompose() => _recomposeSet;

    /// <summary>
    /// Should the serialize revert all anticipation.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRevertAllAnticipation() => _revertAllAnticipationSet;

    #endregion
}
