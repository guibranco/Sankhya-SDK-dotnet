using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class CrudServiceProviderEntities
{
    private string _pagerId;

    private bool _pagerIdSet;

    private int _totalPages;

    private bool _totalPagesSet;

    private int _total;

    private bool _totalSet;

    private Metadata _metadata;

    private bool _metadataSet;

    private dynamic[] _entities;

    private bool _entitiesSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePagerId() => _pagerIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotalPages() => _totalPagesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTotal() => _totalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMetadata() => _metadataSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;
}
