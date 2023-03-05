namespace Sankhya.GoodPractices;

using System;
using System.Runtime.Serialization;

[Serializable]
public class OpenFileException : Exception
{
    public OpenFileException(string key)
        : base($@"Unable to open the file with the key {key} in the Sankhya file manager")
    { }

    protected OpenFileException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}