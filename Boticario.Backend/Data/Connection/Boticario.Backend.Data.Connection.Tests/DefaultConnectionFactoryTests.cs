using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.Database.Implementation;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Tests
{
    public class DefaultConnectionFactoryTests
    {
        private DefaultConnectionFactory connectionFactory;

        [SetUp]
        public void Setup()
        {
            this.connectionFactory = new DefaultConnectionFactory(new MemoryDatabase());
        }

        [Test]
        public async Task When_CreateIsCalled_Should_ReturnNewConnection()
        {
            IConnection connection = await this.connectionFactory.Create();

            Assert.IsNotNull(connection);
        }
    }
}