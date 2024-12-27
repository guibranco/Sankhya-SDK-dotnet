using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

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
