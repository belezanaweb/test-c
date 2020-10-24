using Boticario.Backend.Data.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Implementation
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        public readonly ConcurrentQueue<IWriterCommand> commandQueue;        
        public readonly ConcurrentQueue<string> transactions;

        public UnitOfWorkImpl()
        {
            this.commandQueue = new ConcurrentQueue<IWriterCommand>();
            this.transactions = new ConcurrentQueue<string>();
        }

        public bool InTransaction
        {
            get
            {
                return this.transactions.Count > 0;
            }
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
            this.transactions.Enqueue(string.Empty);
        }

        public void DequeueTransaction()
        {
            this.transactions.TryDequeue(out _);
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
            this.transactions.Clear();
        }
    }
}
