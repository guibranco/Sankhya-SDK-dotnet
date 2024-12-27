using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class ResponseBody
{
    private int _codeUserLoggedIn;

    private bool _codeUserLoggedInSet;

    private int _codeUser;

    private bool _codeUserSet;

    private string _callId;

    private bool _callIdSet;

    private string _jSessionId;

    private bool _jSessionIdSet;

    private CrudServiceEntities _crudServiceEntities;

    private bool _crudServiceEntitiesSet;

    private CrudServiceProviderEntities _crudServiceProviderEntities;

    private bool _crudServiceProviderEntitiesSet;

    private InvoiceAccompaniments _invoiceAccompaniments;

    private bool _invoiceAccompanimentsSet;

    private Users _users;

    private bool _usersSet;

    private Invoices _invoices;

    private bool _invoicesSet;

    private SessionsResponse _sessions;

    private bool _sessionsSet;

    private Warnings _warnings;

    private bool _warningsSet;

    private CancellationResult _cancellationResult;

    private bool _cancellationResultSet;

    private Key _key;

    private bool _keySet;

    private dynamic _primaryKey;

    private bool _primaryKeySet;

    private ClientEvents _clientEvents;

    private bool _clientEventsSet;

    private Messages _messages;

    private bool _messagesSet;

    private Releases _releases;

    private bool _releasesSet;

    private MessageUnlinkShipping _messageUnlinkShipping;

    private bool _messageUnlinkShippingSet;

    [XmlElement("codUsuLogado")]
    public int CodeUserLoggedIn
    {
        get => _codeUserLoggedIn;
        set
        {
            _codeUserLoggedIn = value;
            _codeUserLoggedInSet = true;
        }
    }

    [XmlIgnore]
    public int CodeUser
    {
        get => _codeUser;
        set
        {
            _codeUser = value;
            _codeUserSet = true;
        }
    }

    [XmlElement("idusu")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string CodeUserInternal
    {
        get => _codeUser.ToString().ToBase64();
        set
        {
            _codeUser = value.FromBase64().ToInt32();
            _codeUserSet = true;
        }
    }

    [XmlElement("callID")]
    public string CallId
    {
        get => _callId;
        set
        {
            _callId = value;
            _callIdSet = true;
        }
    }

    [XmlElement("jsessionid")]
    public string JSessionId
    {
        get => _jSessionId;
        set
        {
            _jSessionId = value;
            _jSessionIdSet = true;
        }
    }

    [XmlElement("entidades")]
    public CrudServiceEntities CrudServiceEntities
    {
        get => _crudServiceEntities;
        set
        {
            _crudServiceEntities = value;
            _crudServiceEntitiesSet = true;
        }
    }

    [XmlElement("entities")]
    public CrudServiceProviderEntities CrudServiceProviderEntities
    {
        get => _crudServiceProviderEntities;
        set
        {
            _crudServiceProviderEntities = value;
            _crudServiceProviderEntitiesSet = true;
        }
    }

    [XmlElement("acompanhamentosNotas")]
    public InvoiceAccompaniments InvoiceAccompaniments
    {
        get => _invoiceAccompaniments;
        set
        {
            _invoiceAccompaniments = value;
            _invoiceAccompanimentsSet = true;
        }
    }

    [XmlElement("usuarios")]
    public Users Users
    {
        get => _users;
        set
        {
            _users = value;
            _usersSet = true;
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

    [XmlElement("SESSIONS")]
    public SessionsResponse Sessions
    {
        get => _sessions;
        set
        {
            _sessions = value;
            _sessionsSet = true;
        }
    }

    [XmlElement("avisos")]
    public Warnings Warnings
    {
        get => _warnings;
        set
        {
            _warnings = value;
            _warningsSet = true;
        }
    }

    [XmlElement("resultadoCancelamento")]
    public CancellationResult CancellationResult
    {
        get => _cancellationResult;
        set
        {
            _cancellationResult = value;
            _cancellationResultSet = true;
        }
    }

    [XmlElement("chave")]
    public Key Key
    {
        get => _key;
        set
        {
            _key = value;
            _keySet = true;
        }
    }

    [XmlArray("PK")]
    public dynamic PrimaryKey
    {
        get => _primaryKey;
        set
        {
            _primaryKey = value;
            _primaryKeySet = true;
        }
    }

    [XmlElement("clientEvents")]
    public ClientEvents ClientEvents
    {
        get => _clientEvents;
        set
        {
            _clientEvents = value;
            _clientEventsSet = true;
        }
    }

    [XmlElement("mensagens")]
    public Messages Messages
    {
        get => _messages;
        set
        {
            _messages = value;
            _messagesSet = true;
        }
    }

    [XmlElement("liberacoes")]
    public Releases Releases
    {
        get => _releases;
        set
        {
            _releases = value;
            _releasesSet = true;
        }
    }

    [XmlElement("msgDesvincularRemessa")]
    public MessageUnlinkShipping MessageUnlinkShipping
    {
        get => _messageUnlinkShipping;
        set
        {
            _messageUnlinkShipping = value;
            _messageUnlinkShippingSet = true;
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUserLoggedIn() => _codeUserLoggedInSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUserInternal() => _codeUserSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCallId() => _callIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeJSessionId() => _jSessionIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCrudServiceEntities() => _crudServiceEntitiesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCrudServiceProviderEntities() => _crudServiceProviderEntitiesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccompanimentsInvoices() => _invoiceAccompanimentsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUsers() => _usersSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoices() => _invoicesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSessions() => _sessionsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeWarnings() => _warningsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancellationResult() => _cancellationResultSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeKey() => _keySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePrimaryKey() => _primaryKeySet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvents() => _clientEventsSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessages() => _messagesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleases() => _releasesSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessageUnlinkShipping() => _messageUnlinkShippingSet;
}
