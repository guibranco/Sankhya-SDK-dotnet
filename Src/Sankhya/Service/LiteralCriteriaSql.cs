using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class LiteralCriteriaSql : ILiteralCriteria
{
    [XmlElement(ElementName = "expressao")]
    public string Expression { get; set; }
}
