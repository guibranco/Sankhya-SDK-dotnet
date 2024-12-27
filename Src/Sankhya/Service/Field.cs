using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class Field
{
    private string _name;

    private bool _nameSet;

    private string _list;

    private bool _listSet;

    private bool _except;

    private bool _exceptSet;

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

    [XmlAttribute("list")]
    public string List
    {
        get => _list;
        set
        {
            _list = value;
            _listSet = true;
        }
    }

    [XmlIgnore]
    public bool Except
    {
        get => _except;
        set
        {
            _except = value;
            _exceptSet = true;
        }
    }

    [XmlAttribute("except")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ExceptInternal
    {
        get => _except.ToString();
        set
        {
            _except = value.ToBoolean(@"S|N");
            _exceptSet = true;
        }
    }

    [XmlText]
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
    public bool ShouldSerializeList() => _listSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeExceptInternal() => _exceptSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeValue() => _valueSet;
}
