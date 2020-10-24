using Boticario.Backend.Data.UnitOfWork.Implementation;
using Boticario.Backend.Data.UnitOfWork.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Tests
{
    public class UnitOfWorkImplTests
    {
        private UnitOfWorkImpl unitOfWork;

        [SetUp]
        public void Setup()
        {
            this.unitOfWork = new UnitOfWorkImpl();
        }

        [Test]
        public void When_FunctionNotStarted_Should_ReturnNotInTransaction()
        {
            Assert.IsFalse(this.unitOfWork.InTransaction);
        }

        [Test]
        public async Task When_FunctionStarted_Should_ReturnInTransaction()
        {
            await this.unitOfWork.Execute(async () =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(this.unitOfWork.InTransaction);
                });
            });
        }

        [Test]
        public async Task When_50TransactionsWereEnqueued_Should_Return50TransactionEnqueued()
        {
            List<Task> tasks = new List<Task>(50);

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    this.unitOfWork.EnqueueTransaction();
                }));
            }

            await Task.WhenAll(tasks);            

            Assert.AreEqual(50, this.unitOfWork.transactionQueue.Count);
        }

        [Test]
        public void When_1TransactionWasDequeuedWithoutBeEnqueuedBefore_Should_Return0TransactionEnqueued()
        {
            this.unitOfWork.DequeueTransaction();
            
            Assert.AreEqual(0, this.unitOfWork.transactionQueue.Count);
        }

        [Test]
        public void When_Enqueue1Command_Should_Have1CommandInQueue()
        {
            this.unitOfWork.EnqueueCommand(new CommandMock());

            Assert.AreEqual(1, this.unitOfWork.commandQueue.Count);
        }

        [Test]
        public async Task When_CommitTransactionWith1Command_Should_CommandQueueBeEmpty()
        {
            this.unitOfWork.commandQueue.Enqueue(new CommandMock());

            await this.unitOfWork.CommitTransaction();

            Assert.IsEmpty(this.unitOfWork.commandQueue);
        }

        [Test]
        public async Task When_CommitTransactionWith10Commands_Should_ExecuteWholeCommands()
        {
            List<CommandMock> commands = new List<CommandMock>(10);

            for (int i = 0; i < 10; i++)
            {
                CommandMock command = new CommandMock();

                commands.Add(command);
                this.unitOfWork.commandQueue.Enqueue(command);
            }

            await this.unitOfWork.CommitTransaction();

            Assert.AreEqual(10, commands.Count(p => p.Executed));
        }

        [Test]
        public void When_RollbackTransactionWith1Command_Should_CommandQueueBeEmpty()
        {
            this.unitOfWork.commandQueue.Enqueue(new CommandMock());

            this.unitOfWork.RollbackTransaction();

            Assert.IsEmpty(this.unitOfWork.commandQueue);
        }

        [Test]
        public void When_RollbackTransactionWith10Commands_Should_NotExecuteCommands()
        {
            List<CommandMock> commands = new List<CommandMock>(10);

            for (int i = 0; i < 10; i++)
            {
                CommandMock command = new CommandMock();

                commands.Add(command);
                this.unitOfWork.commandQueue.Enqueue(command);
            }

            this.unitOfWork.RollbackTransaction();

            Assert.AreEqual(10, commands.Count(p => !p.Executed));
        }

        [Test]
        public async Task When_FunctionStartedTwice_Should_KeepTransactionAfterLeaveInsideFunction()
        {
            await this.unitOfWork.Execute(async () =>
            {
                await this.unitOfWork.Execute(async () =>
                {
                    await Task.Run(() => { });
                });

                Assert.IsTrue(this.unitOfWork.InTransaction);
            });
        }

        [Test]
        public async Task When_FunctionStartedTwice_Should_CancelTransactionAfterFirstRollback()
        {
            try
            {
                await this.unitOfWork.Execute(async () =>
                {
                    try
                    {
                        await this.unitOfWork.Execute(() =>
                        {
                            throw new Exception("Cancelling InnerTransaction");
                        });
                    }
                    catch
                    {
                    }

                    Assert.IsFalse(this.unitOfWork.InTransaction);
                });
            }
            catch
            {
            }
        }

        [Test]
        public async Task When_FunctionStartedTwice_Should_CommitTransactionAfterLeaveOuterFunction()
        {
            await this.unitOfWork.Execute(async () =>
            {
                await this.unitOfWork.Execute(async () =>
                {
                    await Task.Run(() => { });
                });
            });

            Assert.IsFalse(this.unitOfWork.InTransaction);
        }
    }
}