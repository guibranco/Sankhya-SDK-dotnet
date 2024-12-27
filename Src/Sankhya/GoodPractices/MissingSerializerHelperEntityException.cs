using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class MissingSerializerHelperEntityException : Exception
{
    public MissingSerializerHelperEntityException(
        string propertyName,
        string entityName,
        string fullyQualifiedClassName
    )
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.MissingSerializerHelperEntityException,
                propertyName,
                entityName,
                fullyQualifiedClassName
            )
        ) { }
}
