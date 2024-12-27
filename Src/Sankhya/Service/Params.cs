using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using Sankhya.Enums;

namespace Sankhya.Service;

public sealed class Params
{
    private int _singleNumber;

    private bool _singleNumberSet;

    private int _codePartner;

    private bool _codePartnerSet;

    private MovementType _movementType;

    private bool _movementTypeSet;

    [XmlAttribute("nuNota")]
    public int SingleNumber
    {
        get => _singleNumber;
        set
        {
            _singleNumber = value;
            _singleNumberSet = true;
        }
    }

    [XmlAttribute("codParc")]
    public int CodePartner
    {
        get => _codePartner;
        set
        {
            _codePartner = value;
            _codePartnerSet = true;
        }
    }

    [XmlIgnore]
    public MovementType MovementType
    {
        get => _movementType;
        set
        {
            _movementType = value;
            _movementTypeSet = true;
        }
    }

    [XmlAttribute("tipMov")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string MovementTypeInternal
    {
        get => _movementType.GetInternalValue();
        set
        {
            _movementType = EnumExtensions.GetEnumByInternalValueAttribute<MovementType>(value);
            _movementTypeSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumber() => _singleNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodePartner() => _codePartnerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMovementTypeInternal() => _movementTypeSet;
}
