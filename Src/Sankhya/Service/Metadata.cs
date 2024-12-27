using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "metadata")]
public sealed class Metadata
{
    [XmlArray("fields")]
    [XmlArrayItem("field")]
    public Field[] Fields { get; set; }
}
