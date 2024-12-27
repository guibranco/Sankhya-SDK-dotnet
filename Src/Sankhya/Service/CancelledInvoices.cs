using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class CancelledInvoices
{
    [XmlAttribute("justificativa")]
    public string Justification { get; set; }

    [XmlElement("nunota")]
    public int[] SingleNumbers { get; set; }
}
