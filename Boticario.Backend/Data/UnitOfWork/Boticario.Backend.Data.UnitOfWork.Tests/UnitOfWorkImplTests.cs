using Boticario.Backend.Data.UnitOfWork.Implementation;
using NUnit.Framework;
using System;
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