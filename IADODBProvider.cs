using System;
using MFramework.Infrastructure.Database.Connections;

namespace MFramework.Infrastructure.Database
{
    public interface IADODBProvider<T> where T:IEquatable<T>
    {
        IADODBConnection NewConnection();
        string ProviderName { get; }
        T Id { get; }
    }
}
