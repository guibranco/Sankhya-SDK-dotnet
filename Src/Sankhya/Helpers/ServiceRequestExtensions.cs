using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using CrispyWaffle.Utilities;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.GoodPractices;
using Sankhya.Properties;
using Sankhya.Service;
using Sankhya.Transport;
using Sankhya.Validations;
using Sankhya.ValueObjects;

namespace Sankhya.Helpers;

/// <summary>
/// Implements service request extensions methods.
/// </summary>
public static class ServiceRequestExtensions
{
    #region Private methods

    /// <summary>
    /// Parse properties.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The Service Request</param>
    /// <param name="criteria">The criteria.</param>
    /// <param name="maxLevel">(Optional) the maximum level.</param>
    /// <param name="currentLevel">(Optional) the current level.</param>
    /// <returns>A ParseResult.</returns>
    /// <exception cref="TooInnerLevelsException">Thrown when a Too Inner Levels error condition occurs.</exception>
    private static EntityResolverResult ParseProperties<T>(
        this ServiceRequest request,
        T criteria,
        ReferenceLevel maxLevel,
        ReferenceLevel currentLevel = ReferenceLevel.None
    )
    {
        var type = typeof(T);
        if (type == typeof(object))
        {
            type = criteria.GetType();
        }

        var currentEntityName = type.GetEntityName();
        if (maxLevel == ReferenceLevel.Fifth)
        {
            throw new TooInnerLevelsException(currentEntityName);
        }

        var result = new EntityResolverResult(currentEntityName);
        var ignoredFields = new List<string>();
        foreach (var propertyInfo in type.GetProperties())
        {
            ParseProperty(
                request,
                criteria,
                maxLevel,
                currentLevel,
                propertyInfo,
                ignoredFields,
                result,
                type,
                currentEntityName
            );
        }

        return result;
    }

    /// <summary>
    /// Parses the property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="criteriaEntity">The entity used as criteria.</param>
    /// <param name="maxLevel">The maximum level.</param>
    /// <param name="currentLevel">The current level.</param>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="ignoredFields">The ignored fields.</param>
    /// <param name="result">The result.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    private static void ParseProperty<T>(
        ServiceRequest request,
        T criteriaEntity,
        ReferenceLevel maxLevel,
        ReferenceLevel currentLevel,
        PropertyInfo propertyInfo,
        ICollection<string> ignoredFields,
        EntityResolverResult result,
        Type type,
        string currentEntityName
    )
    {
        var model = new ParsePropertyModel();

        ParseCustomAttributes(propertyInfo, model);

        if (CheckIfElementIsIgnored(propertyInfo, ignoredFields, model))
        {
            return;
        }

        if (
            !model.IsEntityReference
            && !model.IgnoreEntityReferenceInline
            && (
                EntityValidation.ReferenceFieldsFirstLevelPattern.IsMatch(model.PropertyName)
                || EntityValidation.ReferenceFieldsSecondLevelPattern.IsMatch(model.PropertyName)
            )
        )
        {
            model.IsEntityReferenceInline = true;
        }

        ProcessParse(
            request,
            criteriaEntity,
            maxLevel,
            currentLevel,
            propertyInfo,
            result,
            type,
            currentEntityName,
            model
        );
    }

    /// <summary>
    /// Processes the parse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="criteriaEntity">The criteria entity.</param>
    /// <param name="maxLevel">The maximum level.</param>
    /// <param name="currentLevel">The current level.</param>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="result">The result.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    /// <param name="model">The model.</param>
    private static void ProcessParse<T>(
        ServiceRequest request,
        T criteriaEntity,
        ReferenceLevel maxLevel,
        ReferenceLevel currentLevel,
        PropertyInfo propertyInfo,
        EntityResolverResult result,
        Type type,
        string currentEntityName,
        ParsePropertyModel model
    )
    {
        if (!model.IsEntityReference && !model.IsEntityReferenceInline)
        {
            ProcessFieldsAndCriteria(
                request,
                criteriaEntity,
                currentLevel,
                propertyInfo,
                result,
                type,
                currentEntityName,
                model
            );
        }
        else if (model.IsEntityReferenceInline)
        {
            ProcessEntityReferenceInline(result, type, currentEntityName, model);
        }
        else
        {
            ProcessEntityReference(
                request,
                criteriaEntity,
                maxLevel,
                currentLevel,
                propertyInfo,
                result,
                model
            );
        }
    }

    /// <summary>
    /// Processes the fields and criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="criteriaEntity">The criteria entity.</param>
    /// <param name="currentLevel">The current level.</param>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="result">The result.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    /// <param name="model">The model.</param>
    private static void ProcessFieldsAndCriteria<T>(
        ServiceRequest request,
        T criteriaEntity,
        ReferenceLevel currentLevel,
        PropertyInfo propertyInfo,
        EntityResolverResult result,
        Type type,
        string currentEntityName,
        ParsePropertyModel model
    )
    {
        result.Fields.Add(new() { Name = model.PropertyName });

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
            model.IsCriteria = (bool)shouldSerializeMethod.Invoke(criteriaEntity, null);
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

        if (
            !model.IsCriteria
            && (
                !model.IsEntityKey
                || currentLevel != ReferenceLevel.None
                || request.Service == ServiceName.CrudServiceSave
                || request.Service == ServiceName.CrudSave
            )
        )
        {
            return;
        }

        var possibleValue = propertyInfo.GetValue(criteriaEntity, null);
        if (possibleValue == null)
        {
            return;
        }

        var value = possibleValue.ToString();
        if (model.CustomData.MaxLength > 0 && value.Length > model.CustomData.MaxLength)
        {
            value = value.Abbreviate(model.CustomData.MaxLength, false);
        }

        if (model.IsEntityKey)
        {
            result.Keys.Add(new() { Name = model.PropertyName, Value = value });
        }

        if (model.IsCriteria)
        {
            result.Criteria.Add(new() { Name = model.PropertyName, Value = value });
            var isNumberType = propertyInfo.PropertyType.IsNumericType();
            var condition = string.Concat(
                model.PropertyName,
                @" = ",
                isNumberType ? string.Empty : @"'",
                value,
                isNumberType ? string.Empty : @"'"
            );
            result.LiteralCriteria.Expression =
                result.Criteria.Count == 1
                    ? condition
                    : string.Concat(result.LiteralCriteria.Expression, @" AND ", condition);
        }

        result.FieldValues.Add(new() { Name = model.PropertyName, Value = value });
    }

    /// <summary>
    /// Processes the entity reference inline.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    /// <param name="model">The model.</param>
    private static void ProcessEntityReferenceInline(
        EntityResolverResult result,
        Type type,
        string currentEntityName,
        ParsePropertyModel model
    )
    {
        var secondLevel = EntityValidation.ReferenceFieldsSecondLevelPattern.IsMatch(
            model.PropertyName
        );
        var match = secondLevel
            ? EntityValidation.ReferenceFieldsSecondLevelPattern.Match(model.PropertyName)
            : EntityValidation.ReferenceFieldsFirstLevelPattern.Match(model.PropertyName);
        var referenceEntity = secondLevel
            ? $@"{match.Groups[@"parentEntity"].Value}.{match.Groups[@"entity"].Value}"
            : match.Groups[@"entity"].Value;
        var referenceField = new Field { Name = match.Groups[@"field"].Value };

        if (result.References.ContainsKey(referenceEntity))
        {
            result.References[referenceEntity].Add(referenceField);
        }
        else
        {
            result.References.Add(referenceEntity, new() { referenceField });
        }

        LogConsumer.Warning(
            Resources.ServiceRequestExtensions_ParseProperty,
            referenceEntity,
            referenceField.Name,
            model.PropertyName,
            currentEntityName,
            type.Name
        );
    }

    /// <summary>
    /// Processes the entity reference.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="criteriaEntity">The criteria entity.</param>
    /// <param name="maxLevel">The maximum level.</param>
    /// <param name="currentLevel">The current level.</param>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="result">The result.</param>
    /// <param name="model">The model.</param>
    private static void ProcessEntityReference<T>(
        ServiceRequest request,
        T criteriaEntity,
        ReferenceLevel maxLevel,
        ReferenceLevel currentLevel,
        PropertyInfo propertyInfo,
        EntityResolverResult result,
        ParsePropertyModel model
    )
    {
        if ((int)maxLevel <= (int)currentLevel)
        {
            return;
        }

        var innerType = propertyInfo.PropertyType;
        var innerLevel = (ReferenceLevel)((int)currentLevel + 1);
        var innerTypeValue =
            Convert.ChangeType(
                propertyInfo.GetValue(criteriaEntity, null),
                innerType,
                CultureInfo.InvariantCulture
            ) ?? Activator.CreateInstance(innerType);
        var innerResult = request.ParseProperties(innerTypeValue, maxLevel, innerLevel);

        var innerName = string.IsNullOrWhiteSpace(model.CustomRelationName)
            ? innerType.GetEntityName()
            : model.CustomRelationName;

        foreach (var innerField in innerResult.Fields)
        {
            if (result.References.ContainsKey(innerName))
            {
                result.References[innerName].Add(innerField);
            }
            else
            {
                result.References.Add(innerName, new() { innerField });
            }
        }

        foreach (var innerReference in innerResult.References)
        {
            if (innerName.Equals(innerReference.Key, StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            var nestedInnerReference = $@"{innerName}.{innerReference.Key}";

            if (result.References.ContainsKey(nestedInnerReference))
            {
                result.References[nestedInnerReference].AddRange(innerReference.Value);
            }
            else
            {
                result.References.Add(nestedInnerReference, innerReference.Value);
            }
        }

        foreach (var criteria in innerResult.Criteria)
        {
            result.Criteria.Add(
                new() { Name = $@"{innerName}->{criteria.Name}", Value = criteria.Value }
            );
        }
    }

    /// <summary>
    /// Checks if element is ignored.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="ignoredFields">The ignored fields.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    private static bool CheckIfElementIsIgnored(
        PropertyInfo propertyInfo,
        ICollection<string> ignoredFields,
        ParsePropertyModel model
    )
    {
        if (
            !model.IsIgnored
            && (
                !ignoredFields.Any(
                    f => f.Equals(model.PropertyName, StringComparison.InvariantCultureIgnoreCase)
                )
                || propertyInfo.Name.EndsWith(
                    @"Internal",
                    StringComparison.InvariantCultureIgnoreCase
                )
            )
        )
        {
            return false;
        }

        ignoredFields.Add(model.PropertyName);
        return true;
    }

    /// <summary>
    /// Parses the custom attributes.
    /// </summary>
    /// <param name="propertyInfo">The property information.</param>
    /// <param name="model">The model.</param>
    private static void ParseCustomAttributes(PropertyInfo propertyInfo, ParsePropertyModel model)
    {
        foreach (var customAttribute in propertyInfo.GetCustomAttributes(true))
        {
            switch (customAttribute)
            {
                case EntityIgnoreAttribute _:
                    model.IsIgnored = true;
                    continue;
                case EntityKeyAttribute _:
                    model.IsEntityKey = true;
                    continue;
                case EntityReferenceAttribute referenceAttribute:
                    model.IsEntityReference = true;
                    model.CustomRelationName = referenceAttribute.CustomRelationName;
                    continue;
                case EntityElementAttribute elementAttribute:
                    model.PropertyName = elementAttribute.ElementName;
                    model.IgnoreEntityReferenceInline = elementAttribute.IgnoreInlineReference;
                    continue;
                case EntityCustomDataAttribute customDataAttribute:
                    model.CustomData = customDataAttribute;
                    continue;
            }
        }

        if (string.IsNullOrWhiteSpace(model.PropertyName))
        {
            model.PropertyName = propertyInfo.Name;
        }
    }

    #endregion

    #region IEntity CRUD Resolvers

    /// <summary>
    /// Request with type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The request</param>
    /// <exception cref="InvalidServiceRequestOperationException">Thrown when an Invalid Service Request Operation error condition occurs.</exception>
    public static void Resolve<T>(this ServiceRequest request)
        where T : class, IEntity, new()
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (
            request.Service != ServiceName.CrudFind
            && request.Service != ServiceName.CrudServiceFind
        )
        {
            throw new InvalidServiceRequestOperationException(request.Service);
        }

        var criteria = new T();
        var result = request.ParseProperties(criteria, ReferenceLevel.Third);

        switch (request.Service)
        {
            #region CRUD Find

            case ServiceName.CrudFind:
                request.RequestBody.Entity = new()
                {
                    Fields = result.Fields.ToArray(),
                    Name = result.Name,
                    IncludePresentationFields = false
                };
                if (!result.References.Any())
                {
                    return;
                }

                request.RequestBody.Entity.ReferencesFetch = result.References
                    .Select(
                        reference =>
                            new ReferenceFetch
                            {
                                Field = reference.Value.ToArray(),
                                Name = reference.Key
                            }
                    )
                    .ToArray();
                break;

            #endregion

            #region CRUD Service Find

            case ServiceName.CrudServiceFind:
                request.RequestBody.DataSet = new()
                {
                    RootEntity = result.Name,
                    IncludePresentationFields = false,
                    ParallelLoader = true,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_1")
                };
                var entities = new List<Entity>
                {
                    new()
                    {
                        Path = string.Empty,
                        Fieldset = new()
                        {
                            List = string.Join(@",", result.Fields.Select(f => f.Name))
                        }
                    }
                };
                if (!result.References.Any())
                {
                    request.RequestBody.DataSet.Entities = entities.ToArray();
                    return;
                }

                entities.AddRange(
                    result.References.Select(
                        reference =>
                            new Entity
                            {
                                Path = reference.Key,
                                Fieldset = new()
                                {
                                    List = string.Join(@",", reference.Value.Select(v => v.Name))
                                }
                            }
                    )
                );
                request.RequestBody.DataSet.Entities = entities.ToArray();
                break;

            #endregion
        }
    }

    /// <summary>
    /// Request with type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The request</param>
    /// <param name="criteria">The criteria.</param>
    /// <param name="maxReferenceLevel"></param>
    /// <exception cref="InvalidServiceRequestOperationException"></exception>
    public static void Resolve<T>(
        this ServiceRequest request,
        T criteria,
        ReferenceLevel maxReferenceLevel = ReferenceLevel.Fourth
    )
        where T : class, IEntity, new()
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (criteria == null)
        {
            throw new ArgumentNullException(nameof(criteria));
        }

        var maxReference = maxReferenceLevel;

        if (request.Service == ServiceName.CrudServiceFind && maxReference == ReferenceLevel.Fourth)
        {
            maxReference = ReferenceLevel.Third;
        }

        var result = request.ParseProperties(criteria, maxReference);
        if (
            request.Service == ServiceName.CrudFind
            || request.Service == ServiceName.CrudSave
            || request.Service == ServiceName.CrudRemove
        )
        {
            request.RequestBody.Entity = new() { Name = result.Name };
        }

        HandleService(request, result);
    }

    /// <summary>
    /// Handles the service.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="result">The result.</param>
    /// <exception cref="InvalidServiceRequestOperationException"></exception>
    private static void HandleService(ServiceRequest request, EntityResolverResult result)
    {
        switch (request.Service)
        {
            #region CRUD Find

            case ServiceName.CrudFind:

                request.RequestBody.Entity.Criteria = result.Criteria.ToArray();
                request.RequestBody.Entity.Fields = result.Fields.ToArray();
                request.RequestBody.Entity.IncludePresentationFields = false;
                if (!result.References.Any())
                {
                    return;
                }

                request.RequestBody.Entity.ReferencesFetch = result.References
                    .Select(
                        reference =>
                            new ReferenceFetch
                            {
                                Field = reference.Value.ToArray(),
                                Name = reference.Key
                            }
                    )
                    .ToArray();

                break;

            #endregion

            #region CRUD Save | CRUD Remove

            case ServiceName.CrudSave:
            case ServiceName.CrudRemove:

                request.RequestBody.Entity.Campos = result.FieldValues.ToArray();

                break;

            #endregion

            #region CRUD Service Find

            case ServiceName.CrudServiceFind:

                request.RequestBody.DataSet = new()
                {
                    RootEntity = result.Name,
                    IncludePresentationFields = false,
                    ParallelLoader = true,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_1")
                };
                var entities = new List<Entity>
                {
                    new()
                    {
                        Path = string.Empty,
                        Fieldset = new()
                        {
                            List = string.Join(@",", result.Fields.Select(f => f.Name))
                        }
                    }
                };
                request.RequestBody.DataSet.LiteralCriteria = result.LiteralCriteria;
                if (!result.References.Any())
                {
                    request.RequestBody.DataSet.Entities = entities.ToArray();
                    return;
                }

                entities.AddRange(
                    result.References.Select(
                        reference =>
                            new Entity
                            {
                                Path = reference.Key,
                                Fieldset = new()
                                {
                                    List = string.Join(@",", reference.Value.Select(v => v.Name))
                                }
                            }
                    )
                );
                request.RequestBody.DataSet.Entities = entities.ToArray();

                break;

            #endregion

            #region CRUD Service Save

            case ServiceName.CrudServiceSave:

                request.RequestBody.DataSet = new()
                {
                    RootEntity = result.Name,
                    IncludePresentationFields = false,
                    ParallelLoader = true,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_1"),
                    Entities = new[]
                    {
                        new Entity
                        {
                            Path = string.Empty,
                            Fieldset = new() { List = @"*" }
                        }
                    },
                    DataRows = new[]
                    {
                        new DataRow { Keys = new(), LocalFields = new() }
                    }
                };
                result.Keys.ForEach(
                    k =>
                        request.RequestBody.DataSet.DataRows
                            .Single()
                            .Keys.SetMember(k.Name, k.Value)
                );
                result.FieldValues
                    .Except(result.Keys)
                    .ToList()
                    .ForEach(
                        f =>
                            request.RequestBody.DataSet.DataRows
                                .Single()
                                .LocalFields.SetMember(f.Name, f.Value)
                    );

                break;

            #endregion

            #region CRUD Service Remove

            case ServiceName.CrudServiceRemove:

                request.RequestBody.Entity = new()
                {
                    RootEntity = result.Name,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_2"),
                    Ids = new[]
                    {
                        new EntityDynamicSerialization(DynamicSerializationOption.Uppercase)
                    }
                };
                result.Keys.ForEach(
                    k => request.RequestBody.Entity.Ids[0].SetMember(k.Name, k.Value)
                );

                break;

            #endregion

            default:
                throw new InvalidServiceRequestOperationException(request.Service);
        }
    }

    /// <summary>
    /// Request with type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The request</param>
    /// <param name="criteriaList">The criteria list to create/update/save or exclude/remove.</param>
    /// <exception cref="InvalidServiceRequestOperationException">Thrown when an Invalid Service Request Operation error condition occurs.</exception>
    public static void Resolve<T>(this ServiceRequest request, ICollection<T> criteriaList)
        where T : class, IEntity, new()
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var results = criteriaList
            .Select(criteria => request.ParseProperties(criteria, ReferenceLevel.Third))
            .ToList();

        var sample = results[0];

        switch (request.Service)
        {
            #region CRUD Service Save

            case ServiceName.CrudServiceSave:
                request.RequestBody.DataSet = new()
                {
                    RootEntity = sample.Name,
                    IncludePresentationFields = false,
                    ParallelLoader = true,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_1"),
                    Entities = new[]
                    {
                        new Entity
                        {
                            Path = string.Empty,
                            Fieldset = new() { List = @"*" }
                        }
                    }
                };
                var dataRows = new List<DataRow>();
                foreach (var result in results)
                {
                    var dataRow = new DataRow { Keys = new() };
                    dataRows.Add(dataRow);
                    result.Keys.ForEach(k => dataRow.Keys.SetMember(k.Name, k.Value));
                    if (request.Service != ServiceName.CrudServiceSave)
                    {
                        continue;
                    }

                    dataRow.LocalFields = new();
                    result.FieldValues
                        .Except(result.Keys)
                        .ToList()
                        .ForEach(v => dataRow.LocalFields.SetMember(v.Name, v.Value));
                }

                request.RequestBody.DataSet.DataRows = dataRows.ToArray();
                break;

            #endregion

            #region CRUD Service Remove

            case ServiceName.CrudServiceRemove:
                var ids = new List<EntityDynamicSerialization>();
                foreach (var result in results)
                {
                    var id = new EntityDynamicSerialization(DynamicSerializationOption.Uppercase);
                    ids.Add(id);
                    result.Keys.ForEach(k => id.SetMember(k.Name, k.Value));
                }

                request.RequestBody.Entity = new()
                {
                    RootEntity = sample.Name,
                    DataSetId = string.Concat(DateTime.Now.ToUnixTimeStamp(), @"_2"),
                    Ids = ids.ToArray()
                };
                break;

            #endregion

            default:
                throw new InvalidServiceRequestOperationException(request.Service);
        }
    }

    /// <summary>
    /// Resolve <seealso cref="IEntity" /> to a <seealso cref="ServiceRequest" /> using a <seealso cref="ILiteralCriteria" /> as filter.
    /// This method is only used for retrieve (in CRUD, the R part) data requests, so, only ServiceName.CRUD_FIND or ServiceName.CRUD_SERVICE_FIND can be used.
    /// Any other service request will throw a exception of type <seealso cref="InvalidServiceRequestOperationException" />.
    /// If <paramref name="literalCriteria" /> is of type <seealso cref="LiteralCriteriaSql" />, then service must be ServiceName.CRUD_FIND or it will also throw a exception.
    /// </summary>
    /// <typeparam name="T">Generic type parameter. Must be a <seealso cref="IEntity" /> entity.</typeparam>
    /// <param name="request">The request</param>
    /// <param name="literalCriteria">The literal criteria.</param>
    /// <exception cref="InvalidServiceRequestOperationException">Throws when the <paramref name="literalCriteria" /> is not a instance of <seealso cref="LiteralCriteria" /> and the <seealso cref="ServiceName" /> of the <paramref name="request" /> is not CRUD_FIND or CRUD_SERVICE_FIND and also <paramref name="literalCriteria" /> is not a instance of <seealso cref="LiteralCriteriaSql" /> and the <seealso cref="ServiceName" /> is CRUD_FIND.</exception>
    public static void Resolve<T>(this ServiceRequest request, ILiteralCriteria literalCriteria)
        where T : class, IEntity, new()
    {
        request.Resolve<T>();
        var literal = literalCriteria as LiteralCriteria;
        var literalSql = literalCriteria as LiteralCriteriaSql;
        if (literal != null && request.Service == ServiceName.CrudFind)
        {
            request.RequestBody.Entity.LiteralCriteria = literal;
        }
        else if (literal != null && request.Service == ServiceName.CrudServiceFind)
        {
            request.RequestBody.DataSet.LiteralCriteria = literal;
        }
        else if (literalSql != null && request.Service == ServiceName.CrudFind)
        {
            request.RequestBody.Entity.LiteralCriteriaSql = literalSql;
        }
        else
        {
            throw new InvalidServiceRequestOperationException(request.Service);
        }
    }

    /// <summary>
    /// Request with type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The request</param>
    /// <param name="literalCriteriaBuilder">The literal criteria builder.</param>
    public static void Resolve<T>(this ServiceRequest request, StringBuilder literalCriteriaBuilder)
        where T : class, IEntity, new()
    {
        if (literalCriteriaBuilder == null)
        {
            throw new ArgumentNullException(nameof(literalCriteriaBuilder));
        }

        request.Resolve<T>(new LiteralCriteria(literalCriteriaBuilder.ToString()));
    }

    /// <summary>
    /// Request with type using predicate.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="request">The request</param>
    /// <param name="predicate">The predicate to use as literal criteria</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    // TODO: issue #29
    public static void Resolve<T>(this ServiceRequest request, Expression<Func<T, bool>> predicate)
        where T : class, IEntity, new() => throw new NotImplementedException();

    /// <summary>
    /// Resolves the specified entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="entity">The entity.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="InvalidServiceRequestOperationException"></exception>
    public static void Resolve<T>(this ServiceRequest request, T entity, EntityQueryOptions options)
        where T : class, IEntity, new()
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        request.Resolve(entity, options.MaxReferenceDepth ?? ReferenceLevel.Fourth);
        switch (request.Service)
        {
            case ServiceName.CrudFind:
                if (options.IncludePresentationFields.HasValue)
                {
                    request.RequestBody.Entity.IncludePresentationFields = options
                        .IncludePresentationFields
                        .Value;
                }

                if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
                {
                    request.RequestBody.Entity.ReferencesFetch = null;
                }

                if (options.MaxResults.HasValue)
                {
                    request.RequestBody.Entity.RowsLimit = options.MaxResults.Value;
                }

                break;
            case ServiceName.CrudServiceFind:
                if (options.IncludePresentationFields.HasValue)
                {
                    request.RequestBody.DataSet.IncludePresentationFields = options
                        .IncludePresentationFields
                        .Value;
                }

                if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
                {
                    request.RequestBody.DataSet.Entities = request.RequestBody.DataSet.Entities
                        .Where(e => string.IsNullOrWhiteSpace(e.Path))
                        .ToArray();
                }

                if (options.UseWildcardFields.HasValue && options.UseWildcardFields.Value)
                {
                    foreach (var dataSetEntity in request.RequestBody.DataSet.Entities)
                    {
                        dataSetEntity.Fieldset = new() { List = @"*" };
                        dataSetEntity.Fields = null;
                    }
                }

                break;
        }
    }

    /// <summary>
    /// Resolves the specified criteria.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="criteria">The criteria.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="InvalidServiceRequestOperationException"></exception>
    public static void Resolve<T>(
        this ServiceRequest request,
        ILiteralCriteria criteria,
        EntityQueryOptions options
    )
        where T : class, IEntity, new()
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        request.Resolve<T>(criteria);
        switch (request.Service)
        {
            case ServiceName.CrudFind:

                ResolveCrudFindInternal(request, options);

                break;
            case ServiceName.CrudServiceFind:

                ResolveCrudServiceFindInternal(request, options);

                break;
        }
    }

    #endregion

    /// <summary>
    /// Resolves the crud service find internal.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="NotImplementedException"></exception>
    private static void ResolveCrudServiceFindInternal(
        ServiceRequest request,
        EntityQueryOptions options
    )
    {
        if (options.IncludePresentationFields.HasValue)
        {
            request.RequestBody.DataSet.IncludePresentationFields = options
                .IncludePresentationFields
                .Value;
        }

        if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
        {
            request.RequestBody.DataSet.Entities = request.RequestBody.DataSet.Entities
                .Where(e => string.IsNullOrWhiteSpace(e.Path))
                .ToArray();
        }

        if (options.MaxReferenceDepth.HasValue)
        {
            throw new NotImplementedException();
        }

        if (options.UseWildcardFields.HasValue && options.UseWildcardFields.Value)
        {
            foreach (var dataSetEntity in request.RequestBody.DataSet.Entities)
            {
                dataSetEntity.Fieldset = new() { List = @"*" };
                dataSetEntity.Fields = null;
            }
        }
    }

    /// <summary>
    /// Resolves the crud find internal.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="NotImplementedException"></exception>
    private static void ResolveCrudFindInternal(ServiceRequest request, EntityQueryOptions options)
    {
        if (options.IncludePresentationFields.HasValue)
        {
            request.RequestBody.Entity.IncludePresentationFields = options
                .IncludePresentationFields
                .Value;
        }

        if (options.IncludeReferences.HasValue && !options.IncludeReferences.Value)
        {
            request.RequestBody.Entity.ReferencesFetch = null;
        }

        if (options.MaxReferenceDepth.HasValue)
        {
            throw new NotImplementedException();
        }

        if (options.MaxResults.HasValue)
        {
            request.RequestBody.Entity.RowsLimit = options.MaxResults.Value;
        }
    }
}
