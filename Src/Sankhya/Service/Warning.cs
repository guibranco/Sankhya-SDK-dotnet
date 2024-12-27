using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

[XmlType("aviso")]
public sealed class Warning
{
    private int _singleNumber;

    private bool _singleNumberSet;

    private string _message;

    private bool _messageSet;

    [XmlAttribute(AttributeName = "nunota")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    [XmlText]
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            _messageSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessage() => _messageSet;
}
