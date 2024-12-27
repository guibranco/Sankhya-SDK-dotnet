using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

public sealed class RequestBody
{
    private Invoice _invoice;

    private bool _invoiceSet;

    private Entity _entity;

    private bool _entitySet;

    private LowData _lowData;

    private bool _lowDataSet;

    private Param _param;

    private bool _paramSet;

    private Params _params;

    private bool _paramsSet;

    private Invoices _invoices;

    private bool _invoicesSet;

    private Session _session;

    private bool _sessionSet;

    private DataSet _dataSet;

    private bool _dataSetSet;

    private CancelledInvoices _cancelledInvoices;

    private bool _cancelledInvoicesSet;

    private SystemWarning _systemWarning;

    private bool _systemWarningSet;

    private SystemMessage _systemMessage;

    private bool _systemMessageSet;

    private Config _config;

    private bool _configSet;

    private string _username;

    private bool _usernameSet;

    private string _password;

    private bool _passwordSet;

    private int[] _singleNumbers;

    private bool _singleNumbersSet;

    private ClientEvent[] _clientEvents;

    private bool _clientEventsSet;

    private NotificationElem _notificationElem;

    private bool _notificationElemSet;

    private Path[] _paths;

    private bool _pathsSet;

    [XmlElement("nota")]
    public Invoice Invoice
    {
        get => _invoice;
        set
        {
            _invoice = value;
            _invoiceSet = true;
        }
    }

    [XmlElement("entity")]
    public Entity Entity
    {
        get => _entity;
        set
        {
            _entity = value;
            _entitySet = true;
        }
    }

    [XmlElement("dadosBaixa")]
    public LowData LowData
    {
        get => _lowData;
        set
        {
            _lowData = value;
            _lowDataSet = true;
        }
    }

    [XmlElement("param")]
    public Param Param
    {
        get => _param;
        set
        {
            _param = value;
            _paramSet = true;
        }
    }

    [XmlElement("params")]
    public Params Params
    {
        get => _params;
        set
        {
            _params = value;
            _paramsSet = true;
        }
    }

    [XmlElement("notas")]
    public Invoices Invoices
    {
        get => _invoices;
        set
        {
            _invoices = value;
            _invoicesSet = true;
        }
    }

    [XmlElement("SESSION")]
    public Session Session
    {
        get => _session;
        set
        {
            _session = value;
            _sessionSet = true;
        }
    }

    [XmlElement("dataSet")]
    public DataSet DataSet
    {
        get => _dataSet;
        set
        {
            _dataSet = value;
            _dataSetSet = true;
        }
    }

    [XmlElement("notasCanceladas")]
    public CancelledInvoices CancelledInvoices
    {
        get => _cancelledInvoices;
        set
        {
            _cancelledInvoices = value;
            _cancelledInvoicesSet = true;
        }
    }

    [XmlElement("aviso")]
    public SystemWarning SystemWarning
    {
        get => _systemWarning;
        set
        {
            _systemWarning = value;
            _systemWarningSet = true;
        }
    }

    [XmlElement("mensagem")]
    public SystemMessage SystemMessage
    {
        get => _systemMessage;
        set
        {
            _systemMessage = value;
            _systemMessageSet = true;
        }
    }

    [XmlElement("config")]
    public Config Config
    {
        get => _config;
        set
        {
            _config = value;
            _configSet = true;
        }
    }

    [XmlElement("NOMUSU")]
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            _usernameSet = true;
        }
    }

    [XmlElement("INTERNO")]
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            _passwordSet = true;
        }
    }

    [XmlArray("nuNotas")]
    [XmlArrayItem("nuNota")]
    public int[] SingleNumbers
    {
        get => _singleNumbers;
        set
        {
            _singleNumbers = value;
            _singleNumbersSet = true;
        }
    }

    [XmlArray("clientEventList")]
    [XmlArrayItem("clientEvent")]
    public ClientEvent[] ClientEvents
    {
        get => _clientEvents;
        set
        {
            _clientEvents = value;
            _clientEventsSet = true;
        }
    }

    [XmlElement("NotificationElem")]
    public NotificationElem NotificationElem
    {
        get => _notificationElem;
        set
        {
            _notificationElem = value;
            _notificationElemSet = true;
        }
    }

    [XmlArray("arquivos")]
    [XmlArrayItem("path")]
    public Path[] Paths
    {
        get => _paths;
        set
        {
            _paths = value;
            _pathsSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoice() => _invoiceSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntity() => _entitySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLowData() => _lowDataSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParam() => _paramSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParams() => _paramsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoices() => _invoicesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSession() => _sessionSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSet() => _dataSetSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancelledInvoices() => _cancelledInvoicesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSystemWarning() => _systemWarningSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSystemMessage() => _systemMessageSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfig() => _configSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUsername() => _usernameSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePassword() => _passwordSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumbers() => _singleNumbersSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvents() => _clientEventsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNotificationElem() => _notificationElemSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePaths() => _pathsSet;
}
