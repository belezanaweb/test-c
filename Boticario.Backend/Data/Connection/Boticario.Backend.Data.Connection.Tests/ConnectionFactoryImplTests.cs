using Boticario.Backend.Data.Connection.Implementation;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Tests
{
    public class ConnectionFactoryImplTests
    {
        private ConnectionFactoryImpl connectionFactory;

        [SetUp]
        public void Setup()
        {
            this.connectionFactory = new ConnectionFactoryImpl();
        }

        [Test]
        public async Task When_CreateIsCalled_Should_ReturnNewConnection()
        {
            IConnection connection = await this.connectionFactory.Create();

            Assert.IsNotNull(connection);
        }
    }
}