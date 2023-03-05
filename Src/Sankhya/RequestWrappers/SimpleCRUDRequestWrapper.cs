﻿namespace Sankhya.RequestWrappers;

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

/// <summary>
/// Class SimpleCRUDRequestWrapper. This class cannot be inherited.
/// </summary>
public static class SimpleCrudRequestWrapper
{
    #region Private Members

    /// <summary>
    /// The Sankhya context.
    /// </summary>
    private static readonly SankhyaContext _context = ServiceLocator.Resolve<SankhyaContext>();

    /// <summary>
    /// The session token.
    /// </summary>
    private static readonly Guid _sessionToken = _context.AcquireNewSession(ServiceRequestType.SimpleCrud);

    #endregion
        
    #region Retrieve Methods

    /// <summary>
    /// Determines whether this instance [can find internal] the specified entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static T CanFindInternal<T>(T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(request, response, response.Entities.Length);
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Determines whether this instance [can find internal] the specified entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static T CanFindInternal<T>(T entity, EntityQueryOptions options) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        if (options.IncludePresentationFields.HasValue)
        {
            request.RequestBody.DataSet.IncludePresentationFields = options.IncludePresentationFields.Value;
        }

        if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
        {
            request.RequestBody.DataSet.Entities = request.RequestBody.DataSet.Entities.Where(e => string.IsNullOrWhiteSpace(e.Path)).ToArray();
        }

        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(request, response, response.Entities.Length);
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Determines whether this instance [can find internal] the specified entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static async Task<T> CanFindInternalAsync<T>(T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        return await _context
            .ServiceInvokerAsync(request, _sessionToken)
            .ContinueWith(
                t =>
                {
                    if (t.Result.Entities == null ||
                        t.Result.Entities.Length == 0)
                    {
                        return null;
                    }

                    if (t.Result.Entities.Length > 1)
                    {
                        throw new ServiceRequestTooManyResultsException(
                            request,
                            t.Result,
                            t.Result.Entities
                                .Length);
                    }

                    return t.Result.Entities.Single().ConvertToType<T>();
                })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Determines whether this instance [can find internal] the specified criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static T CanFindInternal<T>(ILiteralCriteria criteria) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            return null;
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(request, response, response.Entities.Length);
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Determines whether this instance [can find internal] the specified criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static async Task<T> CanFindInternalAsync<T>(ILiteralCriteria criteria) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        return await _context
            .ServiceInvokerAsync(request, _sessionToken)
            .ContinueWith(
                t =>
                {
                    if (t.Result.Entities == null ||
                        t.Result.Entities.Length == 0)
                    {
                        return null;
                    }

                    if (t.Result.Entities.Length > 1)
                    {
                        throw new ServiceRequestTooManyResultsException(
                            request,
                            t.Result,
                            t.Result.Entities
                                .Length);
                    }

                    return t.Result.Entities.Single().ConvertToType<T>();
                })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Musts the find internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The entity query options</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static T MustFindInternal<T>(T entity, EntityQueryOptions options) where T : class, IEntity, new()
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

        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(request, response, response.Entities.Length);
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Musts the find internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static async Task<T> MustFindInternalAsync<T>(T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        return await _context
            .ServiceInvokerAsync(request, _sessionToken)
            .ContinueWith(
                t =>
                {
                    if (t.Result.Entities == null ||
                        t.Result.Entities.Length == 0)
                    {
                        throw new ServiceRequestUnexpectedResultException(request, t.Result);
                    }

                    if (t.Result.Entities.Length > 1)
                    {
                        throw new ServiceRequestTooManyResultsException(
                            request,
                            t.Result,
                            t.Result.Entities
                                .Length);
                    }

                    return t.Result.Entities.Single().ConvertToType<T>();
                })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Musts the find internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static T MustFindInternal<T>(ILiteralCriteria criteria) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null || response.Entities.Length == 0)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        if (response.Entities.Length > 1)
        {
            throw new ServiceRequestTooManyResultsException(request, response, response.Entities.Length);
        }

        return response.Entities?.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Musts find entity internal as asynchronous operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>
    /// <exception cref="ServiceRequestTooManyResultsException"></exception>
    private static async Task<T> MustFindInternalAsync<T>(ILiteralCriteria criteria) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        return await _context
            .ServiceInvokerAsync(request, _sessionToken)
            .ContinueWith(
                t =>
                {
                    if (t.Result.Entities == null ||
                        t.Result.Entities.Length == 0)
                    {
                        throw new ServiceRequestUnexpectedResultException(request, t.Result);
                    }

                    if (t.Result.Entities.Length > 1)
                    {
                        throw new ServiceRequestTooManyResultsException(
                            request,
                            t.Result,
                            t.Result.Entities
                                .Length);
                    }

                    return t.Result.Entities.Single().ConvertToType<T>();
                })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// A extension method of a IEntity class that try to find a entity in Sankhya.
    /// If found, returns it else returns null.
    /// If more than one entity is found, it's throws a exception!
    /// </summary>
    /// <typeparam name="T">The <paramref name="entity" /> type, that must be a <see cref="IEntity" /> derived class</typeparam>
    /// <param name="entity">The entity to find (populate it's properties to act as filters)</param>
    /// <returns>Returns the instance with it's values or null if not found.</returns>
    public static T TryFind<T>(this T entity) where T : class, IEntity, new() => CanFindInternal(entity);

    /// <summary>
    /// A extension method of a IEntity class that try to find a entity in Sankhya.
    /// If found, returns it else returns null.
    /// If more than one entity is found, it's throws a exception!
    /// </summary>
    /// <typeparam name="T">The <paramref name="entity" /> type, that must be a <see cref="IEntity" /> derived class</typeparam>
    /// <param name="entity">The entity to find (populate it's properties to act as filters)</param>
    /// <returns>Returns the instance with it's values or null if not found.</returns>
    public static async Task<T> TryFindAsync<T>(this T entity) where T : class, IEntity, new() => await CanFindInternalAsync(entity).ConfigureAwait(false);

    /// <summary>
    /// This method try to find a single entity by a criteria (<seealso cref="ILiteralCriteria" />)
    /// If none entity matches the criteria, null is returned, if more than one is found, throws a exception of type <seealso cref="ServiceRequestTooManyResultsException" />
    /// </summary>
    /// <typeparam name="T">A instance of any implementation of <seealso cref="IEntity" /> as the entity to retrieve/find.</typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="criteria">A instance of any implementation of <seealso cref="ILiteralCriteria" /></param>
    /// <returns>The <seealso cref="IEntity" /> if any results found or null</returns>
    public static T TryFind<T>(this T _, ILiteralCriteria criteria) where T : class, IEntity, new() => CanFindInternal<T>(criteria);

    /// <summary>
    /// This method try to find a single entity by a criteria (<seealso cref="ILiteralCriteria" />)
    /// If none entity matches the criteria, null is returned, if more than one is found, throws a exception of type <seealso cref="ServiceRequestTooManyResultsException" />
    /// </summary>
    /// <typeparam name="T">A instance of any implementation of <seealso cref="IEntity" /> as the entity to retrieve/find.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The query options</param>
    /// <returns>The entity if found or null if not</returns>
    public static T TryFind<T>(this T entity, EntityQueryOptions options) where T : class, IEntity, new()
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        return CanFindInternal(entity, options);
    }

    /// <summary>
    /// This method try to find a single entity by a criteria (<seealso cref="ILiteralCriteria" />)
    /// If none entity matches the criteria, null is returned, if more than one is found, throws a exception of type <seealso cref="ServiceRequestTooManyResultsException" />
    /// </summary>
    /// <typeparam name="T">A instance of any implementation of <seealso cref="IEntity" /> as the entity to retrieve/find.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="criteria">A instance of any implementation of <seealso cref="ILiteralCriteria" /></param>
    /// <returns>The <seealso cref="IEntity" /> if any results found or null</returns>
    public static async Task<T> TryFindAsync<T>(this T entity, ILiteralCriteria criteria) where T : class, IEntity, new() => await CanFindInternalAsync<T>(criteria).ConfigureAwait(false);

    /// <summary>
    /// A extension method of a IEntity class that find a entity in Sankhya.
    /// The criteria must be valid, and result in only one item in database/Sankhya.
    /// If none or more than one result is returned by Sankhya, a exception is thrown
    /// </summary>
    /// <typeparam name="T">The <paramref name="entity" /> type, that must be a <see cref="IEntity" /> derived class</typeparam>
    /// <param name="entity">The entity to find (populate it's properties to act as filters)</param>
    /// <returns>Returns a instance of <paramref name="entity" /> populated with it's values.</returns>
    public static T Find<T>(this T entity) where T : class, IEntity, new() => MustFindInternal(entity, null);

    /// <summary>
    /// A extension method of a IEntity class that find a entity in Sankhya.
    /// The criteria must be valid, and result in only one item in database/Sankhya.
    /// If none or more than one result is returned by Sankhya, a exception is thrown
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    public static T Find<T>(this T entity, EntityQueryOptions options) where T : class, IEntity, new() => MustFindInternal(entity, options);

    /// <summary>
    /// A extension method of a IEntity class that find a entity in Sankhya as asynchronous operation.
    /// The criteria must be valid, and result in only one item in database/Sankhya.
    /// If none or more than one result is returned by Sankhya, a exception is thrown
    /// </summary>
    /// <typeparam name="T">The <paramref name="entity" /> type, that must be a <see cref="IEntity" /> derived class</typeparam>
    /// <param name="entity">The entity to find (populate it's properties to act as filters)</param>
    /// <returns>Returns a instance of <paramref name="entity" /> populated with it's values.</returns>
    public static async Task<T> FindAsync<T>(this T entity) where T : class, IEntity, new() => await MustFindInternalAsync(entity).ConfigureAwait(false);

    /// <summary>
    /// This method lookup a single entity by a criteria (<seealso cref="ILiteralCriteria" />)
    /// If none entity matches the criteria, throws a exception of type <seealso cref="ServiceRequestUnexpectedResultException" />,
    /// if more than one is found, throws a exception of type <seealso cref="ServiceRequestTooManyResultsException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    public static T Find<T>(this T _, ILiteralCriteria criteria) where T : class, IEntity, new() => MustFindInternal<T>(criteria);

    /// <summary>
    /// This method lookup a single entity by a criteria (<seealso cref="ILiteralCriteria" />) asynchronous
    /// If none entity matches the criteria, throws a exception of type <seealso cref="ServiceRequestUnexpectedResultException" />,
    /// if more than one is found, throws a exception of type <seealso cref="ServiceRequestTooManyResultsException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="criteria">The criteria.</param>
    /// <returns>T.</returns>
    public static async Task<T> FindAsync<T>(this T _, ILiteralCriteria criteria) where T : class, IEntity, new() => await MustFindInternalAsync<T>(criteria).ConfigureAwait(false);

    #endregion

    #region Create / Update Methods

    /// <summary>
    /// Updates the specified context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>

    public static T Update<T>(this T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceSave);
        request.Resolve(entity);
        var response = _context.ServiceInvoker(request, _sessionToken);
        if (response.Entities == null)
        {
            throw new ServiceRequestUnexpectedResultException(request, response);
        }

        return response.Entities.Single().ConvertToType<T>();
    }

    /// <summary>
    /// Updates the entity asynchronous.
    /// </summary>
    /// <typeparam name="T">The IEntity to be updated</typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="token">The token.</param>
    /// <returns>A task with the entity result</returns>
    public static async Task UpdateAsync<T>(this T entity, CancellationToken token) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceSave);
        request.Resolve(entity);
        await _context
            .ServiceInvokerAsync(request, _sessionToken)
            .ContinueWith(t => ConvertToType<T>(t, request), token)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Converts to type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t">The t.</param>
    /// <param name="request">The request.</param>
    /// <returns>T.</returns>
    /// <exception cref="ServiceRequestUnexpectedResultException"></exception>
    private static T ConvertToType<T>(Task<ServiceResponse> t, ServiceRequest request) where T : class, IEntity, new()
    {
        if (t.IsFaulted)
        {
            var exception =
                (t.Exception?.InnerExceptions.FirstOrDefault() ??
                 t.Exception?.InnerException ??
                 t.Exception) ?? new InvalidOperationException("Invalid async update request");
            LogConsumer.Handle(exception);
            return null;
        }

        if (t.Result.Entities == null)
        {
            throw new ServiceRequestUnexpectedResultException(request, t.Result);
        }

        return t.Result.Entities.Single().ConvertToType<T>();
    }

    #endregion

    #region Delete Methods

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>

    public static void Remove<T>(this T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceRemove);
        request.Resolve(entity);
        _context.ServiceInvoker(request, _sessionToken);
    }

    /// <summary>
    /// remove as an asynchronous operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>

    public static async Task RemoveAsync<T>(this T entity) where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceRemove);
        request.Resolve(entity);
        await _context.ServiceInvokerAsync(request, _sessionToken).ConfigureAwait(false);
    }

    #endregion
}