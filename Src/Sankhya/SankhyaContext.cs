using System.Collections.Concurrent;
using CrispyWaffle.Configuration;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.RequestWrappers;
using Sankhya.Service;
using Sankhya.ValueObjects;

namespace Sankhya;

/// <summary>
/// A SankhyaContext instance is a generic Unit of Work pattern for consuming Sankhya web service.
/// Each instance is assigned for a single Sankhya host/environment and user only.
/// Basically it's allow us to check if a combination of username/password are valid,
/// make service's requests, get files (from Sankhya File Repository) and images from entities.
/// It's also have support for async service requests.
/// Internally it uses a instance of <seealso cref="SankhyaWrapper" /> class.
/// </summary>
[ConnectionName("Sankhya")]
public sealed class SankhyaContext
{
    /// <summary>
    /// The wrappers
    /// </summary>
    private static readonly ConcurrentDictionary<Guid, SankhyaWrapper> Wrappers = new();

    /// <summary>
    /// The connection
    /// </summary>
    private readonly IConnection _connection;

    /// <summary>
    /// The on demand request wrappers attached tokens
    /// </summary>
    private readonly ConcurrentBag<Guid> _onDemandRequestWrappersAttachedTokens;

    /// <summary>
    /// The disposed
    /// </summary>
    private bool _disposed;

    /// <summary>
    /// The current logged in username.
    /// </summary>
    /// <value>The name of the user.</value>

    public string UserName => _connection.Credentials.UserName;

    /// <summary>
    /// The current context token.
    /// </summary>
    /// <value>The token.</value>

    public Guid Token { get; }

    /// <summary>
    /// The current internal wrapper's authenticated user code
    /// </summary>
    /// <value>The user code.</value>
    /// <remarks>This will always return a value,
    /// but the value is valid only if wrapper is authenticated
    /// in the Sankhya WebService.</remarks>

    public int UserCode => GetWrapper(Token).UserCode;

    /// <summary>
    /// The current internal wrapper's connected environment.
    /// </summary>
    /// <value>The environment.</value>
    public ServiceEnvironment Environment => GetWrapper(Token).Environment;

    /// <summary>
    /// Gets the name of the database.
    /// </summary>
    /// <value>The name of the database.</value>
    public string DatabaseName => GetWrapper(Token).DatabaseName;

    /// <summary>
    /// Initializes a new instance of SankhyaContext class.
    /// </summary>
    /// <param name="connection"><see cref="IConnection"/></param>
    public SankhyaContext(IConnection connection)
    {
        _connection = connection;
        Token = AcquireNewSession(ServiceRequestType.Default);
        _onDemandRequestWrappersAttachedTokens = new();
    }

    /// <summary>
    /// Initializes a new instance of SankhyaContext class.
    /// </summary>
    /// <param name="host">The Sankhya WebService's host (AKA JBOSS server hostname/ip address)</param>
    /// <param name="port">THe Sankhya JBOSS port (AKA Sankhya Environment - Production/Homologation/Training)</param>
    /// <param name="userName">The username to act on behalf's on Sankhya WS</param>
    /// <param name="password">The <paramref name="userName"></paramref> password's</param>
    public SankhyaContext(string host, int port, string userName, string password)
        : this(
            new Connection
            {
                Credentials = new Credentials { Password = password, UserName = userName },
                Host = host,
                Port = port
            }
        ) { }

    /// <summary>
    /// Finalizes an instance of the <see cref="SankhyaContext" /> class.
    /// </summary>
    ~SankhyaContext() => Dispose(false);

    /// <summary>
    /// Gets the wrapper associated with <paramref name="token" />
    /// </summary>
    /// <param name="token">The token identifying the wrapper</param>
    /// <returns>A instance of <seealso cref="SankhyaWrapper" /></returns>
    private static SankhyaWrapper GetWrapper(Guid token)
    {
        if (!Wrappers.ContainsKey(token))
        {
            return null;
        }

        while (true)
        {
            if (Wrappers.TryGetValue(token, out var wrapper))
            {
                return wrapper;
            }
        }
    }

    /// <summary>
    /// Acquires a new session in Sankhya platform
    /// </summary>
    /// <param name="requestType">Type of the request.</param>
    /// <returns>A token identifying the new session</returns>
    public Guid AcquireNewSession(ServiceRequestType requestType)
    {
        LogConsumer.Info(
            Resources.SankhyaContext_AcquireNewSession_NewSession,
            requestType.GetHumanReadableValue()
        );
        var wrapper = new SankhyaWrapper(_connection.Host, _connection.Port, requestType);
        wrapper.Authenticate(_connection.Credentials.UserName, _connection.Credentials.Password);
        var token = Guid.NewGuid();
        Wrappers.TryAdd(token, wrapper);
        if (requestType == ServiceRequestType.OnDemandCrud)
        {
            _onDemandRequestWrappersAttachedTokens.Add(token);
        }

        LogConsumer.Trace(
            Resources.SankhyaContext_AcquireNewSession_NewSessionStarted,
            requestType.GetHumanReadableValue(),
            token
        );
        return token;
    }

    /// <summary>
    /// Finalizes a session acquired by <seealso cref="AcquireNewSession" /> method.
    /// </summary>
    /// <param name="token">The token identifying the session to finalize</param>
    public void FinalizeSession(Guid token)
    {
        if (token == Token || !Wrappers.ContainsKey(token))
        {
            return;
        }

        LogConsumer.Trace(Resources.SankhyaContext_FinalizeSession_FinalizeSession, token);
        if (!Wrappers.TryRemove(token, out var wrapper))
        {
            return;
        }

        wrapper.Dispose();
    }

    /// <summary>
    /// Detaches the on demand request wrapper.
    /// </summary>
    /// <param name="token">The token.</param>
    public void DetachOnDemandRequestWrapper(Guid token)
    {
        FinalizeSession(token);
        _onDemandRequestWrappersAttachedTokens.TryTake(out var _);
    }

    /// <summary>
    /// Invoke a service request in Sankhya WS.
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>The service response instance</returns>
    public ServiceResponse ServiceInvoker(ServiceRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return GetWrapper(Token).ServiceInvoker(request);
    }

    /// <summary>
    /// Invoke a service request in Sankhya WS.
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="token">The token identifying the connection</param>
    /// <returns>The service response instance</returns>
    public ServiceResponse ServiceInvoker(ServiceRequest request, Guid token)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return GetWrapper(token).ServiceInvoker(request);
    }

    /// <summary>
    /// Invoice a service request in Sankhya WS asynchronous.
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>The service response instance</returns>
    public Task<ServiceResponse> ServiceInvokerAsync(ServiceRequest request) =>
        GetWrapper(Token).ServiceInvokerAsync(request);

    /// <summary>
    /// Invoice a service request in Sankhya WS asynchronous.
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="token">The token identifying the connection</param>
    /// <returns>The service response instance</returns>
    public Task<ServiceResponse> ServiceInvokerAsync(ServiceRequest request, Guid token) =>
        GetWrapper(token).ServiceInvokerAsync(request);

    /// <summary>
    /// Gets the file.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>ServiceFile.</returns>
    public ServiceFile GetFile(string key) => GetWrapper(Token).GetFile(key);

    /// <summary>
    /// Gets a file in the Sankhya File Repository based on file key
    /// </summary>
    /// <param name="key">The key of the file</param>
    /// <param name="token">The token.</param>
    /// <returns>A instance of ServiceFile with ContentType header and the file as a byte array.</returns>
    /// <remarks>This method returns a instance of ServiceFile with Data property with null if file is not found or any error occurs in the request.
    /// Errors are directly logged in LogConsumer
    /// No exception is throw by this method.</remarks>
    public ServiceFile GetFile(string key, Guid token) => GetWrapper(token).GetFile(key);

    /// <summary>
    /// Gets a file in the Sankhya File Repository as an asynchronous operation based on it's key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>Task&lt;ServiceFile&gt;.</returns>
    public Task<ServiceFile> GetFileAsync(string key) => GetWrapper(Token).GetFileAsync(key);

    /// <summary>
    /// Gets the file asynchronous.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="token">The token.</param>
    /// <returns>Task&lt;ServiceFile&gt;.</returns>
    public Task<ServiceFile> GetFileAsync(string key, Guid token) =>
        GetWrapper(token).GetFileAsync(key);

    /// <summary>
    /// Gets the image from a entity (database table) based on entity keys (row's primaries keys).
    /// </summary>
    /// <param name="entity">The entity name</param>
    /// <param name="keys">The key's names and it's values</param>
    /// <returns>The image and it's file extension based on content-type header as a <seealso cref="ServiceFile" /> instance</returns>
    /// <remarks>This method returns nulls if the image is not found or any error occurs in the request.
    /// Errors are directly logged in LogConsumer
    /// No exception is throw by this method.</remarks>
    public ServiceFile GetImage(string entity, Dictionary<string, object> keys) =>
        GetWrapper(Token).GetImage(entity, keys);

    /// <summary>
    /// Gets the image asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <param name="keys">The keys.</param>
    /// <returns>Task&lt;ServiceImage&gt;.</returns>
    public Task<ServiceFile> GetImageAsync(string entity, Dictionary<string, object> keys) =>
        GetWrapper(Token).GetImageAsync(entity, keys);

    /// <summary>
    /// Disposes this instance.
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

        _disposed = true;
        if (!disposing)
        {
            return;
        }

        LogConsumer.Trace(Resources.SankhyaContext_Dispose_DisposingServiceContext);
        if (!_onDemandRequestWrappersAttachedTokens.IsEmpty)
        {
            OnDemandRequestFactory.FinalizeAll();
        }

        while (Wrappers.Any())
        {
            foreach (var item in Wrappers)
            {
                if (Wrappers.TryRemove(item.Key, out var wrapper))
                {
                    wrapper.Dispose();
                }
            }
        }
    }
}
