// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Config.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.Service;

using CrispyWaffle.Serialization;

using System.Xml.Serialization;

/// <summary>
/// Class Config. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "config")]
public sealed class Config
{
    #region Private Members

    /// <summary>
    /// The path
    /// </summary>
    private string _path;
    /// <summary>
    /// The path set
    /// </summary>
    private bool _pathSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    /// <value>The path.</value>
    [XmlAttribute(AttributeName = "path")]
    public string Path
    {
        get => _path; set
        {
            _path = value;
            _pathSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize path.
    /// </summary>
    /// <returns>Boolean.</returns>
    public bool ShouldSerializePath() => _pathSet;

    #endregion
}