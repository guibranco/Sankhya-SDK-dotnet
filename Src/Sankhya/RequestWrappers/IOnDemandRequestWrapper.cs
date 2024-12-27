using System;
using Sankhya.Transport;

namespace Sankhya.RequestWrappers;

public interface IOnDemandRequestWrapper : IDisposable
{
    void Add(IEntity entity);

    void Flush();
}
