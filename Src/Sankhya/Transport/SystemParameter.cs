using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

namespace Sankhya.Transport;

[Entity("ParametroSistema")]
public class SystemParameter : IEntity, IEquatable<SystemParameter>
{
    public bool Equals(SystemParameter other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other)
            || (
                string.Equals(_key, other._key, StringComparison.OrdinalIgnoreCase)
                && _keySet == other._keySet
                && string.Equals(
                    _description,
                    other._description,
                    StringComparison.OrdinalIgnoreCase
                )
                && _descriptionSet == other._descriptionSet
                && _codeUser == other._codeUser
                && _codeUserSet == other._codeUserSet
                && _type == other._type
                && _typeSet == other._typeSet
                && string.Equals(_module, other._module, StringComparison.OrdinalIgnoreCase)
                && _moduleSet == other._moduleSet
                && string.Equals(_class, other._class, StringComparison.OrdinalIgnoreCase)
                && _classSet == other._classSet
                && string.Equals(_tab, other._tab, StringComparison.OrdinalIgnoreCase)
                && _tabSet == other._tabSet
                && _logical == other._logical
                && _logicalSet == other._logicalSet
                && _integer == other._integer
                && _integerSet == other._integerSet
                && _decimal == other._decimal
                && _decimalSet == other._decimalSet
                && _date.Equals(other._date)
                && _dateSet == other._dateSet
                && string.Equals(_text, other._text, StringComparison.OrdinalIgnoreCase)
                && _textSet == other._textSet
                && Equals(_user, other._user)
                && _userSet == other._userSet
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj)
            || (obj is SystemParameter parameter && Equals(parameter));
    }

    [SuppressMessage(
        "ReSharper",
        "NonReadonlyMemberInGetHashCode",
        Justification = "Used to compute hash internally"
    )]
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode =
                _key != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_key) : 0;
            hashCode = (hashCode * 397) ^ _keySet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _description != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_description)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _descriptionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_type;
            hashCode = (hashCode * 397) ^ _typeSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _module != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_module)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _moduleSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _class != null
                        ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_class)
                        : 0
                );
            hashCode = (hashCode * 397) ^ _classSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (_tab != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_tab) : 0);
            hashCode = (hashCode * 397) ^ _tabSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _logical.GetHashCode();
            hashCode = (hashCode * 397) ^ _logicalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _integer;
            hashCode = (hashCode * 397) ^ _integerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _decimal.GetHashCode();
            hashCode = (hashCode * 397) ^ _decimalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _date.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateSet.GetHashCode();
            hashCode =
                (hashCode * 397)
                ^ (
                    _text != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_text) : 0
                );
            hashCode = (hashCode * 397) ^ _textSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _userSet.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(SystemParameter left, SystemParameter right) =>
        Equals(left, right);

    public static bool operator !=(SystemParameter left, SystemParameter right) =>
        !Equals(left, right);

    private string _key;

    private bool _keySet;

    private string _description;

    private bool _descriptionSet;

    private int _codeUser;

    private bool _codeUserSet;

    private SystemParameterType _type;

    private bool _typeSet;

    private string _module;

    private bool _moduleSet;

    private string _class;

    private bool _classSet;

    private string _tab;

    private bool _tabSet;

    private bool _logical;

    private bool _logicalSet;

    private int _integer;

    private bool _integerSet;

    private decimal _decimal;

    private bool _decimalSet;

    private DateTime _date;

    private bool _dateSet;

    private string _text;

    private bool _textSet;

    private User _user;

    private bool _userSet;

    [EntityElement("CHAVE")]
    [EntityKey]
    public string Key
    {
        get => _key;
        set
        {
            _key = value;
            _keySet = true;
        }
    }

    [EntityElement("DESCRICAO")]
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            _descriptionSet = true;
        }
    }

    [EntityElement("CODUSU")]
    public int CodeUser
    {
        get => _codeUser;
        set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    [EntityIgnore]
    public SystemParameterType Type
    {
        get => _type;
        set
        {
            _type = value;
            _typeSet = true;
        }
    }

    [EntityElement("TIPO")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue();
        set
        {
            _type = EnumExtensions.GetEnumByInternalValueAttribute<SystemParameterType>(value);
            _typeSet = true;
        }
    }

    [EntityElement("MODULO")]
    public string Module
    {
        get => _module;
        set
        {
            _module = value;
            _moduleSet = true;
        }
    }

    [EntityElement("CLASSE")]
    public string Class
    {
        get => _class;
        set
        {
            _class = value;
            _classSet = true;
        }
    }

    [EntityElement("ABA")]
    public string Tab
    {
        get => _tab;
        set
        {
            _tab = value;
            _tabSet = true;
        }
    }

    [EntityIgnore]
    public bool Logical
    {
        get => _logical;
        set
        {
            _logical = value;
            _logicalSet = true;
        }
    }

    [EntityElement("LOGICO")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string LogicalInternal
    {
        get => _logical.ToString();
        set
        {
            _logical = value.ToBoolean(@"S|N");
            _logicalSet = true;
        }
    }

    [EntityElement("INTEIRO")]
    public int Integer
    {
        get => _integer;
        set
        {
            _integer = value;
            _integerSet = true;
        }
    }

    [EntityElement("NUMDEC")]
    public decimal Decimal
    {
        get => _decimal;
        set
        {
            _decimal = value;
            _decimalSet = true;
        }
    }

    [EntityElement("DATA")]
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            _dateSet = true;
        }
    }

    [EntityElement("TEXTO")]
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _textSet = true;
        }
    }

    [EntityReference]
    public User User
    {
        get => _user;
        set
        {
            _user = value;
            _userSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeKey() => _keySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeModule() => _moduleSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClass() => _classSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTab() => _tabSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLogical() => _logicalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInteger() => _integerSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDecimal() => _decimalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDate() => _dateSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;
}
