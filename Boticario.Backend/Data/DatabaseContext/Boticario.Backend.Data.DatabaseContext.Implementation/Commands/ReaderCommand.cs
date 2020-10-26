using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.Connection;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation.Commands
{
    internal class ReaderCommand<T> : IReaderCommand<T>
    {   
        private readonly Func<IConnection, Task<T>> function;

        public ReaderCommand(Func<IConnection, Task<T>> function)
        {
            this.function = function;
        }

        public async Task<T> Execute(IConnection connection)
        {
            return await this.function(connection);
        }
    }
}
