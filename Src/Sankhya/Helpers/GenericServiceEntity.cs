using System;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CrispyWaffle.Extensions;
using CrispyWaffle.Log;
using Sankhya.Attributes;
using Sankhya.GoodPractices;
using Sankhya.Transport;

namespace Sankhya.Helpers;

public abstract class GenericServiceEntity : IXmlSerializable, IEntity
{
    public XmlSchema GetSchema() => null;

    public void ReadXml(XmlReader reader) => throw new NotImplementedException();

    public void WriteXml(XmlWriter writer)
    {
        var type = GetType();
        var currentEntityName = type.GetEntityName();

        foreach (var property in GetType().GetProperties())
        {
            WriteXmlElement(writer, property, type, currentEntityName);
        }
    }

    private void WriteXmlElement(
        XmlWriter writer,
        PropertyInfo property,
        Type type,
        string currentEntityName
    )
    {
        var propertyName = property.Name;

        var customDataProperty = type.GetEntityCustomData();

        if (ValidateAttributes(property, ref propertyName))
        {
            return;
        }

        if (ValidateShouldSerialize(property, type, currentEntityName))
        {
            return;
        }

        Serialize(writer, property, propertyName, customDataProperty);
    }

    private void Serialize(
        XmlWriter writer,
        PropertyInfo property,
        string propertyName,
        EntityCustomDataAttribute customDataProperty
    )
    {
        var value = property.GetValue(this);

        writer.WriteStartElement(propertyName);

        if (value == null)
        {
            writer.WriteEndElement();
            return;
        }

        var propertySerialized = new StringBuilder();

        using (var propertyWriter = XmlWriter.Create(propertySerialized))
        {
            var propertyType = property.PropertyType;
            if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }

            if (propertyType != null)
            {
                if (
                    propertyType == typeof(string)
                    && customDataProperty.MaxLength > 0
                    && value.ToString().Length > customDataProperty.MaxLength
                )
                {
                    value = value.ToString().Abbreviate(customDataProperty.MaxLength, false);
                }

                var serializer = new XmlSerializer(propertyType);
                serializer.Serialize(propertyWriter, value);
            }

            var document = new XmlDocument();

            document.LoadXml(propertySerialized.ToString());

            if (document.DocumentElement != null)
            {
                writer.WriteRaw(document.DocumentElement.InnerXml);
            }
        }

        writer.WriteEndElement();
    }

    private bool ValidateShouldSerialize(PropertyInfo property, Type type, string currentEntityName)
    {
        var shouldSerializeMethodName = property.Name.EndsWith(@"Internal")
            ? property.Name.Substring(0, property.Name.Length - 8)
            : property.Name;

        var shouldSerializeMethod = type.GetMethod(
            string.Concat(@"ShouldSerialize", shouldSerializeMethodName)
        );

        if (shouldSerializeMethod == null || shouldSerializeMethod.ReturnType != typeof(bool))
        {
            LogConsumer.Handle(
                new MissingSerializerHelperEntityException(
                    property.Name,
                    currentEntityName,
                    type.FullName
                )
            );
        }

        if (
            shouldSerializeMethod != null
            && shouldSerializeMethod.ReturnType == typeof(bool)
            && !(bool)shouldSerializeMethod.Invoke(this, null)
        )
        {
            return true;
        }

        return false;
    }

    private static bool ValidateAttributes(PropertyInfo property, ref string propertyName)
    {
        var shouldSerialize = true;

        foreach (var customAttribute in property.GetCustomAttributes(true))
        {
            if (customAttribute is EntityIgnoreAttribute)
            {
                shouldSerialize = false;
                break;
            }

            if (customAttribute is not EntityElementAttribute elementAttribute)
            {
                continue;
            }

            propertyName = elementAttribute.ElementName;
            break;
        }

        if (!shouldSerialize)
        {
            return true;
        }

        return false;
    }
}
