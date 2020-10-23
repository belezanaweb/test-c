using Boticario.Backend.Data.Connection.Implementation;
using NUnit.Framework;

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
        public void When_CreateIsCalled_Should_ReturnNewConnection()
        {
            Assert.IsNotNull(this.connectionFactory.Create());
        }
    }
}