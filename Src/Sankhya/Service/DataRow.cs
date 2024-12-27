using System.Xml.Serialization;
using Sankhya.Helpers;

namespace Sankhya.Service;

[XmlRoot("DataRow")]
public sealed class DataRow
{
    [XmlElement("localFields")]
    public EntityDynamicSerialization LocalFields { get; set; }

    [XmlElement("key")]
    public EntityDynamicSerialization Keys { get; set; }
}
