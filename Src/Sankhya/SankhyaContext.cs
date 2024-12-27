using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrispyWaffle.Configuration;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using Sankhya.Enums;
using Sankhya.Properties;
using Sankhya.RequestWrappers;
using Sankhya.Service;
using Sankhya.ValueObjects;

namespace Sankhya;

[ConnectionName("Sankhya")]
public sealed class SankhyaContext
{
    private static readonly ConcurrentDictionary<Guid, SankhyaWrapper> Wrappers = new();

    private readonly IConnection _connection;

    private readonly ConcurrentBag<Guid> _onDemandRequestWrappersAttachedTokens;

    private bool _disposed;

    public string UserName => _connection.Credentials.Username;

    public Guid Token { get; }

    public int UserCode => GetWrapper(Token).UserCode;

    public ServiceEnvironment Environment => GetWrapper(Token).Environment;

    public string DatabaseName => GetWrapper(Token).DatabaseName;

    public SankhyaContext(IConnection connection)
    {
        _connection = connection;
        Token = AcquireNewSession(ServiceRequestType.Default);
        _onDemandRequestWrappersAttachedTokens = new();
    }

    public SankhyaContext(string host, int port, string username, string password)
        : this(
            new Connection
            {
                Credentials = new Credentials { Password = password, Username = username },
                Host = host,
                Port = port,
            }
        ) { }

    ~SankhyaContext() => Dispose(false);

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

    public Guid AcquireNewSession(ServiceRequestType requestType)
    {
        LogConsumer.Info(
            Resources.SankhyaContext_AcquireNewSession_NewSession,
            requestType.GetHumanReadableValue()
        );
        var wrapper = new SankhyaWrapper(_connection.Host, _connection.Port, requestType);
        wrapper.Authenticate(_connection.Credentials.Username, _connection.Credentials.Password);
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

    public void DetachOnDemandRequestWrapper(Guid token)
    {
        FinalizeSession(token);
        _onDemandRequestWrappersAttachedTokens.TryTake(out _);
    }

    public ServiceResponse ServiceInvoker(ServiceRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return GetWrapper(Token).ServiceInvoker(request);
    }

    public static ServiceResponse ServiceInvoker(ServiceRequest request, Guid token)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return GetWrapper(token).ServiceInvoker(request);
    }

    public Task<ServiceResponse> ServiceInvokerAsync(ServiceRequest request) =>
        GetWrapper(Token).ServiceInvokerAsync(request);

    public static Task<ServiceResponse> ServiceInvokerAsync(ServiceRequest request, Guid token) =>
        GetWrapper(token).ServiceInvokerAsync(request);

    public ServiceFile GetFile(string key) => GetWrapper(Token).GetFile(key);

    public static ServiceFile GetFile(string key, Guid token) => GetWrapper(token).GetFile(key);

    public Task<ServiceFile> GetFileAsync(string key) => GetWrapper(Token).GetFileAsync(key);

    public static Task<ServiceFile> GetFileAsync(string key, Guid token) =>
        GetWrapper(token).GetFileAsync(key);

    public ServiceFile GetImage(string entity, Dictionary<string, object> keys) =>
        GetWrapper(Token).GetImage(entity, keys);

    public Task<ServiceFile> GetImageAsync(string entity, Dictionary<string, object> keys) =>
        GetWrapper(Token).GetImageAsync(entity, keys);

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
