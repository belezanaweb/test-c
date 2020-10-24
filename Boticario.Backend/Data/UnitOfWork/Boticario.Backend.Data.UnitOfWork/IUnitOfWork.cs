using Boticario.Backend.Data.Commands;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool InTransaction { get; }
        void EnqueueCommand(IWriterCommand command);
        Task Execute(Func<Task> function);
    }
}
