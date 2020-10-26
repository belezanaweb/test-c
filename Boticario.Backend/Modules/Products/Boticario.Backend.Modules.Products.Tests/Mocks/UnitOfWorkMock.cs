using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class UnitOfWorkMock : IUnitOfWork
    {
        public bool InTransaction { get; private set; }
        public bool UsedUnifOfWork { get; private set; }

        public UnitOfWorkMock()
        {
            this.UsedUnifOfWork = false;
        }

        public void EnqueueCommand(IWriterCommand command)
        {
        }

        public async Task Execute(Func<Task> function)
        {
            this.InTransaction = true;
            await function();
            this.InTransaction = false;
            this.UsedUnifOfWork = true;
        }
    }
}
