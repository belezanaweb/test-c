using Boticario.Backend.Data.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Implementation
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly ConcurrentQueue<IWriterCommand> commandQueue;
        private long transactionsEnqueued;

        public UnitOfWorkImpl()
        {
            this.commandQueue = new ConcurrentQueue<IWriterCommand>();
            this.transactionsEnqueued = 0;
        }

        public bool InTransaction { get { return this.ReadTransactionsEnqueued() > 0; } }

        public async Task Execute(Func<Task> function)
        {
            try
            {
                this.AddTransactionsEnqueued();

                await Task.Run(function);

                this.DecTransactionsEnqueued();

                await this.CommitIfTransactionCountIsZero();
            }
            catch
            {
                this.RollbackTransaction();
                throw;
            }
        }

        private async Task CommitIfTransactionCountIsZero()
        {
            if (this.ReadTransactionsEnqueued() == 0)
            {
                List<Task<bool>> commandTasks = new List<Task<bool>>(this.commandQueue.Count);

                while (this.commandQueue.TryDequeue(out IWriterCommand command))
                {
                    commandTasks.Add(command.Execute());
                }

                await Task.WhenAll(commandTasks);
            }
        }

        private void RollbackTransaction()
        {
            if (this.ReadTransactionsEnqueued() > 0)
            {
                this.commandQueue.Clear();
                this.ResetTransactionsEnqueued();
            }
        }

        private void AddTransactionsEnqueued()
        {
            Interlocked.Increment(ref this.transactionsEnqueued);
        }

        private long DecTransactionsEnqueued()
        {
            return Interlocked.Decrement(ref this.transactionsEnqueued);
        }

        private long ReadTransactionsEnqueued()
        {
            return Interlocked.Read(ref this.transactionsEnqueued);
        }

        private void ResetTransactionsEnqueued()
        {
            Interlocked.Exchange(ref this.transactionsEnqueued, 0);
        }
    }
}
