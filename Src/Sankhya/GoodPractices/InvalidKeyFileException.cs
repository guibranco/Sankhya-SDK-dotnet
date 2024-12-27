using System;
using System.Globalization;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an invalid key file is encountered.
/// </summary>
/// <param name="key">The key that caused the exception.</param>
public class InvalidKeyFileException(string key)
    : Exception(string.Format(CultureInfo.CurrentCulture, Resources.InvalidKeyFileException, key));
