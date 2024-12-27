using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class Prop
{
    private string _name;

    private bool _nameSet;

    private string _value;

    private bool _valueSet;

    [XmlAttribute("name")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [XmlAttribute("value")]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValue() => _valueSet;
}
