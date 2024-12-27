using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class InvalidKeyFileException : Exception
{
    public InvalidKeyFileException(string key)
        : base(string.Format(CultureInfo.CurrentCulture, Resources.InvalidKeyFileException, key))
    { }
}
