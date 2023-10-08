using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using CrispyWaffle.Utilities;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Service;

namespace Sankhya.Helpers;

/// <summary>
/// The entity dynamic serialization class.
/// </summary>
/// <seealso cref="DynamicSerialization" />
public class EntityDynamicSerialization : DynamicSerialization
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDynamicSerialization" /> class.
    /// </summary>
    public EntityDynamicSerialization() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDynamicSerialization" /> class.
    /// </summary>
    /// <param name="keyFilter">The filter to serialize keys</param>
    public EntityDynamicSerialization(DynamicSerializationOption keyFilter)
        : base(keyFilter) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDynamicSerialization" /> class.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <param name="context">The context.</param>
    // ReSharper disable once UnusedMember.Global
    protected EntityDynamicSerialization(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    /// <summary>
    /// Parse entity.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="instance">The instance.</param>
    /// <param name="type">The type.</param>
    /// <param name="maxInnerLevel">The max inner level of references</param>
    /// <param name="prefix">(Optional) the prefix.</param>
    /// <param name="currentLevel">(Optional) the current level.</param>
    /// <returns>A T.</returns>
    private T ParseEntity<T>(
        T instance,
        Type type,
        ReferenceLevel maxInnerLevel,
        string prefix = null,
        ReferenceLevel currentLevel = ReferenceLevel.None
    )
        where T : class, new()
    {
        if (currentLevel >= maxInnerLevel)
        {
            return null;
        }

        foreach (var propertyInfo in type.GetProperties())
        {
            ParseProperty(instance, maxInnerLevel, prefix, currentLevel, propertyInfo);
        }

        return instance;
    }

    /// <summary>
    /// Processes the property.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
    /// <param name="instance">The instance.</param>
    /// <param name="maxInnerLevel">The maximum inner level.</param>
    /// <param name="prefix">The prefix.</param>
    /// <param name="currentLevel">The current level.</param>
    /// <param name="propertyInfo">The property information.</param>
    private void ParseProperty<T>(
        T instance,
        ReferenceLevel maxInnerLevel,
        string prefix,
        ReferenceLevel currentLevel,
        PropertyInfo propertyInfo
    )
        where T : class, new()
    {
        var isEntityReference = false;
        var propertyName = propertyInfo.Name;
        var customRelationName = string.Empty;

        foreach (var customAttribute in propertyInfo.GetCustomAttributes(true))
        {
            switch (customAttribute)
            {
                case EntityIgnoreAttribute _:
                    return;
                case EntityReferenceAttribute referenceAttribute:
                    isEntityReference = true;
                    customRelationName = referenceAttribute.CustomRelationName;
                    continue;
            }

            if (customAttribute is not EntityElementAttribute)
            {
                continue;
            }

            var attribute = customAttribute as EntityElementAttribute;

            propertyName = attribute.ElementName;
        }

        if (!string.IsNullOrWhiteSpace(prefix))
        {
            propertyName = $@"{prefix}_{propertyName}";
        }

        if (isEntityReference)
        {
            var innerType = propertyInfo.PropertyType;
            var referencePrefix = string.IsNullOrWhiteSpace(customRelationName)
                ? innerType.GetEntityName()
                : customRelationName;
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                referencePrefix = $@"{prefix}_{referencePrefix}";
            }

            var innerLevel = (ReferenceLevel)((int)currentLevel + 1);
            var referenceValue = ParseEntity(
                Activator.CreateInstance(innerType),
                innerType,
                maxInnerLevel,
                referencePrefix,
                innerLevel
            );
            if (
                propertyInfo.GetValue(instance) != null
                && typeof(IUpdateable).IsAssignableFrom(propertyInfo.PropertyType)
            )
            {
                propertyInfo.SetValue(
                    instance,
                    ((IUpdateable)propertyInfo.GetValue(instance)).UpdateValues(
                        (IUpdateable)referenceValue
                    ),
                    null
                );
            }
            else
            {
                propertyInfo.SetValue(instance, referenceValue, null);
            }
        }

        if (
            !Dictionary.ContainsKey(propertyName)
            && !Dictionary.ContainsKey(propertyName.ToUpperInvariant())
        )
        {
            return;
        }

        var valueInDictionary = Dictionary.TryGetValue(propertyName, out var valueLowerCase)
            ? valueLowerCase
            : Dictionary[propertyName.ToUpperInvariant()];
        var propertyType = propertyInfo.PropertyType;
        if (Nullable.GetUnderlyingType(propertyType) != null)
        {
            propertyType = Nullable.GetUnderlyingType(propertyType);
        }

        if (propertyType == null)
        {
            return;
        }

        try
        {
            object value;

            if (valueInDictionary == null)
            {
                value = null;
            }
            else if (typeof(decimal) == propertyType)
            {
                value = decimal.Parse(valueInDictionary.ToString(), CultureInfo.InvariantCulture);
            }
            else if (typeof(bool) == propertyType)
            {
                value = valueInDictionary.ToString().ToBoolean();
            }
            else if (typeof(DateTime) == propertyType)
            {
                var culture = new CultureInfo("pt-BR");
                if (valueInDictionary.ToString().TryToDateTime(out var date))
                {
                    value = date;
                }
                else if (
                    DateTime.TryParseExact(
                        valueInDictionary.ToString(),
                        @"dd/MM/yyyy HH:mm:ss",
                        culture,
                        DateTimeStyles.None,
                        out date
                    )
                )
                {
                    value = date;
                }
                else if (
                    DateTime.TryParseExact(
                        valueInDictionary.ToString(),
                        @"dd/MM/yyyy",
                        culture,
                        DateTimeStyles.None,
                        out date
                    )
                )
                {
                    value = date;
                }
                else
                {
                    throw new InvalidOperationException(
                        $@"Invalid date format for value {valueInDictionary}"
                    );
                }
            }
            else
            {
                value = Convert.ChangeType(valueInDictionary, propertyType);
            }

            propertyInfo.SetValue(instance, value, null);
        }
        catch (Exception e)
        {
            LogConsumer.Handle(e);
        }
    }

    /// <summary>
    /// Converts this object to a type.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <returns>object converted to a type&lt; t&gt;</returns>
    public T ConvertToType<T>()
        where T : class, new()
    {
        var type = typeof(T);
        var instance = (T)Activator.CreateInstance(type);
        instance = ParseEntity(instance, type, ReferenceLevel.Fifth);
        return instance;
    }

    /// <summary>
    /// Changes the keys.
    /// </summary>
    /// <param name="newKeys">The new keys.</param>
    /// <exception cref="InvalidOperationException">The key count in metadata is different than the key count in the dictionary</exception>
    public void ChangeKeys(Metadata newKeys)
    {
        if (newKeys == null)
        {
            return;
        }

        if (newKeys.Fields.Length != Dictionary.Count)
        {
            throw new InvalidOperationException(
                "The key count in metadata is different than the key count in the dictionary"
            );
        }

        var index = 0;
        const string keyFormat = "f{0}";

        foreach (var newKey in newKeys.Fields)
        {
            var oldKey = string.Format(CultureInfo.CurrentCulture, keyFormat, index);
            var value = Dictionary[oldKey];
            Dictionary.Remove(oldKey);
            Dictionary[newKey.Name] = value;
            index++;
        }
    }
}
