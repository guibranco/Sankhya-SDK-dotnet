﻿using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class CancellationResult. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "resultadoCancelamento")]
public sealed class CancellationResult
{
    /// <summary>
    /// Gets or sets the total cancelled invoices.
    /// </summary>
    /// <value>The total cancelled invoices.</value>
    [XmlAttribute("totalNotasCanceladas")]
    public int TotalCancelledInvoices { get; set; }

    /// <summary>
    /// Gets or sets the single numbers.
    /// </summary>
    /// <value>The single numbers.</value>
    [XmlArray("acompanhamentos")]
    [XmlArrayItem("nunota")]
    public int[] SingleNumbers { get; set; }
}
