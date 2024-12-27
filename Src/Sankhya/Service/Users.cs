using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "usuarios")]
public sealed class Users
{
    [XmlElement(ElementName = "usuario")]
    public User[] User { get; set; }
}
