using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "resultadoCancelamento")]
public sealed class CancellationResult
{
    [XmlAttribute("totalNotasCanceladas")]
    public int TotalCancelledInvoices { get; set; }

    [XmlArray("acompanhamentos")]
    [XmlArrayItem("nunota")]
    public int[] SingleNumbers { get; set; }
}
