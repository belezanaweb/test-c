using Boticario.Backend.Data.DatabaseContext.Implementation;
using Boticario.Backend.Data.DatabaseContext.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests
{
    public class DatabaseContextImplTests
    {
        private DatabaseContextImpl databaseContext;

        [SetUp]
        public void Setup()
        {
            this.databaseContext = new DatabaseContextImpl();
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
            UnifOfWorkMock unifOfWork = new UnifOfWorkMock();

            await unifOfWork.Execute(async() =>
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
    }
}