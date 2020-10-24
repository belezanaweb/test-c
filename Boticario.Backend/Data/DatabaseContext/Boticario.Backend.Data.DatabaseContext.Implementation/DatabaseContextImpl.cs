using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation
{
    public class DatabaseContextImpl : IDatabaseContext
    {
        private readonly IUnitOfWork unitOfwork;

        public DatabaseContextImpl(IUnitOfWork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }

        public async Task<T> ExecuteReader<T>(IReaderCommand<T> command)
        {
            if (command == null)
            {
                throw new NullReferenceException("ReaderCommand is Null!");
            }

            return await command.Execute();
        }

        public async Task ExecuteWriter(IWriterCommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("WriterCommand is Null!");
            }

            if (this.unitOfwork.InTransaction)
            {
                this.unitOfwork.EnqueueCommand(command);
            }
            else
            {
                await command.Execute();
            }
        }
    }
}
