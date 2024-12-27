using System.Xml.Serialization;
using CrispyWaffle.Serialization;

namespace Sankhya.Service;

[Serializer]
[XmlRoot(ElementName = "config")]
public sealed class Config
{
    private string _path;

    private bool _pathSet;

    [XmlAttribute(AttributeName = "path")]
    public string Path
    {
        get => _path;
        set
        {
            _path = value;
            _pathSet = true;
        }
    }

    public bool ShouldSerializePath() => _pathSet;
}
