using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class ReferenceFetch
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "field")]
    public Field[] Field { get; set; }
}
