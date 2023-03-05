namespace Sankhya.Transport;

using System;
using System.ComponentModel;
using CrispyWaffle.Extensions;
using Sankhya.Attributes;
using Sankhya.Enums;

/// <summary>
/// Class SystemParameter. This class cannot be inherited.
/// </summary>
/// <seealso cref="IEntity" />
[Entity("ParametroSistema")]
public class SystemParameter : IEntity, IEquatable<SystemParameter>
{
    #region Equality members

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
    // ReSharper disable once CyclomaticComplexity
    public bool Equals(SystemParameter other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other) || string.Equals(_key, other._key, StringComparison.InvariantCultureIgnoreCase) &&
            _keySet == other._keySet &&
            string.Equals(_description, other._description, StringComparison.InvariantCultureIgnoreCase) &&
            _descriptionSet == other._descriptionSet && _codeUser == other._codeUser &&
            _codeUserSet == other._codeUserSet && _type == other._type && _typeSet == other._typeSet &&
            string.Equals(_module, other._module, StringComparison.InvariantCultureIgnoreCase) &&
            _moduleSet == other._moduleSet &&
            string.Equals(_class, other._class, StringComparison.InvariantCultureIgnoreCase) &&
            _classSet == other._classSet &&
            string.Equals(_tab, other._tab, StringComparison.InvariantCultureIgnoreCase) &&
            _tabSet == other._tabSet && _logical == other._logical &&
            _logicalSet == other._logicalSet && _integer == other._integer &&
            _integerSet == other._integerSet && _decimal == other._decimal &&
            _decimalSet == other._decimalSet && _date.Equals(other._date) &&
            _dateSet == other._dateSet &&
            string.Equals(_text, other._text, StringComparison.InvariantCultureIgnoreCase) &&
            _textSet == other._textSet && Equals(_user, other._user) && _userSet == other._userSet;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return ReferenceEquals(this, obj) || obj is SystemParameter parameter && Equals(parameter);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _key != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_key) : 0;
            hashCode = (hashCode * 397) ^ _keySet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_description != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_description) : 0);
            hashCode = (hashCode * 397) ^ _descriptionSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _codeUser;
            hashCode = (hashCode * 397) ^ _codeUserSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (int)_type;
            hashCode = (hashCode * 397) ^ _typeSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_module != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_module) : 0);
            hashCode = (hashCode * 397) ^ _moduleSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_class != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_class) : 0);
            hashCode = (hashCode * 397) ^ _classSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_tab != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_tab) : 0);
            hashCode = (hashCode * 397) ^ _tabSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _logical.GetHashCode();
            hashCode = (hashCode * 397) ^ _logicalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _integer;
            hashCode = (hashCode * 397) ^ _integerSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _decimal.GetHashCode();
            hashCode = (hashCode * 397) ^ _decimalSet.GetHashCode();
            hashCode = (hashCode * 397) ^ _date.GetHashCode();
            hashCode = (hashCode * 397) ^ _dateSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_text != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_text) : 0);
            hashCode = (hashCode * 397) ^ _textSet.GetHashCode();
            hashCode = (hashCode * 397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _userSet.GetHashCode();
            return hashCode;
        }
    }

    /// <summary>
    /// Implements the ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(SystemParameter left, SystemParameter right) => Equals(left, right);

    /// <summary>
    /// Implements the !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(SystemParameter left, SystemParameter right) => !Equals(left, right);

    #endregion

    #region Private Members

    /// <summary>
    /// The key
    /// </summary>
    private string _key;
    /// <summary>
    /// The key set
    /// </summary>
    private bool _keySet;

    /// <summary>
    /// The description
    /// </summary>
    private string _description;
    /// <summary>
    /// The description set
    /// </summary>
    private bool _descriptionSet;

    /// <summary>
    /// The code user
    /// </summary>
    private int _codeUser;
    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The type
    /// </summary>
    private SystemParameterType _type;
    /// <summary>
    /// The type set
    /// </summary>
    private bool _typeSet;

    /// <summary>
    /// The module
    /// </summary>
    private string _module;
    /// <summary>
    /// The module set
    /// </summary>
    private bool _moduleSet;

    /// <summary>
    /// The class
    /// </summary>
    private string _class;
    /// <summary>
    /// The class set
    /// </summary>
    private bool _classSet;

    /// <summary>
    /// The tab
    /// </summary>
    private string _tab;
    /// <summary>
    /// The tab set
    /// </summary>
    private bool _tabSet;

    /// <summary>
    /// The logical
    /// </summary>
    private bool _logical;
    /// <summary>
    /// The logical set
    /// </summary>
    private bool _logicalSet;

    /// <summary>
    /// The integer
    /// </summary>
    private int _integer;
    /// <summary>
    /// The integer set
    /// </summary>
    private bool _integerSet;

    /// <summary>
    /// The decimal
    /// </summary>
    private decimal _decimal;
    /// <summary>
    /// The decimal set
    /// </summary>
    private bool _decimalSet;

    /// <summary>
    /// The date
    /// </summary>
    private DateTime _date;
    /// <summary>
    /// The date set
    /// </summary>
    private bool _dateSet;

    /// <summary>
    /// The text
    /// </summary>
    private string _text;
    /// <summary>
    /// The text set
    /// </summary>
    private bool _textSet;

    /// <summary>
    /// The user
    /// </summary>
    private User _user;
    /// <summary>
    /// The user set
    /// </summary>
    private bool _userSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>The key.</value>
    [EntityElement("CHAVE")]
    [EntityKey]
    public string Key
    {
        get => _key; set
        {
            _key = value;
            _keySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [EntityElement("DESCRICAO")]
    public string Description
    {
        get => _description; set
        {
            _description = value;
            _descriptionSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the code user.
    /// </summary>
    /// <value>The code user.</value>
    [EntityElement("CODUSU")]
    public int CodeUser
    {
        get => _codeUser; set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [EntityIgnore]
    public SystemParameterType Type
    {
        get => _type; set
        {
            _type = value;
            _typeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the type internal.
    /// </summary>
    /// <value>The type internal.</value>
    [EntityElement("TIPO")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string TypeInternal
    {
        get => _type.GetInternalValue(); set
        {
            _type = EnumExtensions.GetEnumByInternalValueAttribute<SystemParameterType>(value);
            _typeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the module.
    /// </summary>
    /// <value>The module.</value>
    [EntityElement("MODULO")]
    public string Module
    {
        get => _module; set
        {
            _module = value;
            _moduleSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the class.
    /// </summary>
    /// <value>The class.</value>
    [EntityElement("CLASSE")]
    public string Class
    {
        get => _class; set
        {
            _class = value;
            _classSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the tab.
    /// </summary>
    /// <value>The tab.</value>
    [EntityElement("ABA")]
    public string Tab
    {
        get => _tab; set
        {
            _tab = value;
            _tabSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the logical.
    /// </summary>
    /// <value>The logical.</value>
    [EntityIgnore]
    public bool Logical
    {
        get => _logical; set
        {
            _logical = value;
            _logicalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the logical internal.
    /// </summary>
    /// <value>The logical internal.</value>
    [EntityElement("LOGICO")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string LogicalInternal
    {
        get => _logical.ToString(); set
        {
            _logical = value.ToBoolean(@"S|N");
            _logicalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the integer.
    /// </summary>
    /// <value>The integer.</value>
    [EntityElement("INTEIRO")]
    public int Integer
    {
        get => _integer; set
        {
            _integer = value;
            _integerSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the decimal.
    /// </summary>
    /// <value>The decimal.</value>
    [EntityElement("NUMDEC")]
    public decimal Decimal
    {
        get => _decimal; set
        {
            _decimal = value;
            _decimalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    [EntityElement("DATA")]
    public DateTime Date
    {
        get => _date; set
        {
            _date = value;
            _dateSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    [EntityElement("TEXTO")]
    public string Text
    {
        get => _text; set
        {
            _text = value;
            _textSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    [EntityReference]
    public User User
    {
        get => _user; set
        {
            _user = value;
            _userSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize key.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeKey() => _keySet;

    /// <summary>
    /// Should the serialize description.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDescription() => _descriptionSet;

    /// <summary>
    /// Should the serialize code user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUser() => _codeUserSet;

    /// <summary>
    /// Should the type of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeType() => _typeSet;

    /// <summary>
    /// Should the serialize module.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeModule() => _moduleSet;

    /// <summary>
    /// Should the serialize class.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClass() => _classSet;

    /// <summary>
    /// Should the serialize tab.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTab() => _tabSet;

    /// <summary>
    /// Should the serialize logical.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLogical() => _logicalSet;

    /// <summary>
    /// Should the serialize integer.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInteger() => _integerSet;

    /// <summary>
    /// Should the serialize decimal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDecimal() => _decimalSet;

    /// <summary>
    /// Should the serialize date.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDate() => _dateSet;

    /// <summary>
    /// Should the serialize text.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeText() => _textSet;

    /// <summary>
    /// Should the serialize user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUser() => _userSet;

    #endregion

}