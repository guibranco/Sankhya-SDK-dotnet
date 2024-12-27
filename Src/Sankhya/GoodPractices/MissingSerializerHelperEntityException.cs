using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when a serializer helper entity is missing.
/// </summary>
/// <param name="propertyName">The name of the property that is missing the serializer helper entity.</param>
/// <param name="entityName">The name of the entity that is missing the serializer helper entity.</param>
/// <param name="fullyQualifiedClassName">The fully qualified class name of the entity that is missing the serializer helper entity.</param>
public class MissingSerializerHelperEntityException(
    string propertyName,
    string entityName,
    string fullyQualifiedClassName
)
    : Exception(
        string.Format(
            CultureInfo.CurrentCulture,
            Resources.MissingSerializerHelperEntityException,
            propertyName,
            entityName,
            fullyQualifiedClassName
        )
    );
