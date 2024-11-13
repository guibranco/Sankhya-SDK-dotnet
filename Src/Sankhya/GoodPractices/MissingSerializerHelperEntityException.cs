using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

[Serializable]
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

    protected MissingSerializerHelperEntityException(
        SerializationInfo info,
        StreamingContext context
    )
        : base(info, context) { }
}
