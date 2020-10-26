using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.Connection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Implementation
{
    public class DefaultUnitOfWork : IUnitOfWork
    {
        private readonly IConnectionPool connectionPool;

        public readonly ConcurrentQueue<IWriterCommand> commandQueue;        
        public readonly ConcurrentQueue<string> transactionQueue;

        public DefaultUnitOfWork(IConnectionPool connectionPool)
        {
            this.connectionPool = connectionPool;
            this.commandQueue = new ConcurrentQueue<IWriterCommand>();
            this.transactionQueue = new ConcurrentQueue<string>();
        }

        public bool InTransaction
        {
            get
            {
                return this.transactionQueue.Count > 0;
            }
        }

        public void EnqueueCommand(IWriterCommand command)
        {
            if (command == null)
            {
                throw new NullReferenceException("WriterCommand is Null!");
            }

            this.commandQueue.Enqueue(command);
        }

        public async Task Execute(Func<Task> function)
        {
            try
            {
                this.EnqueueTransaction();

                await Task.Run(function);

                this.DequeueTransaction();

                if (!this.InTransaction)
                {
                    await this.CommitTransaction();
                }
            }
            catch
            {
                this.RollbackTransaction();
                throw;
            }
        }

        public void EnqueueTransaction()
        {
            this.transactionQueue.Enqueue(string.Empty);
        }

        public void DequeueTransaction()
        {
            this.transactionQueue.TryDequeue(out _);
        }

        public async Task CommitTransaction()
        {
            IConnection connection = await this.connectionPool.Pop();

            try
            {
                List<Task<bool>> commandTasks = new List<Task<bool>>(this.commandQueue.Count);

                while (this.commandQueue.TryDequeue(out IWriterCommand command))
                {
                    commandTasks.Add(command.Execute(connection));
                }

                await Task.WhenAll(commandTasks);
            }
            finally
            {
                this.connectionPool.Push(connection);
            }
        }

        public void RollbackTransaction()
        {
            this.commandQueue.Clear();
            this.transactionQueue.Clear();
        }
    }
}
