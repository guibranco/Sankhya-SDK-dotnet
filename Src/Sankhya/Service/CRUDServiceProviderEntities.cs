namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;

/// <summary>
/// An entities.
/// </summary>
public sealed class CrudServiceProviderEntities
{
    #region Private Members

    /// <summary>
    /// The pager identifier
    /// </summary>
    private string _pagerId;

    /// <summary>
    /// The pager identifier set
    /// </summary>
    private bool _pagerIdSet;

    /// <summary>
    /// The total pages
    /// </summary>
    private int _totalPages;

    /// <summary>
    /// The total pages set
    /// </summary>
    private bool _totalPagesSet;

    /// <summary>
    /// The total
    /// </summary>
    private int _total;

    /// <summary>
    /// The total set
    /// </summary>
    private bool _totalSet;

    /// <summary>
    /// The metadata
    /// </summary>
    private Metadata _metadata;

    /// <summary>
    /// The metadata set
    /// </summary>
    private bool _metadataSet;

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
    /// Gets or sets the pager identifier.
    /// </summary>
    /// <value>The pager identifier.</value>
    [XmlAttribute("pagerID")]
    public string PagerId
    {
        get => _pagerId;
        set
        {
            _pagerId = value;
            _pagerIdSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the total pages.
    /// </summary>
    /// <value>The total pages.</value>
    [XmlAttribute("totalPages")]
    public int TotalPages
    {
        get => _totalPages;
        set
        {
            _totalPages = value;
            _totalPagesSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>The total.</value>
    [XmlAttribute("total")]
    public int Total
    {
        get => _total;
        set
        {
            _total = value;
            _totalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the metadata.
    /// </summary>
    /// <value>The metadata.</value>
    [XmlElement("metadata")]
    public Metadata Metadata
    {
        get => _metadata;
        set
        {
            _metadata = value;
            _metadataSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the entities.
    /// </summary>
    /// <value>The entities.</value>
    [XmlArrayItem("entity")]
    public dynamic[] Entities
    {
        get => _entities;
        set
        {
            _entities = value;
            _entitiesSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize pager identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePagerId() => _pagerIdSet;

    /// <summary>
    /// Should the serialize total pages.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotalPages() => _totalPagesSet;

    /// <summary>
    /// Should the serialize total.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotal() => _totalSet;

    /// <summary>
    /// Should the serialize metadata.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMetadata() => _metadataSet;

    /// <summary>
    /// Should the serialize entities.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;

    #endregion
}
