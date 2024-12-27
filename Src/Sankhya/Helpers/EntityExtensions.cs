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

public static class EntityExtensions
{
    private static readonly Type InterfaceEntityType = typeof(IEntity);

    private static readonly Type EntityAttributeType = typeof(EntityAttribute);

    private static readonly Type EntityDynamicSerializationType =
        typeof(EntityDynamicSerialization);

    public static string GetEntityName(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!InterfaceEntityType.IsAssignableFrom(type) && type != EntityDynamicSerializationType)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.EntityExtensions_TypeMustInherits,
                    type.FullName,
                    InterfaceEntityType.FullName,
                    EntityDynamicSerializationType.FullName
                )
            );
        }

        if (
            type.GetCustomAttributes(EntityAttributeType, false)
                is EntityAttribute[] attributeElement
            && attributeElement.Any()
        )
        {
            return attributeElement[0].Name;
        }

        if (
            InterfaceEntityType.IsAssignableFrom(type.BaseType)
            && type.BaseType?.GetCustomAttributes(EntityAttributeType, false)
                is EntityAttribute[] attributeElementBase
            && attributeElementBase.Any()
        )
        {
            return attributeElementBase[0].Name;
        }

        if (
            InterfaceEntityType.IsAssignableFrom(type.DeclaringType)
            && type.DeclaringType?.GetCustomAttributes(EntityAttributeType, false)
                is EntityAttribute[] attributeElementDeclaring
            && attributeElementDeclaring.Any()
        )
        {
            return attributeElementDeclaring[0].Name;
        }

        return type.Name.ToUpperInvariant();
    }

    public static EntityCustomDataAttribute GetEntityCustomData(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!typeof(IEntity).IsAssignableFrom(type) && EntityDynamicSerializationType != type)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.EntityExtensions_TypeMustInherits,
                    type.FullName,
                    EntityAttributeType.FullName,
                    EntityDynamicSerializationType.FullName
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
            return entities[0];
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

        result.Fields.Add(new() { Name = propertyName });

        var shouldSerializePropertyName = propertyInfo.Name.EndsWith(
            @"Internal",
            StringComparison.OrdinalIgnoreCase
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
    }

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

            if (!(customAttribute is EntityElementAttribute attribute))
            {
                continue;
            }

            propertyName = attribute.ElementName;
        }

        return isEntityKey;
    }

    private static IEnumerable<T> QueryInternal<T>(
        this ServiceRequest request,
        TimeSpan timeout,
        Action<List<T>> processDataOnDemand,
        int maxResults = -1
    )
        where T : class, IEntity, new() =>
        PagedRequestWrapper.GetManagedEnumerator(request, timeout, processDataOnDemand, maxResults);

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

    public static IEnumerable<T> Query<T>(
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

    public static IEnumerable<T> Query<T>(
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

    public static IEnumerable<T> Query<T>(
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

    public static void UpdateOnDemand<T>(this T entity)
        where T : class, IEntity, new() =>
        OnDemandRequestFactory.GetInstanceForService<T>(ServiceName.CrudServiceSave).Add(entity);

#pragma warning disable CA1030
    public static void RemoveOnDemand<T>(this T entity)
        where T : class, IEntity, new()
#pragma warning restore CA1030
    {
        OnDemandRequestFactory.GetInstanceForService<T>(ServiceName.CrudServiceRemove).Add(entity);
    }
}
