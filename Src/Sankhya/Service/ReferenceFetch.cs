namespace Sankhya.Service;

using System.Xml.Serialization;

public sealed class ReferenceFetch
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }


    [XmlElement(ElementName = "field")]
    public Field[] Field { get; set; }
}