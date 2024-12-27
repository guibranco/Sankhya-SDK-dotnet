using System;

namespace Sankhya.GoodPractices;

public class OpenFileException(string key)
    : Exception($@"Unable to open the file with the key {key} in the Sankhya file manager");
