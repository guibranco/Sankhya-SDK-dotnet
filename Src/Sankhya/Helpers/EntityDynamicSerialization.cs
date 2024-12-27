using System;
using System.Globalization;
using System.Reflection;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using CrispyWaffle.Utilities;
using Sankhya.Attributes;
using Sankhya.Enums;
using Sankhya.Service;

namespace Sankhya.Helpers;

public class EntityDynamicSerialization : DynamicSerialization
{
    public EntityDynamicSerialization() { }

    public EntityDynamicSerialization(DynamicSerializationOption keyFilter)
        : base(keyFilter) { }

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

            if (customAttribute is not EntityElementAttribute attribute)
            {
                continue;
            }

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
                value = decimal.Parse(
                    valueInDictionary.ToString() ?? string.Empty,
                    CultureInfo.InvariantCulture
                );
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

    public T ConvertToType<T>()
        where T : class, new()
    {
        var type = typeof(T);
        var instance = (T)Activator.CreateInstance(type);
        instance = ParseEntity(instance, type, ReferenceLevel.Fifth);
        return instance;
    }

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
