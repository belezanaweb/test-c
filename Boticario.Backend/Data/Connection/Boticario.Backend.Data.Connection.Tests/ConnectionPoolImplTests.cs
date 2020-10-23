using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.Connection.Tests.Mocks;
using NUnit.Framework;

namespace Boticario.Backend.Data.Connection.Tests
{
    public class ConnectionPoolImplTests
    {
        private ConnectionPoolImpl connectionPool;

        [SetUp]
        public void Setup()
        {
            this.connectionPool = new ConnectionPoolImpl(new ConnectionFactoryMock());
        }

        [Test]
        public void When_InitialState_Should_HaveNoConnections()
        {
            Assert.AreEqual(0, this.connectionPool.ActiveConnections);
            Assert.AreEqual(0, this.connectionPool.AvailableConnections);
        }

        [Test]
        public void When_2ConnectionsWereBorrowed_Should_Have2ActiveConnectionsAndNoAvailableConnections()
        {
            this.connectionPool.Pop();
            this.connectionPool.Pop();

            Assert.AreEqual(2, this.connectionPool.ActiveConnections);
            Assert.AreEqual(0, this.connectionPool.AvailableConnections);
        }

        [Test]
        public void When_2ConnectionsWereBorrowedAndReturned_Should_Have2ActiveConnectionsAnd2AvailableConnections()
        {
            IConnection connection1 = this.connectionPool.Pop();
            IConnection connection2 = this.connectionPool.Pop();

            this.connectionPool.Push(connection1);
            this.connectionPool.Push(connection2);

            Assert.AreEqual(2, this.connectionPool.ActiveConnections);
            Assert.AreEqual(2, this.connectionPool.AvailableConnections);
        }

        [Test]
        public void When_1ConnectionWasBorrewedAndReturnedManyTimes_Should_UseTheSameObject()
        {
            IConnection connection1 = this.connectionPool.Pop();
            this.connectionPool.Push(connection1);

            IConnection connection2 = this.connectionPool.Pop();
            this.connectionPool.Push(connection2);

            Assert.AreEqual(1, this.connectionPool.ActiveConnections);
            Assert.AreEqual(1, this.connectionPool.AvailableConnections);
            Assert.AreSame(connection1, connection2);
        }
    }
}
