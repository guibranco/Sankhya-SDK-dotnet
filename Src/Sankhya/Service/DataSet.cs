using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class DataSet
{
    private string _rootEntity;

    private bool _rootEntitySet;

    private bool _includePresentationFields;

    private bool _includePresentationFieldsSet;

    private bool _parallelLoader;

    private bool _parallelLoaderSet;

    private int _pageNumber;

    private bool _pageNumberSet;

    private string _pagerId;

    private bool _pagerIdSet;

    private string _dataSetId;

    private bool _dataSetIdSet;

    private DataRow[] _dataRows;

    private bool _dataRowsSet;

    private LiteralCriteria _literalCriteria;

    private bool _literalCriteriaSet;

    private Entity[] _entities;

    private bool _entitiesSet;

    [XmlAttribute("rootEntity")]
    public string RootEntity
    {
        get => _rootEntity;
        set
        {
            _rootEntity = value;
            _rootEntitySet = true;
        }
    }

    [XmlIgnore]
    public bool IncludePresentationFields
    {
        get => _includePresentationFields;
        set
        {
            _includePresentationFields = value;
            _includePresentationFieldsSet = true;
        }
    }

    [XmlAttribute("includePresentationFields")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IncludePresentationFieldsInternal
    {
        get => _includePresentationFields.ToString(@"S", @"N");
        set
        {
            _includePresentationFields = value.ToBoolean();
            _includePresentationFieldsSet = true;
        }
    }

    [XmlIgnore]
    public bool ParallelLoader
    {
        get => _parallelLoader;
        set
        {
            _parallelLoader = value;
            _parallelLoaderSet = true;
        }
    }

    [XmlAttribute("parallelLoader")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ParallelLoaderInternal
    {
        get => _parallelLoader.ToString(@"true", @"false");
        set
        {
            _parallelLoader = value.ToBoolean(@"true");
            _parallelLoaderSet = true;
        }
    }

    [XmlAttribute("pageNumber")]
    public int PageNumber
    {
        get => _pageNumber;
        set
        {
            _pageNumber = value;
            _pageNumberSet = true;
        }
    }

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

    [XmlAttribute("datasetid")]
    public string DataSetId
    {
        get => _dataSetId;
        set
        {
            _dataSetId = value;
            _dataSetIdSet = true;
        }
    }

    [XmlElement("dataRow")]
    public DataRow[] DataRows
    {
        get => _dataRows;
        set
        {
            _dataRows = value;
            _dataRowsSet = true;
        }
    }

    [XmlElement("criteria")]
    public LiteralCriteria LiteralCriteria
    {
        get => _literalCriteria;
        set
        {
            _literalCriteria = value;
            _literalCriteriaSet = true;
        }
    }

    [XmlElement(ElementName = "entity")]
    public Entity[] Entities
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
    public bool ShouldSerializeRootEntity() => _rootEntitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIncludePresentationFieldsInternal() => _includePresentationFieldsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParallelLoaderInternal() => _parallelLoaderSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePageNumber() => _pageNumberSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePagerId() => _pagerIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSetId() => _dataSetIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataRows() => _dataRowsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteria() => _literalCriteriaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;
}
