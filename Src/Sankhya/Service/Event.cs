using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot("Event")]
public sealed class Event
{
    private int _codeProduct;

    private bool _codeProductSet;

    [XmlAttribute(AttributeName = "codProd")]
    public int CodeProduct
    {
        get => _codeProduct;
        set
        {
            _codeProduct = value;
            _codeProductSet = true;
        }
    }

    public bool ShouldSerializeCodeProduct() => _codeProductSet;
}
