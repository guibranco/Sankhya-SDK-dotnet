namespace Sankhya.GoodPractices;

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Sankhya.Properties;

[Serializable]
public class InvalidKeyFileException : Exception
{
    public InvalidKeyFileException(string key)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.InvalidKeyFileException, key))
    { }

    protected InvalidKeyFileException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}