using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CrispyWaffle.Extensions;
using CrispyWaffle.Infrastructure;
using CrispyWaffle.Log;
using CrispyWaffle.Serialization;
using CrispyWaffle.Utilities;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Properties;
using Sankhya.Service;
using Sankhya.ValueObjects;

namespace Sankhya;

/// <summary>
/// Class ServiceWrapper. This class cannot be inherited.
/// </summary>
internal class SankhyaWrapper
{
    #region Private fields

    /// <summary>
    /// The locks
    /// </summary>
    private static readonly ConcurrentDictionary<string, object> Locks = new();

    /// <summary>
    /// The disposed
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// The session identifier
    /// </summary>
    private string _sessionId;

    /// <summary>
    /// The username
    /// </summary>
    private string _username;

    /// <summary>
    /// The password
    /// </summary>
    private string _password;

    /// <summary>
    /// The host
    /// </summary>
    private readonly string _host;

    /// <summary>
    /// The port
    /// </summary>
    private readonly int _port;

    /// <summary>
    /// The request type
    /// </summary>
    private readonly string _requestType;

    /// <summary>
    /// The request count
    /// </summary>
    private static int _requestCount;

    /// <summary>
    /// The internal user agent
    /// </summary>
    private static string _internalUserAgent;

    /// <summary>
    /// The invalid session ids
    /// </summary>
    private static readonly List<string> InvalidSessionIds = new();

    /// <summary>
    /// Gets the internal user agent.
    /// </summary>
    /// <value>The internal user agent.</value>
    private static string InternalUserAgent
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(_internalUserAgent))
            {
                return _internalUserAgent;
            }

            var assembly = Assembly.GetAssembly(typeof(SankhyaWrapper)).GetName();
            _internalUserAgent = $@"{assembly.Name}/{assembly.Version}";
            return _internalUserAgent;
        }
    }

    /// <summary>
    /// The MIME types to extensions dictionary
    /// </summary>
    private static readonly Dictionary<string, string> MimeTypes2Extensions =
        new()
        {
            { @"image/jpeg", @"jpg" },
            { @"image/png", @"png" },
            { @"image/gif", @"gif" }
        };

    #endregion

    #region ~Ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="SankhyaWrapper" /> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="port">The port.</param>
    /// <param name="requestType">Type of the request.</param>
    public SankhyaWrapper(string host, int port, ServiceRequestType requestType)
    {
        UserCode = -1;
        _host = Regex.Replace(
            host,
            "^https?://",
            string.Empty,
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase
        );
        _port = port;
        switch (port)
        {
            case 8180:
                Environment = ServiceEnvironment.Production;
                DatabaseName = @"SANKHYA_PRODUCAO";
                break;
            case 8280:
                Environment = ServiceEnvironment.Sandbox;
                DatabaseName = @"SANKHYA_HOMOLOGACAO";
                break;
            case 8380:
                Environment = ServiceEnvironment.Training;
                DatabaseName = @"SANKHYA_SANDBOX";
                break;
            default:
                Environment = ServiceEnvironment.None;
                break;
        }

        _requestType = requestType.GetHumanReadableValue();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SankhyaWrapper" /> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="port">The port.</param>
    /// <param name="requestType">Type of the request.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="databaseName">Name of the database.</param>
    /// <exception cref="ArgumentOutOfRangeException">environment - null</exception>
    public SankhyaWrapper(
        string host,
        int port,
        ServiceRequestType requestType,
        ServiceEnvironment environment,
        string databaseName = null
    )
    {
        UserCode = -1;
        _host = Regex.Replace(
            host,
            "^https?://",
            string.Empty,
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase
        );
        _port = port;
        _requestType = requestType.GetHumanReadableValue();
        Environment = environment;
        if (!string.IsNullOrWhiteSpace(databaseName))
        {
            DatabaseName = databaseName;
            return;
        }

        DatabaseName = environment switch
        {
            ServiceEnvironment.Production => @"SANKHYA_PRODUCAO",
            ServiceEnvironment.Sandbox => @"SANKHYA_HOMOLOGACAO",
            ServiceEnvironment.Training => @"SANKHYA_TREINAMENTO",
            _ => throw new ArgumentOutOfRangeException(nameof(environment), environment, null)
        };
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="SankhyaWrapper" /> class.
    /// </summary>
    ~SankhyaWrapper() => Dispose(false);

    #endregion

    #region Implementation of IDisposable

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the specified disposing.
    /// </summary>
    /// <param name="disposing">The disposing.</param>
    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            Invalidate();
        }

        _disposed = true;
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets the environment.
    /// </summary>
    /// <value>The environment.</value>

    public ServiceEnvironment Environment { get; }

    /// <summary>
    /// Gets the name of the database.
    /// </summary>
    /// <value>The name of the database.</value>

    public string DatabaseName { get; }

    /// <summary>
    /// Gets the user code.
    /// </summary>
    /// <value>The user code.</value>

    public int UserCode { get; private set; }

    #endregion

    #region Service connector

    /// <summary>
    /// Generics the web request factory.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="query">The query.</param>
    /// <returns>HttpWebRequest.</returns>
    [Localizable(false)]
    private HttpWebRequest GenericWebRequestFactory(string path, QueryStringBuilder query)
    {
        var cookieContainer = new CookieContainer();
        if (!string.IsNullOrWhiteSpace(_sessionId))
        {
            query.Add("mgeSession", _sessionId);
            cookieContainer.Add(
                new(string.Concat("http://", _host, ":", _port)),
                new Cookie(SankhyaConstants.SessionIdCookieName, _sessionId)
            );
        }

        var builder = new UriBuilder("http", _host, _port, path, query.ToString());
        LogConsumer.Debug(builder.Uri.ToString());
        var request = (HttpWebRequest)WebRequest.Create(builder.Uri);
        request.KeepAlive = true;
        request.CookieContainer = cookieContainer;
        request.UserAgent = $"{EnvironmentHelper.UserAgent} ({InternalUserAgent}+{_requestType})";
        return request;
    }

    /// <summary>
    /// Webs the request factory.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="module">The module.</param>
    /// <returns>HttpWebRequest.</returns>
    [Localizable(false)]
    private HttpWebRequest WebRequestFactory(ServiceName service, ServiceModule module)
    {
        var request = GenericWebRequestFactory(
            $"{module.GetInternalValue()}/service.sbr",
            new() { { "serviceName", service.GetInternalValue() } }
        );
        request.Method = "POST";
        request.ContentType = "text/xml;charset=UTF-8";
        if (service == ServiceName.Login)
        {
            RegisterUserAgent(
                _host,
                _port,
                _username,
                _password,
                request.CookieContainer,
                _requestType
            );
        }

        return request;
    }

    /// <summary>
    /// Services the invoker internal.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="body">The body.</param>
    /// <returns>HttpWebResponse.</returns>
    [Localizable(false)]
    private static HttpWebResponse ServiceInvokerInternal(WebRequest connection, string body = null)
    {
        if (body == null)
        {
            return (HttpWebResponse)connection.GetResponse();
        }

        if (body.IndexOf("<?xml version=", StringComparison.InvariantCultureIgnoreCase) == -1)
        {
            body = string.Concat("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n", body);
        }

        var stream = connection.GetRequestStream();
        var bytes = Encoding.UTF8.GetBytes(body);
        stream.Write(bytes, 0, bytes.Length);
        stream.Flush();
        stream.Close();
        return (HttpWebResponse)connection.GetResponse();
    }

    /// <summary>
    /// Services the invoker.
    /// </summary>
    /// <param name="serviceName">Name of the service.</param>
    /// <param name="request">The request.</param>
    /// <returns>ServiceResponse.</returns>
    private ServiceResponse ServiceInvoker(ServiceName serviceName, ServiceRequest request = null)
    {
        var service = serviceName.GetService();
        var lockKey = string.IsNullOrWhiteSpace(_sessionId) ? nameof(ServiceInvoker) : _sessionId;
        var attemptCount = 0;
        ServiceResponse result;
        while (true)
        {
            result = ServiceInvokerInternal(
                request,
                service.Module,
                serviceName,
                service.Category,
                service.Type,
                lockKey,
                ref attemptCount
            );
            if (result != null)
            {
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// Services the invoker internal.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="module">The module.</param>
    /// <param name="name">Name of the service.</param>
    /// <param name="category">The category.</param>
    /// <param name="type">The type.</param>
    /// <param name="lockKey">The lock key.</param>
    /// <param name="attemptCount">The attempt count.</param>
    /// <returns>ServiceResponse.</returns>
    /// <exception cref="ServiceRequestInvalidAuthorizationException"></exception>
    private ServiceResponse ServiceInvokerInternal(
        ServiceRequest request,
        ServiceModule module,
        ServiceName name,
        ServiceCategory category,
        ServiceType type,
        string lockKey,
        ref int attemptCount
    )
    {
        var serviceNameReadable = name.GetHumanReadableValue()
            .RemoveSpaces()
            .ReplaceNonAlphanumeric(string.Empty);

        Interlocked.Increment(ref _requestCount);

        var wait = 0;

        var currentLock = Locks.GetOrAdd(lockKey, _ => new());

        Monitor.Enter(currentLock);

        if (category == ServiceCategory.Crud && request != null)
        {
            LogConsumer.Trace(
                Resources.SankhyaWrapper_ServiceInvokerInternal_Service,
                name.GetHumanReadableValue(),
                request.RequestBody.Entity?.Name
                    ?? request.RequestBody.Entity?.RootEntity
                    ?? request.RequestBody.DataSet.RootEntity,
                ++attemptCount
            );
        }
        else
        {
            LogConsumer.Trace(
                Resources.SankhyaWrapper_ServiceInvokerInternal_Module,
                module.GetHumanReadableValue(),
                name.GetHumanReadableValue(),
                ++attemptCount
            );
        }

        try
        {
            if (string.IsNullOrWhiteSpace(_sessionId) && name != ServiceName.Login)
            {
                throw new ServiceRequestInvalidAuthorizationException();
            }

            return ProcessRequest(name, request, module, _requestCount, serviceNameReadable);
        }
        catch (Exception e)
        {
            if (!HandleException(e, name, category, type, request, attemptCount, ref wait))
            {
                throw;
            }
        }
        finally
        {
            if (wait > 0)
            {
                Thread.Sleep(new TimeSpan(0, 0, wait));
            }

            Monitor.Exit(currentLock);
        }

        return null;
    }

    /// <summary>
    /// Handles the exception.
    /// </summary>
    /// <param name="e">The e.</param>
    /// <param name="name">The name.</param>
    /// <param name="category">The category.</param>
    /// <param name="type">The type.</param>
    /// <param name="request">The request.</param>
    /// <param name="attemptCount">The attempt count.</param>
    /// <param name="wait">The wait.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool HandleException(
        Exception e,
        ServiceName name,
        ServiceCategory category,
        ServiceType type,
        ServiceRequest request,
        int attemptCount,
        ref int wait
    )
    {
        if (attemptCount > 3)
        {
            return false;
        }

        if (
            type == ServiceType.Transactional
            && (
                e is ServiceRequestCompetitionException
                || e is ServiceRequestDeadlockException
                || e is ServiceRequestTimeoutException
            )
        )
        {
            return false;
        }

        switch (e)
        {
            case ServiceRequestInvalidAuthorizationException _:

                if (
                    InvalidSessionIds.Exists(
                        sessionId =>
                            sessionId.Equals(
                                _sessionId,
                                StringComparison.InvariantCultureIgnoreCase
                            )
                    )
                )
                {
                    return false;
                }

                if (name != ServiceName.Logout)
                {
                    Invalidate();
                }

                Authenticate(_username, _password);

                return true;

            case ServiceRequestPropertyValueException ex:

                var xmlRequest = (string)request.GetSerializer();

                if (
                    xmlRequest.IndexOf(ex.PropertyName, StringComparison.InvariantCultureIgnoreCase)
                    != -1
                )
                {
                    return false;
                }

                LogConsumer.Trace(e);

                wait = attemptCount * 15;

                return true;

            case ServiceRequestCompetitionException _:

                Invalidate();

                Authenticate(_username, _password);

                return true;

            case ServiceRequestDeadlockException _:

                LogConsumer.Trace(e);

                wait = attemptCount * 15;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    wait,
                    @"Deadlock"
                );

                return true;

            case ServiceRequestTimeoutException _:

                LogConsumer.Trace(e);

                wait = attemptCount * 10;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    wait,
                    @"Timeout"
                );

                return true;

            case ServiceRequestInaccessibleException _:

                if (category != ServiceCategory.Authorization)
                {
                    Invalidate();

                    Authenticate(_username, _password);

                    return true;
                }

                LogConsumer.Trace(e);

                wait = attemptCount * 90;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    wait,
                    @"Sankhya unavailable"
                );

                return true;

            case ServiceRequestUnavailableException _:

                LogConsumer.Trace(e);

                wait = attemptCount * 30;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    wait,
                    @"Database unavailable"
                );

                return true;

            case ServiceRequestCanceledQueryException _:

                LogConsumer.Trace(e);

                wait = attemptCount * 15;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_CanceledQuery,
                    wait
                );

                return true;

            default:

                return false;
        }
    }

    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="request">The request.</param>
    /// <param name="module">The module.</param>
    /// <param name="currentRequestCount">The current request count.</param>
    /// <param name="serviceName">Name of the service.</param>
    /// <returns>ServiceResponse.</returns>
    /// <exception cref="ServiceRequestInaccessibleException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ServiceRequestInvalidAuthorizationException"></exception>
    private ServiceResponse ProcessRequest(
        ServiceName service,
        ServiceRequest request,
        ServiceModule module,
        int currentRequestCount,
        string serviceName
    )
    {
        if (request != null)
        {
            LogConsumer.Debug(request, $"Sankhya-{currentRequestCount}-{serviceName}-Request.xml");
        }

        var webRequest = WebRequestFactory(service, module);

        HttpWebResponse webResponse = null;

        try
        {
            webResponse =
                request == null
                    ? ServiceInvokerInternal(webRequest)
                    : ServiceInvokerInternal(webRequest, (string)request.GetSerializer());

            return ProcessResponse(service, request, webResponse, currentRequestCount, serviceName);
        }
        catch (WebException e)
        {
            throw HandleWebException(request, e);
        }
        finally
        {
            webResponse?.Dispose();
        }
    }

    /// <summary>
    /// Handles the web exception.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="e">The e.</param>
    /// <returns>Exception.</returns>
    /// <exception cref="ServiceRequestInaccessibleException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ServiceRequestInvalidAuthorizationException"></exception>
    private Exception HandleWebException(ServiceRequest request, WebException e)
    {
        if (
            e.Response
            is not HttpWebResponse { StatusCode: HttpStatusCode.InternalServerError } webResponse
        )
        {
            return new ServiceRequestInaccessibleException(_host, _port, request, e);
        }

        using (var responseStream = webResponse.GetResponseStream())
        {
            if (responseStream == null)
            {
                return new InvalidOperationException(Resources.ResponseStreamIsNull, e);
            }

            using var streamReader = new StreamReader(responseStream);
            if (
                streamReader
                    .ReadToEnd()
                    .IndexOf(
                        SankhyaConstants.SessionManagerNotStarted,
                        StringComparison.InvariantCultureIgnoreCase
                    ) != -1
            )
            {
                return new ServiceRequestInvalidAuthorizationException(e);
            }
        }

        return new ServiceRequestInaccessibleException(_host, _port, request, e);
    }

    /// <summary>
    /// Process the response.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="request">The request.</param>
    /// <param name="webResponse">The web response.</param>
    /// <param name="currentRequestCount">The current request count.</param>
    /// <param name="serviceName">Name of the service.</param>
    /// <returns>ServiceResponse.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    private static ServiceResponse ProcessResponse(
        ServiceName service,
        ServiceRequest request,
        WebResponse webResponse,
        int currentRequestCount,
        string serviceName
    )
    {
        using var responseStream = webResponse.GetResponseStream();

        if (responseStream == null)
        {
            throw new InvalidOperationException(Resources.ResponseStreamIsNull);
        }

        var response = SerializerFactory
            .GetSerializer<ServiceResponse>()
            .DeserializeFromStream(responseStream);

        if (response != null)
        {
            LogConsumer.Debug(
                response,
                $"Sankhya-{currentRequestCount}-{serviceName}-Response.xml"
            );
        }

        if (response?.StatusMessage == null)
        {
            return response;
        }

        StatusMessageHelper.ProcessStatusMessage(service, request, response);

        return null;
    }

    /// <summary>
    /// Services the invoker.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>ServiceResponse.</returns>
    public ServiceResponse ServiceInvoker(ServiceRequest request) =>
        ServiceInvoker(request.Service, request);

    /// <summary>
    /// service invoker as an asynchronous operation.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;ServiceResponse&gt;.</returns>
    //TODO issue #67
    public async Task<ServiceResponse> ServiceInvokerAsync(ServiceRequest request)
    {
        try
        {
            return await Task.Run(() => ServiceInvoker(request.Service, request))
                .ConfigureAwait(false);
        }
        catch (AggregateException e)
        {
            throw e.Flatten();
        }
    }

    /// <summary>
    /// Gets the file internal.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>ServiceFile.</returns>
    private ServiceFile GetFileInternal(string key)
    {
        try
        {
            var request = GenericWebRequestFactory(
                "mge/visualizadorArquivos.mge",
                new() { { @"chaveArquivo", key } }
            );
            request.Method = @"GET";
            request.Headers.Add(@"Accept-Charset", @"UTF-8;q=0.9,*;q=0.7");
            return ProcessFileResponse(key, request);
        }
        catch (Exception e)
        {
            LogConsumer.Handle(e);
        }

        return new();
    }

    /// <summary>
    /// Processes the file response.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="request">The request.</param>
    /// <returns>ServiceFile.</returns>
    /// <exception cref="OpenFileException"></exception>
    /// <exception cref="InvalidKeyFileException"></exception>
    private static ServiceFile ProcessFileResponse(string key, HttpWebRequest request)
    {
        var result = new ServiceFile();

        var response = (HttpWebResponse)request.GetResponse();

        result.ContentType = response.ContentType;

        var contentDispositionHeader = response.Headers[@"Content-Disposition"];

        if (!string.IsNullOrWhiteSpace(contentDispositionHeader))
        {
            result.FileName = new ContentDisposition(
                contentDispositionHeader.RemoveDiacritics()
            ).FileName;
        }

        if (!string.IsNullOrWhiteSpace(result.FileName))
        {
            result.FileExtension = result.FileName.GetFileExtension().Replace(@".", string.Empty);
        }

        if (
            string.IsNullOrWhiteSpace(result.FileExtension)
            && !string.IsNullOrWhiteSpace(result.ContentType)
            && MimeTypes2Extensions.ContainsKey(result.ContentType)
        )
        {
            result.FileExtension = MimeTypes2Extensions[result.ContentType];
        }

        ReadStream(key, response, result);

        if (!result.ContentType.StartsWith(@"text/html", StringComparison.InvariantCulture))
        {
            return result;
        }

        var message = Encoding.GetEncoding("ISO-8859-1").GetString(result.Data);
        if (
            message.IndexOf(
                SankhyaConstants.FileNotFoundOnServer,
                StringComparison.InvariantCultureIgnoreCase
            ) != -1
        )
        {
            throw new InvalidKeyFileException(key);
        }

        return result;
    }

    /// <summary>
    /// Reads the stream.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="response">The response.</param>
    /// <param name="result">The result.</param>
    /// <exception cref="OpenFileException"></exception>
    private static void ReadStream(string key, HttpWebResponse response, ServiceFile result)
    {
        var stream = response.GetResponseStream();

        var buffer = new byte[32768];

        using var memory = new MemoryStream();

        int bytesRead;

        while (stream != null && (bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            memory.Write(buffer, 0, bytesRead);
        }

        stream?.Close();

        if (memory.Length == 0)
        {
            throw new OpenFileException(key);
        }

        var data = new byte[memory.Length];

        memory.Seek(0, SeekOrigin.Begin);

        var read = memory.Read(data, 0, data.Length);

        if (read == 0)
        {
            throw new InvalidOperationException(Resources.SankhyaWrapper_ReadStream_Exception);
        }

        result.Data = data;
    }

    #endregion

    #region Authentication

    /// <summary>
    /// Authenticates this instance with the specified user name and password pair.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="password">The password.</param>
    public void Authenticate(string userName, string password)
    {
        _username = userName;
        _password = password;

        if (!string.IsNullOrWhiteSpace(_sessionId))
        {
            return;
        }

        LogConsumer.Info(Resources.SankhyaWrapper_Authenticate_Authentication, userName);

        #region Service Request

        var request = new ServiceRequest(ServiceName.Login)
        {
            RequestBody = { Username = userName, Password = password }
        };

        #endregion

        #region Service Response

        var response = ServiceInvoker(request);
        if (response == null)
        {
            return;
        }

        _sessionId = response.ResponseBody.JSessionId;
        UserCode = response.ResponseBody.CodeUser;

        #endregion
    }

    /// <summary>
    /// Invalidates this instance.
    /// </summary>
    private void Invalidate()
    {
        if (string.IsNullOrWhiteSpace(_sessionId))
        {
            return;
        }

        ServiceInvoker(ServiceName.Logout);
        InvalidSessionIds.Add(_sessionId);
        _sessionId = string.Empty;
    }

    /// <summary>
    /// Creates the request.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="cookieContainer">The cookie container.</param>
    /// <param name="requestType">Type of the request.</param>
    /// <param name="method">The method.</param>
    /// <returns>HttpWebRequest.</returns>
    private static HttpWebRequest CreateRequest(
        Uri uri,
        CookieContainer cookieContainer,
        string requestType,
        [Localizable(false)] string method
    )
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.CookieContainer = cookieContainer;
        request.UserAgent = $@"{EnvironmentHelper.UserAgent} ({InternalUserAgent}+{requestType})";
        request.ContentType = "text/plain;charset=UTF-8";
        if (!string.IsNullOrWhiteSpace(method))
        {
            request.Method = method;
        }

        return request;
    }

    /// <summary>
    /// Registers the user agent.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="port">The port.</param>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <param name="cookieContainer">The cookie container.</param>
    /// <param name="requestType">Type of the request.</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ServiceRequestInaccessibleException">null</exception>
    private static void RegisterUserAgent(
        string host,
        int port,
        string username,
        string password,
        CookieContainer cookieContainer,
        string requestType
    )
    {
        var uriCookie = new UriBuilder("http", host, port, "/mge/");
        var uriDwr = new UriBuilder("http", host, port, "/mge/dwr/exec/DWRController.execute.dwr");

        var webRequestCookie = CreateRequest(
            uriCookie.Uri,
            cookieContainer,
            requestType,
            string.Empty
        );
        var webRequestDwr = CreateRequest(uriDwr.Uri, cookieContainer, requestType, "POST");

        try
        {
            using var webResponseCookie = (HttpWebResponse)webRequestCookie.GetResponse();

            using var responseStream = webResponseCookie.GetResponseStream();

            if (responseStream == null)
            {
                throw new InvalidOperationException(Resources.ResponseStreamIsNull);
            }

            using var responseReader = new StreamReader(responseStream);
            ShowVersionInfo(responseReader, requestType);

            webResponseCookie.Close();

            var bytes = GetRegisterUserAgentRequestBytes(username, password);

            using var requestStream = webRequestDwr.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Flush();
            requestStream.Close();

            using var webResponseDwr = (HttpWebResponse)webRequestDwr.GetResponse();

            webResponseDwr.Close();
        }
        catch (WebException e)
        {
            throw new ServiceRequestInaccessibleException(host, port, null, e);
        }
    }

    /// <summary>
    /// Gets the register user agent request bytes.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>System.Byte[].</returns>
    private static byte[] GetRegisterUserAgentRequestBytes(string username, string password)
    {
        var sb = new StringBuilder();

        sb.AppendLine(@"callCount=1")
            .AppendLine(@"c0-scriptName=DWRController")
            .AppendLine(@"c0-methodName=execute")
            .Append(@"c0-id=")
            .AppendLine(EnvironmentHelper.ProcessId.ToString(CultureInfo.InvariantCulture))
            .AppendLine(@"c0-e1=string:login")
            .Append(@"c0-e2=string:")
            .AppendLine(username)
            .Append(@"c0-e3=string:")
            .AppendLine(password)
            .AppendLine(
                @"c0-param0=Object:{acao:reference:c0-e1, nomeUsu:reference:c0-e2, passUsu:reference:c0-e3}"
            )
            .AppendLine(@"xml=true");

        var bytes = Encoding.UTF8.GetBytes(sb.ToString());
        return bytes;
    }

    /// <summary>
    /// Shows the version information about Sankhya-W application.
    /// </summary>
    /// <param name="responseReader">The response reader.</param>
    /// <param name="requestType">Type of the request.</param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void ShowVersionInfo(TextReader responseReader, string requestType)
    {
        if (
            !requestType.Equals(
                ServiceRequestType.Default.GetHumanReadableValue(),
                StringComparison.InvariantCultureIgnoreCase
            )
        )
        {
            return;
        }

        var html = responseReader.ReadToEnd();
        var stableVersionPattern = new Regex(
            "SYSVERSION = \\\"(?<version>([0-9b].?)+)\\\"",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline
        );
        var betaVersionPattern = new Regex(
            "SYSVERSION = \\\"desenvolvimentob(?<version>([0-9])+)\\\"",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline
        );
        if (!stableVersionPattern.IsMatch(html) && !betaVersionPattern.IsMatch(html))
        {
            throw new InvalidOperationException(
                Resources.SankhyaWrapper_ShowVersionInfo_SankhyaWVersionNotFound
            );
        }

        var version = stableVersionPattern.IsMatch(html)
            ? Version
                .Parse(
                    stableVersionPattern.Match(html).Groups[@"version"].Value.Replace(@"b", @".")
                )
                .ToString()
            : $@"[BETA] {betaVersionPattern.Match(html).Groups[@"version"].Value}";

        LogConsumer.Info(Resources.SankhyaWrapper_ShowVersionInfo_SankhyaWVersion, version);
    }

    #endregion

    #region File Manager

    /// <summary>
    /// Get a file based on it's key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>ServiceFile.</returns>
    public ServiceFile GetFile(string key)
    {
        LogConsumer.Info(Resources.SankhyaWrapper_GetFile_Getting, key);
        return GetFileInternal(key);
    }

    /// <summary>
    /// Get a file as an asynchronous operation based on it's key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>Task&lt;Tuple&lt;String, Byte[]&gt;&gt;.</returns>
    //TODO issue #67
    public async Task<ServiceFile> GetFileAsync(string key)
    {
        try
        {
            return await Task.Run(() => GetFile(key)).ConfigureAwait(false);
        }
        catch (AggregateException e)
        {
            throw e.Flatten();
        }
    }

    /// <summary>
    /// Creates the web request.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="cookieContainer">The cookie container.</param>
    /// <returns>HttpWebRequest.</returns>
    private static HttpWebRequest CreateWebRequest(Uri uri, CookieContainer cookieContainer)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.CookieContainer = cookieContainer;
        request.Method = @"GET";
        request.UserAgent = EnvironmentHelper.UserAgent;
        return request;
    }

    /// <summary>
    /// Reads the stream and get extension.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="extension">The extension.</param>
    /// <returns>MemoryStream.</returns>
    private static MemoryStream ReadStreamAndGetExtension(
        HttpWebResponse response,
        out string extension
    )
    {
        extension = @"jpg";

        using var stream = response.GetResponseStream();

        if (MimeTypes2Extensions.ContainsKey(response.ContentType))
        {
            extension = MimeTypes2Extensions[response.ContentType];
        }

        var memory = new MemoryStream();

        var buffer = new byte[32768];

        int bytesRead;

        while (stream != null && (bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            memory.Write(buffer, 0, bytesRead);
        }

        stream?.Close();

        return memory;
    }

    /// <summary>
    /// Gets the image.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <param name="keys">The keys.</param>
    /// <returns>ServiceImage.</returns>
    /// <exception cref="WebException"></exception>
    public ServiceFile GetImage(string entity, Dictionary<string, object> keys)
    {
        HttpWebResponse response = null;
        try
        {
            LogConsumer.Info(
                Resources.SankhyaWrapper_GetImage_Getting,
                entity,
                string.Join(@" | ", keys.Select(k => $@"{k.Key}->{k.Value}"))
            );

            var imageKeys = string.Concat(keys.Select(k => $@"@{k.Key}={k.Value}"));

            var url = $@"http://{_host}:{_port}/mge/{entity}@IMAGEM{imageKeys}.dbimage";

            var cookies = new CookieContainer();

            if (!string.IsNullOrWhiteSpace(_sessionId))
            {
                cookies.Add(
                    new($"http://{_host}"),
                    new Cookie(SankhyaConstants.SessionIdCookieName, _sessionId)
                );
            }

            var request = CreateWebRequest(new(url), cookies);

            response = (HttpWebResponse)request.GetResponse();

            using var memory = ReadStreamAndGetExtension(response, out var extension);

            if (memory.Length == 0)
            {
                throw new WebException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.SankhyaWrapper_GetImage_ImageNotFound,
                        url
                    ),
                    WebExceptionStatus.PipelineFailure
                );
            }

            var data = new byte[memory.Length];

            memory.Seek(0, SeekOrigin.Begin);

            var read = memory.Read(data, 0, data.Length);

            if (read == 0)
            {
                throw new InvalidOperationException(Resources.SankhyaWrapper_ReadStream_Exception);
            }

            return new()
            {
                ContentType = response.ContentType,
                Data = data,
                FileExtension = extension
            };
        }
        catch (WebException e)
        {
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                response = e.Response as HttpWebResponse;
                if (response is { StatusCode: HttpStatusCode.NotFound })
                {
                    return null;
                }
            }

            LogConsumer.Handle(e);

            return null;
        }
        finally
        {
            response?.Close();
        }
    }

    /// <summary>
    /// get image as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <param name="keys">The keys.</param>
    /// <returns>Task&lt;ServiceImage&gt;.</returns>
    //TODO issue #67
    public async Task<ServiceFile> GetImageAsync(string entity, Dictionary<string, object> keys)
    {
        try
        {
            return await Task.Run(() => GetImage(entity, keys)).ConfigureAwait(false);
        }
        catch (AggregateException e)
        {
            throw e.Flatten();
        }
    }

    #endregion
}
