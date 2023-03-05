namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;

/// <summary>
/// The CRUD service entities
/// </summary>
public sealed class CrudServiceEntities
{
    #region Private Members

    /// <summary>
    /// The name
    /// </summary>
    private string _name;
    /// <summary>
    /// The name set
    /// </summary>
    private bool _nameSet;

    /// <summary>
    /// The entities
    /// </summary>
    private dynamic[] _entities;
    /// <summary>
    /// The entities set
    /// </summary>
    private bool _entitiesSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [XmlAttribute("nome")]
    public string Name
    {
        get => _name; set
        {
            _name = value;
            _nameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the entities.
    /// </summary>
    /// <value>The entities.</value>
    [XmlArrayItem("entidade")]
    public dynamic[] Entities
    {
        get => _entities; set
        {
            _entities = value;
            _entitiesSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the name of the serialize.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    /// <summary>
    /// Should the serialize entities.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;

    #endregion

}