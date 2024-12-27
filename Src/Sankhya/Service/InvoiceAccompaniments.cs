using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "acompanhamentosNotas")]
public sealed class InvoiceAccompaniments
{
    [XmlElement(ElementName = "nota")]
    public Invoice[] Invoices { get; set; }
}
