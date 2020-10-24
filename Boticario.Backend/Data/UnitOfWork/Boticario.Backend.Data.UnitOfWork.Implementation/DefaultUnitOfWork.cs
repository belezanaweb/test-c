using Boticario.Backend.Data.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Implementation
{
    public class DefaultUnitOfWork : IUnitOfWork
    {
        public readonly ConcurrentQueue<IWriterCommand> commandQueue;        
        public readonly ConcurrentQueue<string> transactionQueue;

        public DefaultUnitOfWork()
        {
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
            List<Task<bool>> commandTasks = new List<Task<bool>>(this.commandQueue.Count);

            while (this.commandQueue.TryDequeue(out IWriterCommand command))
            {
                commandTasks.Add(command.Execute());
            }

            await Task.WhenAll(commandTasks);
        }

        public void RollbackTransaction()
        {
            this.commandQueue.Clear();
            this.transactionQueue.Clear();
        }
    }
}
