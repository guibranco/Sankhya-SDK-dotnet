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
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Properties;
using Sankhya.RequestHelpers;
using Sankhya.Service;
using Sankhya.ValueObjects;

namespace Sankhya;

internal class SankhyaWrapper
{
    private static readonly ConcurrentDictionary<string, object> Locks = new();

    private bool _disposed;

    private string _sessionId;

    private string _username;

    private string _password;

    private readonly string _host;

    private readonly int _port;

    private readonly string _requestType;

    private static int _requestCount;

    private static string _internalUserAgent;

    private static readonly List<string> InvalidSessionIds = new();

    private static string InternalUserAgent
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(_internalUserAgent))
            {
                return _internalUserAgent;
            }

            var assembly = Assembly.GetAssembly(typeof(SankhyaWrapper))?.GetName();
            _internalUserAgent =
                $@"{assembly?.Name ?? "Sankhya.SDK.dotNET"}/{assembly?.Version ?? new Version(1, 0)}";
            return _internalUserAgent;
        }
    }

    private static readonly Dictionary<string, string> MimeTypes2Extensions = new()
    {
        { @"image/jpeg", @"jpg" },
        { @"image/png", @"png" },
        { @"image/gif", @"gif" },
    };

    public SankhyaWrapper(string host, int port, ServiceRequestType requestType)
    {
        UserCode = -1;
        _host = Regex.Replace(
            host,
            "^https?://",
            string.Empty,
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
            TimeSpan.FromMinutes(1)
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
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
            TimeSpan.FromMinutes(1)
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
            _ => throw new ArgumentOutOfRangeException(nameof(environment), environment, null),
        };
    }

    ~SankhyaWrapper() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

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

    public ServiceEnvironment Environment { get; }

    public string DatabaseName { get; }

    public int UserCode { get; private set; }

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

    [Localizable(false)]
    private HttpWebRequest WebRequestFactory(ServiceName service, ServiceModule module)
    {
        var request = GenericWebRequestFactory(
            $"{module.GetInternalValue()}/service.sbr",
            new() { { "serviceName", service.GetInternalValue() } }
        );
        request.Method = "POST";
        request.ContentType = "text/xml;charset=UTF-8";
        return request;
    }

    [Localizable(false)]
    private static HttpWebResponse ServiceInvokerInternal(WebRequest connection, string body = null)
    {
        if (body == null)
        {
            return (HttpWebResponse)connection.GetResponse();
        }

#if NETSTANDARD2_0
        var xmlStarted = body.IndexOf("<?xml version=", StringComparison.OrdinalIgnoreCase) >= 0;
#elif NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        var xmlStarted = body.Contains("<?xml version=", StringComparison.OrdinalIgnoreCase);
#endif

        if (!xmlStarted)
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

    private ServiceResponse ServiceInvoker(ServiceName serviceName, ServiceRequest request = null)
    {
        var lockKey = string.IsNullOrWhiteSpace(_sessionId) ? nameof(ServiceInvoker) : _sessionId;
        var retryData = new RequestRetryData { LockKey = lockKey };
        ServiceResponse result;
        while (true)
        {
            result = ServiceInvokerInternal(request, serviceName, retryData);
            if (result != null)
            {
                break;
            }
        }

        return result;
    }

    private ServiceResponse ServiceInvokerInternal(
        ServiceRequest request,
        ServiceName serviceName,
        RequestRetryData retryData
    )
    {
        var service = serviceName.GetService();
        var serviceNameLogs = serviceName.GetHumanReadableValue();
        var serviceNameReadable = serviceNameLogs
            .RemoveSpaces()
            .ReplaceNonAlphanumeric(string.Empty);

        Interlocked.Increment(ref _requestCount);

        retryData.RetryDelay = 0;

        var currentLock = Locks.GetOrAdd(retryData.LockKey, _ => new());

        Monitor.Enter(currentLock);

        retryData.RetryCount++;
        if (service.Category == ServiceCategory.Crud && request != null)
        {
            var requestName =
                request.RequestBody.Entity?.Name
                ?? request.RequestBody.Entity?.RootEntity
                ?? request.RequestBody.DataSet.RootEntity;
            LogConsumer.Trace(
                Resources.SankhyaWrapper_ServiceInvokerInternal_Service,
                serviceNameLogs,
                requestName,
                retryData.RetryCount
            );
        }
        else
        {
            LogConsumer.Trace(
                Resources.SankhyaWrapper_ServiceInvokerInternal_Module,
                service.Module.GetHumanReadableValue(),
                serviceNameLogs,
                retryData.RetryCount
            );
        }

        try
        {
            if (string.IsNullOrWhiteSpace(_sessionId) && serviceName != ServiceName.Login)
            {
                throw new ServiceRequestInvalidAuthorizationException();
            }

            return ProcessRequest(
                serviceName,
                request,
                service.Module,
                _requestCount,
                serviceNameReadable
            );
        }
        catch (Exception exception)
        {
            if (!HandleException(exception, serviceName, service, request, retryData))
            {
                throw;
            }
        }
        finally
        {
            if (retryData.RetryDelay > 0)
            {
                Thread.Sleep(new TimeSpan(0, 0, retryData.RetryDelay));
            }

            Monitor.Exit(currentLock);
        }

        return null;
    }

    private bool HandleException(
        Exception exception,
        ServiceName name,
        ServiceAttribute service,
        ServiceRequest request,
        RequestRetryData retryData
    )
    {
        if (retryData.RetryCount > 3)
        {
            return false;
        }

        if (
            service.Type == ServiceType.Transactional
            && exception
                is ServiceRequestCompetitionException
                    or ServiceRequestDeadlockException
                    or ServiceRequestTimeoutException
        )
        {
            return false;
        }

        return HandleExceptionInternal(exception, name, service.Category, request, retryData);
    }

    private bool HandleExceptionInternal(
        Exception exception,
        ServiceName name,
        ServiceCategory category,
        ServiceRequest request,
        RequestRetryData retryData
    )
    {
        switch (exception)
        {
            case ServiceRequestInvalidAuthorizationException _:

                if (
                    InvalidSessionIds.Exists(sessionId =>
                        sessionId.Equals(_sessionId, StringComparison.OrdinalIgnoreCase)
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

                if (xmlRequest.IndexOf(ex.PropertyName, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    return false;
                }

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Stable;

                return true;

            case ServiceRequestCompetitionException _:

                Invalidate();

                Authenticate(_username, _password);

                return true;

            case ServiceRequestDeadlockException _:

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Stable;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    retryData.RetryDelay,
                    @"Deadlock"
                );

                return true;

            case ServiceRequestTimeoutException _:

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Free;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    retryData.RetryDelay,
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

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Breakdown;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    retryData.RetryDelay,
                    @"Sankhya unavailable"
                );

                return true;

            case ServiceRequestUnavailableException _:

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Unstable;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_ReasonIdentifiedTakingSecondsRetry,
                    retryData.RetryDelay,
                    @"Database unavailable"
                );

                return true;

            case ServiceRequestCanceledQueryException _:

                LogConsumer.Trace(exception);

                retryData.RetryDelay = retryData.RetryCount * RequestRetryDelay.Stable;

                LogConsumer.Warning(
                    Resources.SankhyaWrapper_ServiceInvokerInternal_CanceledQuery,
                    retryData.RetryDelay
                );

                return true;

            default:

                return false;
        }
    }

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
        if (service == ServiceName.Login)
        {
            RegisterUserAgent(
                _host,
                _port,
                _username,
                _password,
                webRequest.CookieContainer,
                _requestType
            );
        }

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
#if NETSTANDARD2_0 || NETSTANDARD2_1
            if (responseStream == null)
            {
                return new ServiceRequestInaccessibleException(_host, _port, request, e);
            }
#endif

            using var streamReader = new StreamReader(responseStream);
            if (
                streamReader
                    .ReadToEnd()
                    .IndexOf(
                        SankhyaConstants.SessionManagerNotStarted,
                        StringComparison.OrdinalIgnoreCase
                    ) != -1
            )
            {
                return new ServiceRequestInvalidAuthorizationException(e);
            }
        }

        return new ServiceRequestInaccessibleException(_host, _port, request, e);
    }

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

    public ServiceResponse ServiceInvoker(ServiceRequest request) =>
        ServiceInvoker(request.Service, request);

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
            && MimeTypes2Extensions.TryGetValue(result.ContentType, out var extension)
        )
        {
            result.FileExtension = extension;
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
                StringComparison.OrdinalIgnoreCase
            ) != -1
        )
        {
            throw new InvalidKeyFileException(key);
        }

        return result;
    }

    private static void ReadStream(string key, HttpWebResponse response, ServiceFile result)
    {
        var stream = response.GetResponseStream();

#if NETSTANDARD2_0 || NETSTANDARD2_1
        if (stream == null)
        {
            throw new InvalidOperationException(Resources.ResponseStreamIsNull);
        }
#endif

        using var memory = new MemoryStream();
        stream.CopyTo(memory);

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

    public void Authenticate(string userName, string password)
    {
        _username = userName;
        _password = password;

        if (!string.IsNullOrWhiteSpace(_sessionId))
        {
            return;
        }

        LogConsumer.Info(Resources.SankhyaWrapper_Authenticate_Authentication, userName);

        var request = new ServiceRequest(ServiceName.Login)
        {
            RequestBody = { Username = userName, Password = password },
        };

        var response = ServiceInvoker(request);
        if (response == null)
        {
            return;
        }

        _sessionId = response.ResponseBody.JSessionId;
        UserCode = response.ResponseBody.CodeUser;
    }

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

    private static void ShowVersionInfo(TextReader responseReader, string requestType)
    {
        if (
            !requestType.Equals(
                ServiceRequestType.Default.GetHumanReadableValue(),
                StringComparison.OrdinalIgnoreCase
            )
        )
        {
            return;
        }

        var html = responseReader.ReadToEnd();
        var stableVersionPattern = new Regex(
            "SYSVERSION = \\\"(?<version>([0-9b].?)+)\\\"",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline,
            TimeSpan.FromMinutes(1)
        );
        var betaVersionPattern = new Regex(
            "SYSVERSION = \\\"desenvolvimentob(?<version>([0-9])+)\\\"",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Multiline,
            TimeSpan.FromMinutes(1)
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

    public ServiceFile GetFile(string key)
    {
        LogConsumer.Info(Resources.SankhyaWrapper_GetFile_Getting, key);
        return GetFileInternal(key);
    }

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

    private static HttpWebRequest CreateWebRequest(Uri uri, CookieContainer cookieContainer)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.CookieContainer = cookieContainer;
        request.Method = @"GET";
        request.UserAgent = EnvironmentHelper.UserAgent;
        return request;
    }

    private static MemoryStream ReadStreamAndGetExtension(
        HttpWebResponse response,
        out string extension
    )
    {
#if NETSTANDARD2_0
        if (!MimeTypes2Extensions.TryGetValue(response.ContentType, out extension))
        {
            extension = @"jpg";
        }
#else
        extension = MimeTypes2Extensions.GetValueOrDefault(response.ContentType, @"jpg");
#endif

        using var stream = response.GetResponseStream();
#if NETSTANDARD2_0 || NETSTANDARD2_1
        if (stream == null)
        {
            throw new InvalidOperationException(Resources.ResponseStreamIsNull);
        }
#endif

        var memory = new MemoryStream();
        stream.CopyTo(memory);

        return memory;
    }

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
                FileExtension = extension,
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
}
