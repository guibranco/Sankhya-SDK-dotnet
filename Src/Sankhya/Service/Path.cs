using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
public sealed class Path
{
    [XmlText]
    public string Value { get; set; }
}
