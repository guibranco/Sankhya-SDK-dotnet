// ***********************************************************************
// Assembly         : Sankhya
// Author           : Guilherme Branco Stracini
// Created          : 01-16-2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-16-2023
// ***********************************************************************
// <copyright file="ServiceFile.cs" company="Guilherme Branco Stracini">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Sankhya.ValueObjects;

/// <summary>
/// Class ServiceFile. This class cannot be inherited.
/// </summary>
public sealed class ServiceFile
{
    /// <summary>
    /// Gets or sets the type of the content.
    /// </summary>
    /// <value>The type of the content.</value>
    public string ContentType { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>The name of the file.</value>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the extension.
    /// </summary>
    /// <value>The extension.</value>
    public string FileExtension { get; set; }
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>The data.</value>
    public byte[] Data { get; set; }
}