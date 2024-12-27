using System;

namespace Sankhya.GoodPractices;

public class OpenFileException : Exception
{
    public OpenFileException(string key)
        : base($@"Unable to open the file with the key {key} in the Sankhya file manager") { }
}
