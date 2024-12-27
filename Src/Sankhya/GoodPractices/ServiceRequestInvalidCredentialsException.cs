using System;
using Sankhya.Properties;

namespace Sankhya.GoodPractices;

public class ServiceRequestInvalidCredentialsException()
    : Exception(Resources.ServiceRequestInvalidCredentialsException);
