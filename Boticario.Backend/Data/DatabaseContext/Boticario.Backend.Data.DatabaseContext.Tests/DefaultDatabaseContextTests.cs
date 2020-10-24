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
        private DefaultDatabaseContext databaseContext;

        [SetUp]
        public void Setup()
        {
            this.unifOfWork = new UnifOfWorkMock();
            this.databaseContext = new DefaultDatabaseContext(this.unifOfWork);
        }

        [Test]
        public void When_ExecuteReaderWithNullCommand_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async() =>
            {
                await this.databaseContext.ExecuteReader<string>(null);
            });

            Assert.AreEqual("ReaderCommand is Null!", exception.Message);
        }

        [Test]
        public async Task When_ExecuteReaderWithoutUnitOfWork_Should_ExecuteCommand()
        {
            ReaderCommandMock command = new ReaderCommandMock("ABCDEF");

            string result = await this.databaseContext.ExecuteReader(command);

            Assert.AreEqual("ABCDEF", result);
        }

        [Test]
        public async Task When_ExecuteReaderWithUnitOfWork_Should_ExecuteCommand()
        {
            await this.unifOfWork.Execute(async() =>
            {
                ReaderCommandMock command = new ReaderCommandMock("ABCDEF");

                string result = await this.databaseContext.ExecuteReader(command);

                Assert.AreEqual("ABCDEF", result);
            });
        }

        [Test]
        public void When_ExecuteWriterWithNullCommand_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await this.databaseContext.ExecuteWriter(null);
            });

            Assert.AreEqual("WriterCommand is Null!", exception.Message);
        }

        [Test]
        public async Task When_ExecuteWriterWithoutUnitOfWork_Should_ExecuteCommand()
        {
            WriterCommandMock command = new WriterCommandMock();

            await this.databaseContext.ExecuteWriter(command);

            Assert.IsTrue(command.Executed);
        }

        [Test]
        public async Task When_ExecuteWriterWithUnitOfWork_Should_NotExecuteCommand()
        {
            await this.unifOfWork.Execute(async () =>
            {
                WriterCommandMock command = new WriterCommandMock();

                await this.databaseContext.ExecuteWriter(command);

                Assert.IsFalse(command.Executed);
            });
        }
    }
}