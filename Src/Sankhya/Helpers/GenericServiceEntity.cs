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

/// <summary>
/// Class GenericServiceEntity.
/// </summary>
/// <seealso cref="IXmlSerializable" />
/// <seealso cref="IEntity" />
public abstract class GenericServiceEntity : IXmlSerializable, IEntity
{
    #region Implementation of IXmlSerializable

    /// <summary>
    /// This method is reserved and should not be used.When implementing the IXmlSerializable
    /// interface, you should return null (Nothing in Visual Basic) from this method, and instead,
    /// if specifying a custom schema is required, apply the
    /// <see cref="XmlSchemaProviderAttribute" /> to the class.
    /// </summary>
    /// <returns>An <see cref="XmlSchema" /> that describes the XML representation of
    /// the object that is produced by the
    /// <see cref="WriteXml(XmlWriter)" />
    /// method and consumed by the
    /// <see cref="ReadXml(XmlReader)" />
    /// method.</returns>
    public XmlSchema GetSchema() => null;

    /// <summary>
    /// Generates an object from its XML representation.
    /// </summary>
    /// <param name="reader">The <see cref="System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void ReadXml(XmlReader reader) => throw new NotImplementedException();

    /// <summary>
    /// Converts an object into its XML representation.
    /// </summary>
    /// <param name="writer">The <see cref="System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
    public void WriteXml(XmlWriter writer)
    {
        var type = GetType();
        var currentEntityName = type.GetEntityName();

        foreach (var property in GetType().GetProperties())
        {
            WriteXmlElement(writer, property, type, currentEntityName);
        }
    }

    #endregion

    /// <summary>
    /// Writes the XML element.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="property">The property.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
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

    /// <summary>
    /// Serializes the specified writer.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="property">The property.</param>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="customDataProperty">The custom data property.</param>
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

    /// <summary>
    /// Validates the should serialize.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="type">The type.</param>
    /// <param name="currentEntityName">Name of the current entity.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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

    /// <summary>
    /// Validates the attributes.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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
