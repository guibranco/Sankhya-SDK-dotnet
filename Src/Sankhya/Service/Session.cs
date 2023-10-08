using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class Session
{
    /// <summary>
    /// The identifier
    /// </summary>
    private string _id;

    /// <summary>
    /// The identifier set
    /// </summary>
    private bool _idSet;

    /// <summary>
    /// The creation time
    /// </summary>
    private string _creationTime;

    /// <summary>
    /// The creation time set
    /// </summary>
    private bool _creationTimeSet;

    /// <summary>
    /// The last accessed time
    /// </summary>
    private string _lastAccessedTime;

    /// <summary>
    /// The last accessed time set
    /// </summary>
    private bool _lastAccessedTimeSet;

    /// <summary>
    /// The inactive interval
    /// </summary>
    private int _inactiveInterval;

    /// <summary>
    /// The inactive interval set
    /// </summary>
    private bool _inactiveIntervalSet;

    /// <summary>
    /// The maximum inactive interval
    /// </summary>
    private int _maxInactiveInterval;

    /// <summary>
    /// The maximum inactive interval set
    /// </summary>
    private bool _maxInactiveIntervalSet;

    /// <summary>
    /// The user agent
    /// </summary>
    private string _userAgent;

    /// <summary>
    /// The user agent set
    /// </summary>
    private bool _userAgentSet;

    /// <summary>
    /// The host
    /// </summary>
    private string _host;

    /// <summary>
    /// The host set
    /// </summary>
    private bool _hostSet;

    /// <summary>
    /// The login time
    /// </summary>
    private string _loginTime;

    /// <summary>
    /// The login time set
    /// </summary>
    private bool _loginTimeSet;

    /// <summary>
    /// The is authenticated
    /// </summary>
    private bool _isAuthenticated;

    /// <summary>
    /// The is authenticated set
    /// </summary>
    private bool _isAuthenticatedSet;

    /// <summary>
    /// The user identifier
    /// </summary>
    private int _userId;

    /// <summary>
    /// The user identifier set
    /// </summary>
    private bool _userIdSet;

    /// <summary>
    /// The user name
    /// </summary>
    private string _userName;

    /// <summary>
    /// The user name set
    /// </summary>
    private bool _userNameSet;

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [XmlAttribute("ID")]
    public string Id
    {
        get => _id;
        set
        {
            _id = value;
            _idSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the creation time.
    /// </summary>
    /// <value>The creation time.</value>
    [XmlAttribute("CREATIONTIME")]
    public string CreationTime
    {
        get => _creationTime;
        set
        {
            _creationTime = value;
            _creationTimeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the last accessed time.
    /// </summary>
    /// <value>The last accessed time.</value>
    [XmlAttribute("LASTACCESSEDTIME")]
    public string LastAccessedTime
    {
        get => _lastAccessedTime;
        set
        {
            _lastAccessedTime = value;
            _lastAccessedTimeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the inactive interval.
    /// </summary>
    /// <value>The inactive interval.</value>
    [XmlAttribute("INACTIVEINTERVAL")]
    public int InactiveInterval
    {
        get => _inactiveInterval;
        set
        {
            _inactiveInterval = value;
            _inactiveIntervalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the maximum inactive interval.
    /// </summary>
    /// <value>The maximum inactive interval.</value>
    [XmlAttribute("MAXINACTIVEINTERVAL")]
    public int MaxInactiveInterval
    {
        get => _maxInactiveInterval;
        set
        {
            _maxInactiveInterval = value;
            _maxInactiveIntervalSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the user agent.
    /// </summary>
    /// <value>The user agent.</value>
    [XmlAttribute("USERAGENT")]
    public string UserAgent
    {
        get => _userAgent;
        set
        {
            _userAgent = value;
            _userAgentSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the host.
    /// </summary>
    /// <value>The host.</value>
    [XmlAttribute("HOST")]
    public string Host
    {
        get => _host;
        set
        {
            _host = value;
            _hostSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the login time.
    /// </summary>
    /// <value>The login time.</value>
    [XmlAttribute("LOGINTIME")]
    public string LoginTime
    {
        get => _loginTime;
        set
        {
            _loginTime = value;
            _loginTimeSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the is authenticated.
    /// </summary>
    /// <value>The is authenticated.</value>
    [XmlIgnore]
    public bool IsAuthenticated
    {
        get => _isAuthenticated;
        set
        {
            _isAuthenticated = value;
            _isAuthenticatedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the is authenticated internal.
    /// </summary>
    /// <value>The is authenticated internal.</value>
    [XmlAttribute("AUTHENTICATED")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IsAuthenticatedInternal
    {
        get => _isAuthenticated.ToString(@"S", @"N");
        set
        {
            _isAuthenticated = value.ToBoolean();
            _isAuthenticatedSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    [XmlAttribute("USERID")]
    public int UserId
    {
        get => _userId;
        set
        {
            _userId = value;
            _userIdSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
    [XmlAttribute("USERNAME")]
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            _userNameSet = true;
        }
    }

    /// <summary>
    /// Should the serialize identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeId() => _idSet;

    /// <summary>
    /// Should the serialize creation time.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCreationTime() => _creationTimeSet;

    /// <summary>
    /// Should the serialize last accessed time.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLastAccessedTime() => _lastAccessedTimeSet;

    /// <summary>
    /// Should the serialize inactive interval.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInactiveInterval() => _inactiveIntervalSet;

    /// <summary>
    /// Should the serialize maximum inactive interval.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMaxInactiveInterval() => _maxInactiveIntervalSet;

    /// <summary>
    /// Should the serialize user agent.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserAgent() => _userAgentSet;

    /// <summary>
    /// Should the serialize host.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHost() => _hostSet;

    /// <summary>
    /// Should the serialize login time.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLoginTime() => _loginTimeSet;

    /// <summary>
    /// Should the serialize is authenticated.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsAuthenticatedInternal() => _isAuthenticatedSet;

    /// <summary>
    /// Should the serialize user identifier.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserId() => _userIdSet;

    /// <summary>
    /// Should the name of the serialize user.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserName() => _userNameSet;
}
