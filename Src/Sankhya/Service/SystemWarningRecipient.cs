using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

public sealed class SystemWarningRecipient
{
    private int _id;

    private bool _idSet;

    private SankhyaWarningType _type;

    private bool _typeSet;

    [XmlAttribute("id")]
    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            _idSet = true;
        }
    }

    [XmlIgnore]
    public SankhyaWarningType Type
    {
        get => _type;
        set
        {
            _type = value;
            _typeSet = true;
        }
    }

    [XmlAttribute("tipo")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue();
        set
        {
            _type = EnumExtensions.GetEnumByInternalValueAttribute<SankhyaWarningType>(value);
            _typeSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeId() => _idSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTypeInternal() => _typeSet;
}
