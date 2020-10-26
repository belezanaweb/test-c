using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.Connection;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation.Commands
{
    internal class WriterCommand : IWriterCommand
    {
        private readonly Func<IConnection, Task> function;

        public WriterCommand(Func<IConnection, Task> function)
        {
            this.function = function;
        }

        public async Task<bool> Execute(IConnection connection)
        {
            await this.function(connection);
            return true;
        }
    }
}
