namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;
using Sankhya.Helpers;

public sealed class Entity
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
    /// The rows limit
    /// </summary>
    private int _rowsLimit;
    /// <summary>
    /// The rows limit set
    /// </summary>
    private bool _rowsLimitSet;

    /// <summary>
    /// The path
    /// </summary>
    private string _path;
    /// <summary>
    /// The path set
    /// </summary>
    private bool _pathSet;

    /// <summary>
    /// The data set identifier
    /// </summary>
    private string _dataSetId;
    /// <summary>
    /// The data set identifier set
    /// </summary>
    private bool _dataSetIdSet;

    /// <summary>
    /// The fields
    /// </summary>
    private Field[] _fields;
    /// <summary>
    /// The fields set
    /// </summary>
    private bool _fieldsSet;

    /// <summary>
    /// The campos
    /// </summary>
    private FieldValue[] _campos;
    /// <summary>
    /// The campos set
    /// </summary>
    private bool _camposSet;

    /// <summary>
    /// The field
    /// </summary>
    private Field _field;
    /// <summary>
    /// The field set
    /// </summary>
    private bool _fieldSet;

    /// <summary>
    /// The fieldset
    /// </summary>
    private Field _fieldset;
    /// <summary>
    /// The fieldset set
    /// </summary>
    private bool _fieldsetSet;

    /// <summary>
    /// The criterion
    /// </summary>
    private Criteria[] _criterion;

    /// <summary>
    /// The criterion set
    /// </summary>
    private bool _criterionSet;

    /// <summary>
    /// The literal criteria
    /// </summary>
    private LiteralCriteria _literalCriteria;
    /// <summary>
    /// The literal criteria set
    /// </summary>
    private bool _literalCriteriaSet;

    /// <summary>
    /// The literal criteria SQL
    /// </summary>
    private LiteralCriteriaSql _literalCriteriaSql;
    /// <summary>
    /// The literal criteria SQL set
    /// </summary>
    private bool _literalCriteriaSqlSet;

    /// <summary>
    /// The references fetch
    /// </summary>
    private ReferenceFetch[] _referencesFetch;
    /// <summary>
    /// The references fetch set
    /// </summary>
    private bool _referencesFetchSet;

    /// <summary>
    /// The ids
    /// </summary>
    private EntityDynamicSerialization[] _ids;
    /// <summary>
    /// The ids set
    /// </summary>
    private bool _idsSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [XmlAttribute(AttributeName = "name")]
    public string Name
    {
        get => _name; set
        {
            _name = value;
            _nameSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the root entity.
    /// </summary>
    /// <value>The root entity.</value>
    [XmlAttribute(AttributeName = "rootEntity")]
    public string RootEntity
    {
        get => _rootEntity; set
        {
            _rootEntity = value;
            _rootEntitySet = true;
        }
    }

    /// <summary>
    /// Gets or sets the include presentation fields.
    /// </summary>
    /// <value>The include presentation fields.</value>
    [XmlAttribute(AttributeName = "getPresentations")]
    public bool IncludePresentationFields
    {
        get => _includePresentationFields; set
        {
            _includePresentationFields = value;
            _includePresentationFieldsSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the rows limit.
    /// </summary>
    /// <value>The rows limit.</value>
    [XmlAttribute(AttributeName = "rowsLimit")]
    public int RowsLimit
    {
        get => _rowsLimit; set
        {
            _rowsLimit = value;
            _rowsLimitSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    /// <value>The path.</value>
    [XmlAttribute(AttributeName = "path")]
    public string Path
    {
        get => _path; set
        {
            _path = value;
            _pathSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the data set identifier.
    /// </summary>
    /// <value>The data set identifier.</value>
    [XmlAttribute(AttributeName = "datasetid")]
    public string DataSetId
    {
        get => _dataSetId; set
        {
            _dataSetId = value;
            _dataSetIdSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the fields.
    /// </summary>
    /// <value>The fields.</value>
    [XmlArray("fields")]
    [XmlArrayItem("field")]
    public Field[] Fields
    {
        get => _fields; set
        {
            _fields = value;
            _fieldsSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the campos.
    /// </summary>
    /// <value>The campos.</value>
    [XmlElement("campo")]
    public FieldValue[] Campos
    {
        get => _campos; set
        {
            _campos = value;
            _camposSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the field.
    /// </summary>
    /// <value>The field.</value>
    [XmlElement(ElementName = "field")]
    public Field Field
    {
        get => _field; set
        {
            _field = value;
            _fieldSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the field set.
    /// </summary>
    /// <value>The field set.</value>
    [XmlElement("fieldset")]
    public Field Fieldset
    {
        get => _fieldset; set
        {
            _fieldset = value;
            _fieldsetSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the criterion.
    /// </summary>
    /// <value>The criterion.</value>
    [XmlElement(ElementName = "criterio")]
    public Criteria[] Criteria
    {
        get => _criterion; set
        {
            _criterion = value;
            _criterionSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the literal criteria.
    /// </summary>
    /// <value>The literal criteria.</value>
    [XmlElement(ElementName = "literalCriteria")]
    public LiteralCriteria LiteralCriteria
    {
        get => _literalCriteria; set
        {
            _literalCriteria = value;
            _literalCriteriaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the literal criteria SQL.
    /// </summary>
    /// <value>The literal criteria SQL.</value>
    [XmlElement("criterioLiteral")]
    public LiteralCriteriaSql LiteralCriteriaSql
    {
        get => _literalCriteriaSql; set
        {
            _literalCriteriaSql = value;
            _literalCriteriaSqlSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the references fetch.
    /// </summary>
    /// <value>The references fetch.</value>
    [XmlElement(ElementName = "referenceFetch")]
    public ReferenceFetch[] ReferencesFetch
    {
        get => _referencesFetch; set
        {
            _referencesFetch = value;
            _referencesFetchSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ids.
    /// </summary>
    /// <value>The ids.</value>

    [XmlElement("id")]
    public EntityDynamicSerialization[] Ids
    {
        get => _ids; set
        {
            _ids = value;
            _idsSet = true;
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
    /// Should the serialize root entity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRootEntity() => _rootEntitySet;


    /// <summary>
    /// Should the serialize include presentation fields.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIncludePresentationFields() => _includePresentationFieldsSet;

    /// <summary>
    /// Should the serialize rows limit.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRowsLimit() => _rowsLimitSet;

    /// <summary>
    /// Should the serialize path.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePath() => _pathSet;


    /// <summary>
    /// Should the serialize data set identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSetId() => _dataSetIdSet;

    /// <summary>
    /// Should the serialize fields.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFields() => _fieldsSet;

    /// <summary>
    /// Should the serialize campos.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCampos() => _camposSet;

    /// <summary>
    /// Should the serialize field.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeField() => _fieldSet;

    /// <summary>
    /// Should the serialize fieldset.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFieldset() => _fieldsetSet;


    /// <summary>
    /// Should the serialize criteria.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCriteria() => _criterionSet;


    /// <summary>
    /// Should the serialize literal criteria.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteria() => _literalCriteriaSet;


    /// <summary>
    /// Should the serialize literal criteria SQL.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteriaSql() => _literalCriteriaSqlSet;


    /// <summary>
    /// Should the serialize references fetch.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReferencesFetch() => _referencesFetchSet;


    /// <summary>
    /// Should the serialize ids.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIds() => _idsSet;

    #endregion
}