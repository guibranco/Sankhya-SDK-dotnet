using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class Message
{
    private string _text;

    private bool _textSet;

    [XmlText]
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _textSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;
}
