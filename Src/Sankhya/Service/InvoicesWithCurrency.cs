using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class InvoicesWithCurrency
{
    [XmlAttribute(AttributeName = "valorMoeda")]
    public string CurrencyValue { get; set; }
}
