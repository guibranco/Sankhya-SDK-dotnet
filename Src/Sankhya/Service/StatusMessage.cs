using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class StatusMessage
{
    private string _value;

    private bool _valueSet;

    [XmlIgnore]
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            _valueSet = true;
        }
    }

    [XmlText]
    public string ValueInternal
    {
        get => _value.ToBase64();
        set
        {
            _value = value.FromBase64();
            _valueSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValueInternal() => _valueSet;
}
