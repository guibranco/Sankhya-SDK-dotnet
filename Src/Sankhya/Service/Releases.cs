using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[XmlRoot("liberacoes")]
[Serializer]
public sealed class Releases
{
    [XmlElement("liberacao")]
    public Release[] Release { get; set; }
}
