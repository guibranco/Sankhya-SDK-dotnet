using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class CrudServiceEntities
{
    private string _name;

    private bool _nameSet;

    private dynamic[] _entities;

    private bool _entitiesSet;

    [XmlAttribute("nome")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [XmlArrayItem("entidade")]
    public dynamic[] Entities
    {
        get => _entities;
        set
        {
            _entities = value;
            _entitiesSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;
}
