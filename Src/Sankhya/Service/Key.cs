using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot("chave")]
public sealed class Key
{
    private string _value;

    private bool _valueSet;

    [XmlAttribute(AttributeName = "valor")]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    public bool ShouldSerializeValue() => _valueSet;
}
