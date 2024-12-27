using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrispyWaffle.Composition;
using CrispyWaffle.Log;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Helpers;
using Sankhya.Service;
using Sankhya.Transport;

namespace Sankhya.RequestWrappers;

public static class SimpleCrudRequestWrapper
{
    private static readonly SankhyaContext Context = ServiceLocator.Resolve<SankhyaContext>();

    private static readonly Guid SessionToken = Context.AcquireNewSession(
        ServiceRequestType.SimpleCrud
    );

    private static T CanFindInternal<T>(T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(
                request,
                response,
                response.Entities.Length
            );
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    private static T CanFindInternal<T>(T entity, EntityQueryOptions options)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        if (options.IncludePresentationFields.HasValue)
        {
            request.RequestBody.DataSet.IncludePresentationFields = options
                .IncludePresentationFields
                .Value;
        }

        if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
        {
            request.RequestBody.DataSet.Entities = request
                .RequestBody.DataSet.Entities.Where(e => string.IsNullOrWhiteSpace(e.Path))
                .ToArray();
        }

        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(
                request,
                response,
                response.Entities.Length
            );
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    private static T CanFindInternal<T>(ILiteralCriteria criteria)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(
                request,
                response,
                response.Entities.Length
            );
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    private static Task<T> CanFindInternalAsync<T>(T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        return ProcessRequestFindInternalAsync<T>(request, (_) => null);
    }

    private static Task<T> CanFindInternalAsync<T>(ILiteralCriteria criteria)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        return ProcessRequestFindInternalAsync<T>(request, (_) => null);
    }

    private static T MustFindInternal<T>(T entity, EntityQueryOptions options)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        if (options != null)
        {
            request.Resolve(entity, options);
        }
        else
        {
            request.Resolve(entity);
        }

        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(
                request,
                response,
                response.Entities.Length
            );
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    private static T MustFindInternal<T>(ILiteralCriteria criteria)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(
                request,
                response,
                response.Entities.Length
            );
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    private static Task<T> MustFindInternalAsync<T>(T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        return ProcessRequestFindInternalAsync<T>(
            request,
            (serviceResponse) =>
                throw new ServiceRequestUnexpectedResultException(request, serviceResponse)
        );
    }

    private static Task<T> MustFindInternalAsync<T>(ILiteralCriteria criteria)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        return ProcessRequestFindInternalAsync<T>(
            request,
            (serviceResponse) =>
                throw new ServiceRequestUnexpectedResultException(request, serviceResponse)
        );
    }

    public static T TryFind<T>(this T entity)
        where T : class, IEntity, new() => CanFindInternal(entity);

    public static T TryFind<T>(this T _, ILiteralCriteria criteria)
        where T : class, IEntity, new() => CanFindInternal<T>(criteria);

    public static T TryFind<T>(this T entity, EntityQueryOptions options)
        where T : class, IEntity, new()
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        return CanFindInternal(entity, options);
    }

    public static Task<T> TryFindAsync<T>(this T entity)
        where T : class, IEntity, new() => CanFindInternalAsync(entity);

    public static Task<T> TryFindAsync<T>(this T entity, ILiteralCriteria criteria)
        where T : class, IEntity, new() => CanFindInternalAsync<T>(criteria);

    public static T Find<T>(this T entity)
        where T : class, IEntity, new() => MustFindInternal(entity, null);

    public static T Find<T>(this T entity, EntityQueryOptions options)
        where T : class, IEntity, new() => MustFindInternal(entity, options);

    public static T Find<T>(this T _, ILiteralCriteria criteria)
        where T : class, IEntity, new() => MustFindInternal<T>(criteria);

    public static Task<T> FindAsync<T>(this T entity)
        where T : class, IEntity, new() => MustFindInternalAsync(entity);

    public static Task<T> FindAsync<T>(this T _, ILiteralCriteria criteria)
        where T : class, IEntity, new() => MustFindInternalAsync<T>(criteria);

    public static T Update<T>(this T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceSave);
        request.Resolve(entity);
        var response = SankhyaContext.ServiceInvoker(request, SessionToken);
        if (response.Entities == null)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        return response.Entities.Single().ConvertToType<T>();
    }

    public static async Task UpdateAsync<T>(this T entity, CancellationToken token)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceSave);
        request.Resolve(entity);
        await SankhyaContext
            .ServiceInvokerAsync(request, SessionToken)
            .ContinueWith(t => ConvertToType<T>(t, request), token)
            .ConfigureAwait(false);
    }

    private static T ConvertToType<T>(Task<ServiceResponse> t, ServiceRequest request)
        where T : class, IEntity, new()
    {
        if (t.IsFaulted)
        {
            var exception =
                (
                    t.Exception?.InnerExceptions.FirstOrDefault()
                    ?? t.Exception?.InnerException
                    ?? t.Exception
                ) ?? new InvalidOperationException("Invalid async update request");
            LogConsumer.Handle(exception);
            return null;
        }

        if (t.Result.Entities == null)
        {
            throw new ServiceRequestUnexpectedResultException(request, t.Result);
        }

        return t.Result.Entities.Single().ConvertToType<T>();
    }

    public static void Remove<T>(this T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceRemove);
        request.Resolve(entity);
        SankhyaContext.ServiceInvoker(request, SessionToken);
    }

    public static async Task RemoveAsync<T>(this T entity)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceRemove);
        request.Resolve(entity);
        await SankhyaContext.ServiceInvokerAsync(request, SessionToken).ConfigureAwait(false);
    }

    private static Task<T> ProcessRequestFindInternalAsync<T>(
        ServiceRequest request,
        Func<ServiceResponse, T> callbackNullOrZero
    )
        where T : class, IEntity, new()
    {
        return SankhyaContext
            .ServiceInvokerAsync(request, SessionToken)
            .ContinueWith(response =>
            {
                if (response.Result.Entities == null || response.Result.Entities.Length == 0)
                {
                    return callbackNullOrZero(response.Result);
                }

                if (response.Result.Entities.Length > 1)
                {
                    throw new ServiceRequestTooManyResultsException(
                        request,
                        response.Result,
                        response.Result.Entities.Length
                    );
                }

                return response.Result.Entities.Single().ConvertToType<T>();
            });
    }
}
