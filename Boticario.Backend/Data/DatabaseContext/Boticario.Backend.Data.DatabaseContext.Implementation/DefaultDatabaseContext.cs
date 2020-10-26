using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.DatabaseContext.Implementation.Commands;
using Boticario.Backend.Data.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation
{
    public class DefaultDatabaseContext : IDatabaseContext
    {
        private readonly IUnitOfWork unitOfwork;
        private readonly IConnectionPool connectionPool;

        public DefaultDatabaseContext(IUnitOfWork unitOfwork, IConnectionPool connectionPool)
        {
            this.unitOfwork = unitOfwork;
            this.connectionPool = connectionPool;
        }

        public async Task<T> ExecuteReader<T>(Func<IConnection, Task<T>> function)
        {
            if (function == null)
            {
                throw new NullReferenceException("ReaderFunction is Null!");
            }

            IReaderCommand<T> command = new ReaderCommand<T>(function);

            IConnection connection = await this.connectionPool.Pop();

            try
            {   
                return await command.Execute(connection);
            }
            finally
            {
                this.connectionPool.Push(connection);
            }
        }

        public async Task ExecuteWriter(Func<IConnection, Task> function)
        {
            if (function == null)
            {
                throw new NullReferenceException("WriterFunction is Null!");
            }

            WriterCommand command = new WriterCommand(function);

            if (this.unitOfwork.InTransaction)
            {                
                this.unitOfwork.EnqueueCommand(command);
            }
            else
            {
                IConnection connection = await this.connectionPool.Pop();

                try
                {
                    await command.Execute(connection);
                }
                finally
                {
                    this.connectionPool.Push(connection);
                }
            }
        }
    }
}
