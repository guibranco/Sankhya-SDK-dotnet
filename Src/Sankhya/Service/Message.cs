// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Message.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Message. This class cannot be inherited.
/// </summary>
public sealed class Message
{
    #region Private Members

    /// <summary>
    /// The text
    /// </summary>
    private string _text;

    /// <summary>
    /// The text set
    /// </summary>
    private bool _textSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    [XmlText]
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _textSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize text.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;

    #endregion
}
