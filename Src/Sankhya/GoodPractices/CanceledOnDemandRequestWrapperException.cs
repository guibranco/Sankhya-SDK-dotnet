using System;

namespace Sankhya.GoodPractices;

/// <summary>
/// Exception thrown when an attempt is made to add new items to a cancelled on demand request wrapper instance.
/// </summary>
public class CanceledOnDemandRequestWrapperException()
    : Exception("Cannot add new items to a cancelled on demand request wrapper instance.");
