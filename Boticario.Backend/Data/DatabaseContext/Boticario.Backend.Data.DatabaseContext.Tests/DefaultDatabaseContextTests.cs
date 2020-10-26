using Boticario.Backend.Data.DatabaseContext.Implementation;
using Boticario.Backend.Data.DatabaseContext.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests
{
    public class DefaultDatabaseContextTests
    {
        private UnifOfWorkMock unifOfWork;
        private ConnectionPoolMock connectionPool;
        private DefaultDatabaseContext databaseContext;

        [SetUp]
        public void Setup()
        {
            this.unifOfWork = new UnifOfWorkMock();
            this.connectionPool = new ConnectionPoolMock();
            this.databaseContext = new DefaultDatabaseContext(this.unifOfWork, this.connectionPool);
        }

        [Test]
        public void When_ExecuteReaderWithNullFunction_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async() =>
            {
                await this.databaseContext.ExecuteReader<string>(null);
            });

            Assert.AreEqual("ReaderFunction is Null!", exception.Message);
        }

        [Test]
        public async Task When_ExecuteReaderWithoutUnitOfWork_Should_ExecuteCommand()
        {
            string result = await this.databaseContext.ExecuteReader((connection) =>
            {
                return Task.Run(() =>
                {
                    return "ABCDEF";
                });
            });

            Assert.AreEqual("ABCDEF", result);
        }

        [Test]
        public async Task When_ExecuteReaderWithUnitOfWork_Should_ExecuteCommand()
        {
            await this.unifOfWork.Execute(async() =>
            {
                string result = await this.databaseContext.ExecuteReader((connection) =>
                {
                    return Task.Run(() =>
                    {
                        return "ABCDEF";
                    });                    
                });

                Assert.AreEqual("ABCDEF", result);
            });
        }

        [Test]
        public void When_ExecuteWriterWithNullFunction_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await this.databaseContext.ExecuteWriter(null);
            });

            Assert.AreEqual("WriterFunction is Null!", exception.Message);
        }

        [Test]
        public async Task When_ExecuteWriterWithoutUnitOfWork_Should_ExecuteCommand()
        {
            bool commandWasExecuted = false;

            await this.databaseContext.ExecuteWriter((connection) =>
            {
                return Task.Run(() =>
                {
                    commandWasExecuted = true;
                });
            });

            Assert.IsTrue(commandWasExecuted);
        }

        [Test]
        public async Task When_ExecuteWriterWithUnitOfWork_Should_NotExecuteCommand()
        {
            bool commandWasExecuted = false;

            await this.unifOfWork.Execute(async () =>
            {
                await this.databaseContext.ExecuteWriter((connection) =>
                {
                    return Task.Run(() =>
                    {
                        commandWasExecuted = true;
                    });
                });

                Assert.IsFalse(commandWasExecuted);
            });
        }
    }
}