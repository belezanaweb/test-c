using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool InTransaction { get; }
        Task Execute(Func<Task> function);
    }
}
