using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class InvoiceAccompaniments. This class cannot be inherited.
/// </summary>
[Serializer]
[XmlRoot(ElementName = "acompanhamentosNotas")]
public sealed class InvoiceAccompaniments
{
    /// <summary>
    /// 	Gets or sets the nota.
    /// </summary>
    ///
    /// <value>
    /// 	The nota.
    /// </value>

    [XmlElement(ElementName = "nota")]
    public Invoice[] Invoices { get; set; }
}
