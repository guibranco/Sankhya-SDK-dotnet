using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

public sealed class Parameter
{
    [XmlAttribute(AttributeName = "type")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => Type.GetInternalValue();
        set => Type = EnumExtensions.GetEnumByInternalValueAttribute<ParameterType>(value);
    }

    [XmlIgnore]
    public ParameterType Type { get; set; }

    [XmlText]
    public string Value { get; set; }
}
