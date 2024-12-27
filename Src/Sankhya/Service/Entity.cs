using System.ComponentModel;
using System.Xml.Serialization;
using Sankhya.Helpers;

namespace Sankhya.Service;

public sealed class Entity
{
    private string _name;

    private bool _nameSet;

    private string _rootEntity;

    private bool _rootEntitySet;

    private bool _includePresentationFields;

    private bool _includePresentationFieldsSet;

    private int _rowsLimit;

    private bool _rowsLimitSet;

    private string _path;

    private bool _pathSet;

    private string _dataSetId;

    private bool _dataSetIdSet;

    private Field[] _fields;

    private bool _fieldsSet;

    private FieldValue[] _campos;

    private bool _camposSet;

    private Field _field;

    private bool _fieldSet;

    private Field _fieldset;

    private bool _fieldsetSet;

    private Criteria[] _criterion;

    private bool _criterionSet;

    private LiteralCriteria _literalCriteria;

    private bool _literalCriteriaSet;

    private LiteralCriteriaSql _literalCriteriaSql;

    private bool _literalCriteriaSqlSet;

    private ReferenceFetch[] _referencesFetch;

    private bool _referencesFetchSet;

    private EntityDynamicSerialization[] _ids;

    private bool _idsSet;

    [XmlAttribute(AttributeName = "name")]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            _nameSet = true;
        }
    }

    [XmlAttribute(AttributeName = "rootEntity")]
    public string RootEntity
    {
        get => _rootEntity;
        set
        {
            _rootEntity = value;
            _rootEntitySet = true;
        }
    }

    [XmlAttribute(AttributeName = "getPresentations")]
    public bool IncludePresentationFields
    {
        get => _includePresentationFields;
        set
        {
            _includePresentationFields = value;
            _includePresentationFieldsSet = true;
        }
    }

    [XmlAttribute(AttributeName = "rowsLimit")]
    public int RowsLimit
    {
        get => _rowsLimit;
        set
        {
            _rowsLimit = value;
            _rowsLimitSet = true;
        }
    }

    [XmlAttribute(AttributeName = "path")]
    public string Path
    {
        get => _path;
        set
        {
            _path = value;
            _pathSet = true;
        }
    }

    [XmlAttribute(AttributeName = "datasetid")]
    public string DataSetId
    {
        get => _dataSetId;
        set
        {
            _dataSetId = value;
            _dataSetIdSet = true;
        }
    }

    [XmlArray("fields")]
    [XmlArrayItem("field")]
    public Field[] Fields
    {
        get => _fields;
        set
        {
            _fields = value;
            _fieldsSet = true;
        }
    }

    [XmlElement("campo")]
    public FieldValue[] Campos
    {
        get => _campos;
        set
        {
            _campos = value;
            _camposSet = true;
        }
    }

    [XmlElement(ElementName = "field")]
    public Field Field
    {
        get => _field;
        set
        {
            _field = value;
            _fieldSet = true;
        }
    }

    [XmlElement("fieldset")]
    public Field Fieldset
    {
        get => _fieldset;
        set
        {
            _fieldset = value;
            _fieldsetSet = true;
        }
    }

    [XmlElement(ElementName = "criterio")]
    public Criteria[] Criteria
    {
        get => _criterion;
        set
        {
            _criterion = value;
            _criterionSet = true;
        }
    }

    [XmlElement(ElementName = "literalCriteria")]
    public LiteralCriteria LiteralCriteria
    {
        get => _literalCriteria;
        set
        {
            _literalCriteria = value;
            _literalCriteriaSet = true;
        }
    }

    [XmlElement("criterioLiteral")]
    public LiteralCriteriaSql LiteralCriteriaSql
    {
        get => _literalCriteriaSql;
        set
        {
            _literalCriteriaSql = value;
            _literalCriteriaSqlSet = true;
        }
    }

    [XmlElement(ElementName = "referenceFetch")]
    public ReferenceFetch[] ReferencesFetch
    {
        get => _referencesFetch;
        set
        {
            _referencesFetch = value;
            _referencesFetchSet = true;
        }
    }

    [XmlElement("id")]
    public EntityDynamicSerialization[] Ids
    {
        get => _ids;
        set
        {
            _ids = value;
            _idsSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeName() => _nameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRootEntity() => _rootEntitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIncludePresentationFields() => _includePresentationFieldsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRowsLimit() => _rowsLimitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePath() => _pathSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSetId() => _dataSetIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFields() => _fieldsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCampos() => _camposSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeField() => _fieldSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFieldset() => _fieldsetSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCriteria() => _criterionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteria() => _literalCriteriaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLiteralCriteriaSql() => _literalCriteriaSqlSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReferencesFetch() => _referencesFetchSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIds() => _idsSet;
}
