using Boticario.Backend.Data.Connection;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext
{
    public interface IDatabaseContext
    {
        Task<T> ExecuteReader<T>(Func<IConnection, Task<T>> function);
        Task ExecuteWriter(Func<IConnection, Task> function);
    }
}
