using System.ComponentModel;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;

namespace Sankhya.Service;

public sealed class Session
{
    private string _id;

    private bool _idSet;

    private string _creationTime;

    private bool _creationTimeSet;

    private string _lastAccessedTime;

    private bool _lastAccessedTimeSet;

    private int _inactiveInterval;

    private bool _inactiveIntervalSet;

    private int _maxInactiveInterval;

    private bool _maxInactiveIntervalSet;

    private string _userAgent;

    private bool _userAgentSet;

    private string _host;

    private bool _hostSet;

    private string _loginTime;

    private bool _loginTimeSet;

    private bool _isAuthenticated;

    private bool _isAuthenticatedSet;

    private int _userId;

    private bool _userIdSet;

    private string _userName;

    private bool _userNameSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeId() => _idSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCreationTime() => _creationTimeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLastAccessedTime() => _lastAccessedTimeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInactiveInterval() => _inactiveIntervalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeMaxInactiveInterval() => _maxInactiveIntervalSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserAgent() => _userAgentSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeHost() => _hostSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeLoginTime() => _loginTimeSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeIsAuthenticatedInternal() => _isAuthenticatedSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserId() => _userIdSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeUserName() => _userNameSet;
}
