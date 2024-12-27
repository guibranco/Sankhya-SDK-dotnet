using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[XmlRoot("avisos")]
[Serializer]
public sealed class Warnings
{
    [XmlElement("aviso")]
    public Warning[] Warning { get; set; }
}
