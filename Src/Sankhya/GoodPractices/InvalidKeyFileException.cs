using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class InvalidKeyFileException(string key)
    : Exception(string.Format(CultureInfo.CurrentCulture, Resources.InvalidKeyFileException, key));
