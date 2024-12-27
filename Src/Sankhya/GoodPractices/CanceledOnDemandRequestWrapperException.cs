using System;

namespace Sankhya.GoodPractices;

public class CanceledOnDemandRequestWrapperException()
    : Exception("Cannot add new items to a cancelled on demand request wrapper instance");
