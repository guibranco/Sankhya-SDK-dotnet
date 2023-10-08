using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

/// <summary>
/// A data set.
/// </summary>
public sealed class DataSet
{
    /// <summary>
    /// The root entity
    /// </summary>
    private string _rootEntity;

    /// <summary>
    /// The root entity set
    /// </summary>
    private bool _rootEntitySet;

    /// <summary>
    /// The include presentation fields
    /// </summary>
    private bool _includePresentationFields;

    /// <summary>
    /// The include presentation fields set
    /// </summary>
    private bool _includePresentationFieldsSet;

    /// <summary>
    /// The parallel loader
    /// </summary>
    private bool _parallelLoader;

    /// <summary>
    /// The parallel loader set
    /// </summary>
    private bool _parallelLoaderSet;

    /// <summary>
    /// The page number
    /// </summary>
    private int _pageNumber;

    /// <summary>
    /// The page number set
    /// </summary>
    private bool _pageNumberSet;

    /// <summary>
    /// The pager identifier
    /// </summary>
    private string _pagerId;

    /// <summary>
    /// The pager identifier set
    /// </summary>
    private bool _pagerIdSet;

    /// <summary>
    /// The data set identifier
    /// </summary>
    private string _dataSetId;

    /// <summary>
    /// The data set identifier set
    /// </summary>
    private bool _dataSetIdSet;

    /// <summary>
    /// The data rows
    /// </summary>
    private DataRow[] _dataRows;

    /// <summary>
    /// The data rows set
    /// </summary>
    private bool _dataRowsSet;

    /// <summary>
    /// The literal criteria
    /// </summary>
    private LiteralCriteria _literalCriteria;

    /// <summary>
    /// The literal criteria set
    /// </summary>
    private bool _literalCriteriaSet;

    /// <summary>
    /// The entities
    /// </summary>
    private Entity[] _entities;

    /// <summary>
    /// The entities set
    /// </summary>
    private bool _entitiesSet;

    /// <summary>
    /// Gets or sets the root entity.
    /// </summary>
    /// <value>The root entity.</value>
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

    /// <summary>
    /// Gets or sets the include presentation fields.
    /// </summary>
    /// <value>The include presentation fields.</value>
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

    /// <summary>
    /// Gets or sets the include presentation fields internal.
    /// </summary>
    /// <value>The include presentation fields internal.</value>
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

    /// <summary>
    /// Gets or sets the parallel loader.
    /// </summary>
    /// <value>The parallel loader.</value>
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

    /// <summary>
    /// Gets or sets the parallel loader internal.
    /// </summary>
    /// <value>The parallel loader internal.</value>
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

    /// <summary>
    /// Gets or sets the page number.
    /// </summary>
    /// <value>The page number.</value>
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
    /// Gets or sets the data set identifier.
    /// </summary>
    /// <value>The data set identifier.</value>
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

    /// <summary>
    /// Gets or sets the data rows.
    /// </summary>
    /// <value>The data rows.</value>
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

    /// <summary>
    /// Gets or sets the literal criteria.
    /// </summary>
    /// <value>The literal criteria.</value>
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

    /// <summary>
    /// Gets or sets the entities.
    /// </summary>
    /// <value>The entities.</value>
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

    /// <summary>
    /// Should the serialize root entity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRootEntity() => _rootEntitySet;

    /// <summary>
    /// Should the serialize include presentation fields internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIncludePresentationFieldsInternal() => _includePresentationFieldsSet;

    /// <summary>
    /// Should the serialize parallel loader internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParallelLoaderInternal() => _parallelLoaderSet;

    /// <summary>
    /// Should the serialize page number.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePageNumber() => _pageNumberSet;

    /// <summary>
    /// Should the serialize pager identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePagerId() => _pagerIdSet;

    /// <summary>
    /// Should the serialize data set identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSetId() => _dataSetIdSet;

    /// <summary>
    /// Should the serialize data rows.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataRows() => _dataRowsSet;

    /// <summary>
    /// Should the serialize literal criteria.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteria() => _literalCriteriaSet;

    /// <summary>
    /// Should the serialize entities.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntities() => _entitiesSet;
}
