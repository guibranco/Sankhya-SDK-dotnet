using System.Xml.Serialization;

namespace Sankhya.Service;

[XmlType("usuario")]
public sealed class User
{
    [XmlAttribute(AttributeName = "codUsuLogado")]
    public int LoggedUserCode { get; set; }
}
