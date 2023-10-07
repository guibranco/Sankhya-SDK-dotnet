using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

/// <summary>
/// A response body.
/// </summary>
public sealed class ResponseBody
{
    #region Private Members

    /// <summary>
    /// The code user logged in
    /// </summary>
    private int _codeUserLoggedIn;

    /// <summary>
    /// The code user logged in set
    /// </summary>
    private bool _codeUserLoggedInSet;

    /// <summary>
    /// The code user
    /// </summary>
    private int _codeUser;

    /// <summary>
    /// The code user set
    /// </summary>
    private bool _codeUserSet;

    /// <summary>
    /// The call identifier
    /// </summary>
    private string _callId;

    /// <summary>
    /// The call identifier set
    /// </summary>
    private bool _callIdSet;

    /// <summary>
    /// The j session identifier
    /// </summary>
    private string _jSessionId;

    /// <summary>
    /// The j session identifier set
    /// </summary>
    private bool _jSessionIdSet;

    /// <summary>
    /// The crud service entities
    /// </summary>
    private CrudServiceEntities _crudServiceEntities;

    /// <summary>
    /// The crud service entities set
    /// </summary>
    private bool _crudServiceEntitiesSet;

    /// <summary>
    /// The crud service provider entities
    /// </summary>
    private CrudServiceProviderEntities _crudServiceProviderEntities;

    /// <summary>
    /// The crud service provider entities set
    /// </summary>
    private bool _crudServiceProviderEntitiesSet;

    /// <summary>
    /// The invoice accompaniments
    /// </summary>
    private InvoiceAccompaniments _invoiceAccompaniments;

    /// <summary>
    /// The invoice accompaniments set
    /// </summary>
    private bool _invoiceAccompanimentsSet;

    /// <summary>
    /// The users
    /// </summary>
    private Users _users;

    /// <summary>
    /// The users set
    /// </summary>
    private bool _usersSet;

    /// <summary>
    /// The invoices
    /// </summary>
    private Invoices _invoices;

    /// <summary>
    /// The invoices set
    /// </summary>
    private bool _invoicesSet;

    /// <summary>
    /// The sessions
    /// </summary>
    private SessionsResponse _sessions;

    /// <summary>
    /// The sessions set
    /// </summary>
    private bool _sessionsSet;

    /// <summary>
    /// The warnings
    /// </summary>
    private Warnings _warnings;

    /// <summary>
    /// The warnings set
    /// </summary>
    private bool _warningsSet;

    /// <summary>
    /// The cancellation result
    /// </summary>
    private CancellationResult _cancellationResult;

    /// <summary>
    /// The cancellation result set
    /// </summary>
    private bool _cancellationResultSet;

    /// <summary>
    /// The key
    /// </summary>
    private Key _key;

    /// <summary>
    /// The key set
    /// </summary>
    private bool _keySet;

    /// <summary>
    /// The primary key
    /// </summary>
    private dynamic _primaryKey;

    /// <summary>
    /// The primary key set
    /// </summary>
    private bool _primaryKeySet;

    /// <summary>
    /// The client events
    /// </summary>
    private ClientEvents _clientEvents;

    /// <summary>
    /// The client events set
    /// </summary>
    private bool _clientEventsSet;

    /// <summary>
    /// The messages
    /// </summary>
    private Messages _messages;

    /// <summary>
    /// The messages set
    /// </summary>
    private bool _messagesSet;

    /// <summary>
    /// The releases
    /// </summary>
    private Releases _releases;

    /// <summary>
    /// The releases set
    /// </summary>
    private bool _releasesSet;

    /// <summary>
    /// The message unlink shipping
    /// </summary>
    private MessageUnlinkShipping _messageUnlinkShipping;

    /// <summary>
    /// The message unlink shipping set
    /// </summary>
    private bool _messageUnlinkShippingSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the code user logged in.
    /// </summary>
    /// <value>The code user logged in.</value>
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

    /// <summary>
    /// Gets or sets the code user.
    /// </summary>
    /// <value>The code user.</value>
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

    /// <summary>
    /// Gets or sets the code user internal.
    /// </summary>
    /// <value>The code user internal.</value>
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

    /// <summary>
    /// Gets or sets the call identifier.
    /// </summary>
    /// <value>The call identifier.</value>
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

    /// <summary>
    /// Gets or sets the j session identifier.
    /// </summary>
    /// <value>The j session identifier.</value>
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

    /// <summary>
    /// Gets or sets the crud service entities.
    /// </summary>
    /// <value>The crud service entities.</value>
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

    /// <summary>
    /// Gets or sets the crud service provider entities.
    /// </summary>
    /// <value>The crud service provider entities.</value>
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

    /// <summary>
    /// Gets or sets the invoice accompaniments.
    /// </summary>
    /// <value>The invoice accompaniments.</value>
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

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
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
    /// Gets or sets the sessions.
    /// </summary>
    /// <value>The sessions.</value>
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

    /// <summary>
    /// Gets or sets the warnings.
    /// </summary>
    /// <value>The warnings.</value>
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

    /// <summary>
    /// Gets or sets the cancellation result.
    /// </summary>
    /// <value>The cancellation result.</value>
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

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>The key.</value>
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

    /// <summary>
    /// Gets or sets the primary key.
    /// </summary>
    /// <value>The primary key.</value>
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

    /// <summary>
    /// Gets or sets the client events.
    /// </summary>
    /// <value>The client events.</value>
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

    /// <summary>
    /// Gets or sets the messages.
    /// </summary>
    /// <value>The messages.</value>
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

    /// <summary>
    /// Gets or sets the releases.
    /// </summary>
    /// <value>The releases.</value>
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

    /// <summary>
    /// Gets or sets the message unlink shipping.
    /// </summary>
    /// <value>
    /// The message unlink shipping.
    /// </value>
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

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize code user logged in.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUserLoggedIn() => _codeUserLoggedInSet;

    /// <summary>
    /// Should the serialize code user internal.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCodeUserInternal() => _codeUserSet;

    /// <summary>
    /// Should the serialize call identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCallId() => _callIdSet;

    /// <summary>
    /// Should the serialize j session identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeJSessionId() => _jSessionIdSet;

    /// <summary>
    /// Should the serialize crud service entities.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCrudServiceEntities() => _crudServiceEntitiesSet;

    /// <summary>
    /// Should the serialize crud service provider entities.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCrudServiceProviderEntities() => _crudServiceProviderEntitiesSet;

    /// <summary>
    /// Should the serialize accompaniments invoices.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAccompanimentsInvoices() => _invoiceAccompanimentsSet;

    /// <summary>
    /// Should the serialize users.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUsers() => _usersSet;

    /// <summary>
    /// Should the serialize invoices.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInvoices() => _invoicesSet;

    /// <summary>
    /// Should the serialize sessions.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeSessions() => _sessionsSet;

    /// <summary>
    /// Should the serialize warnings.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeWarnings() => _warningsSet;

    /// <summary>
    /// Should the serialize cancellation result.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCancellationResult() => _cancellationResultSet;

    /// <summary>
    /// Should the serialize key.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeKey() => _keySet;

    /// <summary>
    /// Should the serialize primary key.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializePrimaryKey() => _primaryKeySet;

    /// <summary>
    /// Should the serialize client events.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeClientEvents() => _clientEventsSet;

    /// <summary>
    /// Should the serialize messages.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessages() => _messagesSet;

    /// <summary>
    /// Should the serialize releases.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeReleases() => _releasesSet;

    /// <summary>
    /// Should the serialize message unlink shipping.
    /// </summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMessageUnlinkShipping() => _messageUnlinkShippingSet;

    #endregion
}
