using Boticario.Backend.Data.Commands;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation
{
    public class DatabaseContextImpl : IDatabaseContext
    {
        public async Task<T> ExecuteReader<T>(IReaderCommand<T> command)
        {
            if (command == null)
            {
                throw new NullReferenceException("ReaderCommand is Null!");
            }

            return await command.Execute();
        }

        public Task ExecuteWriter(IWriterCommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("WriterCommand is Null!");
            }

            throw new NotImplementedException();
        }
    }
}
