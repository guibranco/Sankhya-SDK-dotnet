// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="Messages.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class Messages. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot("mensagens")]
public sealed class Messages
{
    #region Private Members

    /// <summary>
    /// The message
    /// </summary>
    private Message[] _message;

    /// <summary>
    /// The message set
    /// </summary>
    private bool _messageSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>The message.</value>
    [XmlElement("msg")]
    public Message[] Message
    {
        get => _message;
        set
        {
            _message = value;
            _messageSet = true;
        }
    }

    #endregion

    #region Serializer Helpers


    /// <summary>
    /// Should the serialize message.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessage() => _messageSet;

    #endregion
}
