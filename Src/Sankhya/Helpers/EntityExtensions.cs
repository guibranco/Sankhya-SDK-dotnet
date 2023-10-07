using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.RequestWrappers;
using Sankhya.Service;
using Sankhya.Transport;
using Sankhya.ValueObjects;

namespace Sankhya.Helpers;

/// <summary>
/// Entity extensions
/// </summary>
public static class EntityExtensions
{
    #region Helper methods

    /// <summary>
    /// A Type extension method that gets entity name for a IEntity implementation
    /// </summary>
    /// <param name="type">The type to act on.</param>
    /// <returns>The entity name.</returns>
    /// <exception cref="ArgumentNullException">type</exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetEntityName(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!typeof(IEntity).IsAssignableFrom(type) && typeof(EntityDynamicSerialization) != type)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.EntityExtensions_TypeMustInherits,
                    type.FullName,
                    typeof(IEntity).FullName,
                    typeof(EntityDynamicSerialization).FullName
                )
            );
        }

        return
            !(
                type.GetCustomAttributes(typeof(EntityAttribute), false)
                is EntityAttribute[] entities
            ) || !entities.Any()
            ? type.Name.ToUpperInvariant()
            : entities.Single().Name;
    }

    /// <summary>
    /// Get the application client of entity custom data attribute
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>ApplicationClient.</returns>
    /// <exception cref="ArgumentNullException">type</exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static EntityCustomDataAttribute GetEntityCustomData(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!typeof(IEntity).IsAssignableFrom(type) && typeof(EntityDynamicSerialization) != type)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.EntityExtensions_TypeMustInherits,
                    type.FullName,
                    typeof(IEntity).FullName,
                    typeof(EntityDynamicSerialization).FullName
                )
            );
        }

        if (
            !(
                type.GetCustomAttributes(typeof(EntityCustomDataAttribute), true)
                is EntityCustomDataAttribute[] entities
            ) || !entities.Any()
        )
        {
            return new();
        }

        if (entities.Length == 1 || entities.Distinct().Count() == 1)
        {
            return entities.First();
        }

        throw new InvalidOperationException(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.EntityExtensions_GetEntityCustomData,
                type.FullName,
                typeof(EntityCustomDataAttribute).FullName
            )
        );
    }

    /// <summary>
    /// An ServiceName extension method that gets the ServiceCategoryAttribute.Category of a field.
    /// </summary>
    /// <param name="service">The service to get category</param>
    /// <returns>The service category</returns>
    public static ServiceAttribute GetService(this ServiceName service)
    {
        var info = typeof(ServiceName).GetField(service.ToString());
        return
            info.GetCustomAttributes(typeof(ServiceAttribute), false)
                is ServiceAttribute[] attributes
            && attributes.Any()
            ? attributes.Single()
            : null;
    }

    /// <summary>
    /// Extracts the keys.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>EntityResolverResult.</returns>
    internal static EntityResolverResult ExtractKeys<T>(this T entity)
        where T : class, IEntity, new()
    {
        var type = typeof(T);
        if (type == typeof(object))
        {
            type = entity.GetType();
        }

        var currentEntityName = type.GetEntityName();
        var result = new EntityResolverResult(currentEntityName);
        foreach (var propertyInfo in type.GetProperties())
        {
            ParseProperty(entity, propertyInfo, result, type, currentEntityName);
        }

        return result;
    }

    /// <summary>
    /// Parses the property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="result">The result.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    private static void ParseProperty<T>(
        T entity,
        PropertyInfo propertyInfo,
        EntityResolverResult result,
        Type type,
        string currentEntityName
    )
        where T : class, IEntity, new()
    {
        var isCriteria = false;
        var propertyName = propertyInfo.Name;
        var customDataProperty = type.GetEntityCustomData();

        var isEntityKey = GetProperties(propertyInfo, ref propertyName);

        if (!isEntityKey)
        {
            return;
        }

        #region Fields & Keys & Criterios

        result.Fields.Add(new() { Name = propertyName });

        var shouldSerializePropertyName = propertyInfo.Name.EndsWith(
            @"Internal",
            StringComparison.InvariantCultureIgnoreCase
        )
            ? propertyInfo.Name.Substring(0, propertyInfo.Name.Length - 8)
            : propertyInfo.Name;

        var shouldSerializeMethod = type.GetMethod(
            string.Concat(@"ShouldSerialize", shouldSerializePropertyName)
        );

        if (shouldSerializeMethod != null && shouldSerializeMethod.ReturnType == typeof(bool))
        {
            isCriteria = (bool)shouldSerializeMethod.Invoke(entity, null);
        }
        else
        {
            LogConsumer.Handle(
                new MissingSerializerHelperEntityException(
                    propertyInfo.Name,
                    currentEntityName,
                    type.FullName
                )
            );
        }

        if (!isCriteria)
        {
            return;
        }

        var possibleValue = propertyInfo.GetValue(entity, null);

        if (possibleValue == null)
        {
            return;
        }

        var value = possibleValue.ToString();

        if (customDataProperty.MaxLength > 0 && value.Length > customDataProperty.MaxLength)
        {
            value = value.Abbreviate(customDataProperty.MaxLength, false);
        }

        result.Keys.Add(new() { Name = propertyName, Value = value });

        #endregion
    }

    /// <summary>
    /// Gets the properties.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns><c>true</c> if is entity key, <c>false</c> otherwise.</returns>
    private static bool GetProperties(PropertyInfo propertyInfo, ref string propertyName)
    {
        var isEntityKey = false;

        foreach (var customAttribute in propertyInfo.GetCustomAttributes(true))
        {
            if (customAttribute is EntityKeyAttribute)
            {
                isEntityKey = true;
                continue;
            }

            if (!(customAttribute is EntityElementAttribute))
            {
                continue;
            }

            var attribute = customAttribute as EntityElementAttribute;

            propertyName = attribute.ElementName;
        }

        return isEntityKey;
    }

    #endregion

    #region IEntity Simple CRUD Service Invokers


    /// <summary>
    /// Queries the internal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <param name="maxResults">The maximum results.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    private static IEnumerable<T> QueryInternal<T>(
        this ServiceRequest request,
        TimeSpan timeout,
        Action<List<T>> processDataOnDemand,
        int maxResults = -1
    )
        where T : class, IEntity, new() =>
        PagedRequestWrapper.GetManagedEnumerator(request, timeout, processDataOnDemand, maxResults);

    /// <summary>
    /// Queries the specified timeout.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> Query<T>(
        this T entity,
        TimeSpan timeout,
        Action<List<T>> processDataOnDemand = null
    )
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity);
        return QueryInternal(request, timeout, processDataOnDemand);
    }

    /// <summary>
    /// Queries the specified criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="criteria">The criteria.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> Query<T>(
        // ReSharper disable once UnusedParameter.Global
        this T _,
        ILiteralCriteria criteria,
        TimeSpan timeout,
        Action<List<T>> processDataOnDemand = null
    )
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria);
        return QueryInternal(request, timeout, processDataOnDemand);
    }

    /// <summary>
    /// Queries the specified options.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The options.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    /// <exception cref="ArgumentNullException">options</exception>
    public static IEnumerable<T> Query<T>(
        this T entity,
        EntityQueryOptions options,
        Action<List<T>> processDataOnDemand = null
    )
        where T : class, IEntity, new()
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(entity, options);
        return QueryInternal(
            request,
            options.Timeout,
            processDataOnDemand,
            options.MaxResults ?? -1
        );
    }

    /// <summary>
    /// Queries the specified options.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="options">The options.</param>
    /// <param name="literalCriteria">The literal criteria.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    /// <exception cref="ArgumentNullException">options</exception>
    public static IEnumerable<T> Query<T>(
        // ReSharper disable once UnusedParameter.Global
        this T _,
        EntityQueryOptions options,
        ILiteralCriteria literalCriteria,
        Action<List<T>> processDataOnDemand = null
    )
        where T : class, IEntity, new()
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(literalCriteria, options);
        return QueryInternal(
            request,
            options.Timeout,
            processDataOnDemand,
            options.MaxResults ?? -1
        );
    }

    /// <summary>
    /// Queries the light.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="maxResults">The maximum results.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> QueryLight<T>(this T entity, TimeSpan timeout, int maxResults = -1)
        where T : class, IEntity, new()
    {
        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve(
            entity,
            new EntityQueryOptions { IncludeReferences = false, IncludePresentationFields = false }
        );
        return QueryInternal<T>(request, timeout, null, maxResults);
    }

    /// <summary>
    /// Queries the specified criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_">The entity.</param>
    /// <param name="criteria">The criteria.</param>
    /// <param name="options">The options.</param>
    /// <param name="processDataOnDemand">The process data on demand.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    /// <exception cref="ArgumentNullException">options</exception>
    public static IEnumerable<T> Query<T>(
        // ReSharper disable once UnusedParameter.Global
        this T _,
        ILiteralCriteria criteria,
        EntityQueryOptions options,
        Action<List<T>> processDataOnDemand = null
    )
        where T : class, IEntity, new()
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        var request = new ServiceRequest(ServiceName.CrudServiceFind);
        request.Resolve<T>(criteria, options);
        return QueryInternal(
            request,
            options.Timeout,
            processDataOnDemand,
            options.MaxResults ?? -1
        );
    }

    #endregion

    #region IEntity On Demand CUD Service Invokers

    /// <summary>
    /// Updates an <see cref="IEntity" /> instance on demand. This operations does not occurs instantly,
    /// but when a stipulated quantity of items are added to a queue or when the OnDemandRequestWrapper
    /// of this type is finalized.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>
    /// <remarks>This operation runs in a separated thread and may fail if one or more items in the queue fail to update (consistency validation, network error, business validation). If this occurs, the entire set state will be lost. The set size vary depending in the queue/throughput size or the items remaining in the queue when the instance is finalized.
    /// For example, if the queue has the length of 10 items, and are sent 1000 items, if one of this items are with error, 10 items will not persist the state but the other 990 will be persisted in a normal lifecycle.
    /// Remember that if a instance is finalized, the entire remaining items in the queue are sent at one time, this mean that in this example,
    /// you can loose the 1000 items (if no requests has been done yet)</remarks>

    public static void UpdateOnDemand<T>(this T entity)
        where T : class, IEntity, new() =>
        OnDemandRequestFactory.GetInstanceForService<T>(ServiceName.CrudServiceSave).Add(entity);

    /// <summary>
    /// Removes the on demand.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity">The entity.</param>

#pragma warning disable CA1030 // Use events where appropriate
    public static void RemoveOnDemand<T>(this T entity)
        where T : class, IEntity, new()
#pragma warning restore CA1030 // Use events where appropriate
    {
        OnDemandRequestFactory.GetInstanceForService<T>(ServiceName.CrudServiceRemove).Add(entity);
    }

    #endregion
}
