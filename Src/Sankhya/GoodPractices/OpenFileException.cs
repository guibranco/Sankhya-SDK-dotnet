using System;

namespace Sankhya.GoodPractices;

/// <summary>
/// Represents an exception that is thrown when a file cannot be opened in the Sankhya file manager.
/// </summary>
/// <param name="key">The key associated with the file that could not be opened.</param>
public class OpenFileException(string key)
    : Exception($@"Unable to open the file with the key {key} in the Sankhya file manager");
