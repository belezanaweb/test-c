using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests.Mocks
{
    internal class UnifOfWorkMock : IUnitOfWork
    {
        private readonly LinkedList<IWriterCommand> commands;

        public bool InTransaction { get; private set; }

        public UnifOfWorkMock()
        {
            this.commands = new LinkedList<IWriterCommand>();
        }
        
        public void EnqueueCommand(IWriterCommand command)
        {
            this.commands.AddLast(command);
        }

        public async Task Execute(Func<Task> function)
        {
            this.InTransaction = true;
            await function();
            this.InTransaction = false;
        }
    }
}
