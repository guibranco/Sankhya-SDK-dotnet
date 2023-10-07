using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// A request body.
/// </summary>
public sealed class RequestBody
{
    #region Private Members

    /// <summary>
    /// The invoice
    /// </summary>
    private Invoice _invoice;

    /// <summary>
    /// The invoice set
    /// </summary>
    private bool _invoiceSet;

    /// <summary>
    /// The entity
    /// </summary>
    private Entity _entity;

    /// <summary>
    /// The entity set
    /// </summary>
    private bool _entitySet;

    /// <summary>
    /// The low data
    /// </summary>
    private LowData _lowData;

    /// <summary>
    /// The low data set
    /// </summary>
    private bool _lowDataSet;

    /// <summary>
    /// The parameter
    /// </summary>
    private Param _param;

    /// <summary>
    /// The parameter set
    /// </summary>
    private bool _paramSet;

    /// <summary>
    /// The parameters
    /// </summary>
    private Params _params;

    /// <summary>
    /// The parameters set
    /// </summary>
    private bool _paramsSet;

    /// <summary>
    /// The invoices
    /// </summary>
    private Invoices _invoices;

    /// <summary>
    /// The invoices set
    /// </summary>
    private bool _invoicesSet;

    /// <summary>
    /// The session
    /// </summary>
    private Session _session;

    /// <summary>
    /// The session set
    /// </summary>
    private bool _sessionSet;

    /// <summary>
    /// The data set
    /// </summary>
    private DataSet _dataSet;

    /// <summary>
    /// The data set set
    /// </summary>
    private bool _dataSetSet;

    /// <summary>
    /// The cancelled invoices
    /// </summary>
    private CancelledInvoices _cancelledInvoices;

    /// <summary>
    /// The cancelled invoices set
    /// </summary>
    private bool _cancelledInvoicesSet;

    /// <summary>
    /// The system warning
    /// </summary>
    private SystemWarning _systemWarning;

    /// <summary>
    /// The system warning set
    /// </summary>
    private bool _systemWarningSet;

    /// <summary>
    /// The system message
    /// </summary>
    private SystemMessage _systemMessage;

    /// <summary>
    /// The system message set
    /// </summary>
    private bool _systemMessageSet;

    /// <summary>
    /// The configuration
    /// </summary>
    private Config _config;

    /// <summary>
    /// The configuration set
    /// </summary>
    private bool _configSet;

    /// <summary>
    /// The username
    /// </summary>
    private string _username;

    /// <summary>
    /// The username set
    /// </summary>
    private bool _usernameSet;

    /// <summary>
    /// The password
    /// </summary>
    private string _password;

    /// <summary>
    /// The password set
    /// </summary>
    private bool _passwordSet;

    /// <summary>
    /// The single numbers
    /// </summary>
    private int[] _singleNumbers;

    /// <summary>
    /// The single numbers set
    /// </summary>
    private bool _singleNumbersSet;

    /// <summary>
    /// The client events
    /// </summary>
    private ClientEvent[] _clientEvents;

    /// <summary>
    /// The client events set
    /// </summary>
    private bool _clientEventsSet;

    /// <summary>
    /// The notification elem
    /// </summary>
    private NotificationElem _notificationElem;

    /// <summary>
    /// The notification elem set
    /// </summary>
    private bool _notificationElemSet;

    /// <summary>
    /// The paths
    /// </summary>
    private Path[] _paths;

    /// <summary>
    /// The paths set
    /// </summary>
    private bool _pathsSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the invoice.
    /// </summary>
    /// <value>The invoice.</value>
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

    /// <summary>
    /// Gets or sets the entity.
    /// </summary>
    /// <value>The entity.</value>
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

    /// <summary>
    /// Gets or sets the low data.
    /// </summary>
    /// <value>The low data.</value>
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

    /// <summary>
    /// Gets or sets the parameter.
    /// </summary>
    /// <value>The parameter.</value>
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

    /// <summary>
    /// Gets or sets the parameters.
    /// </summary>
    /// <value>The parameters.</value>
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

    /// <summary>
    /// Gets or sets the invoices.
    /// </summary>
    /// <value>The invoices.</value>
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

    /// <summary>
    /// Gets or sets the session.
    /// </summary>
    /// <value>The session.</value>
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

    /// <summary>
    /// Gets or sets the data set.
    /// </summary>
    /// <value>The data set.</value>
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

    /// <summary>
    /// Gets or sets the cancelled invoices.
    /// </summary>
    /// <value>The cancelled invoices.</value>
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

    /// <summary>
    /// Gets or sets the system warning.
    /// </summary>
    /// <value>The system warning.</value>
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

    /// <summary>
    /// Gets or sets the system message.
    /// </summary>
    /// <value>The system message.</value>
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

    /// <summary>
    /// Gets or sets the configuration.
    /// </summary>
    /// <value>The configuration.</value>
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

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    /// <value>The username.</value>
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

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
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

    /// <summary>
    /// Gets or sets the single numbers.
    /// </summary>
    /// <value>The single numbers.</value>
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

    /// <summary>
    /// Gets or sets the client events.
    /// </summary>
    /// <value>The client events.</value>
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

    /// <summary>
    /// Gets or sets the notification elem.
    /// </summary>
    /// <value>The notification elem.</value>
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

    /// <summary>
    /// Gets or sets the paths.
    /// </summary>
    /// <value>The paths.</value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize invoice.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoice() => _invoiceSet;

    /// <summary>
    /// Should the serialize entity.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEntity() => _entitySet;

    /// <summary>
    /// Should the serialize low data.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLowData() => _lowDataSet;

    /// <summary>
    /// Should the serialize parameter.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParam() => _paramSet;

    /// <summary>
    /// Should the serialize parameters.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParams() => _paramsSet;

    /// <summary>
    /// Should the serialize invoices.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoices() => _invoicesSet;

    /// <summary>
    /// Should the serialize session.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSession() => _sessionSet;

    /// <summary>
    /// Should the serialize data set.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDataSet() => _dataSetSet;

    /// <summary>
    /// Should the serialize cancelled invoices.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancelledInvoices() => _cancelledInvoicesSet;

    /// <summary>
    /// Should the serialize system warning.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSystemWarning() => _systemWarningSet;

    /// <summary>
    /// Should the serialize system message.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSystemMessage() => _systemMessageSet;

    /// <summary>
    /// Should the serialize configuration.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeConfig() => _configSet;

    /// <summary>
    /// Should the serialize username.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUsername() => _usernameSet;

    /// <summary>
    /// Should the serialize password.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePassword() => _passwordSet;

    /// <summary>
    /// Should the serialize single numbers.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSingleNumbers() => _singleNumbersSet;

    /// <summary>
    /// Should the serialize client events.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvents() => _clientEventsSet;

    /// <summary>
    /// Should the serialize notification elem.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNotificationElem() => _notificationElemSet;

    /// <summary>
    /// Should the serializer paths.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePaths() => _pathsSet;

    #endregion
}
