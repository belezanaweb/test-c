using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.Connection.Tests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Tests
{
    public class DefaultConnectionPoolTests
    {
        private DefaultConnectionPool connectionPool;

        [SetUp]
        public void Setup()
        {
            this.connectionPool = new DefaultConnectionPool(new ConnectionFactoryMock());
        }

        [Test]
        public void When_InitialState_Should_HaveNoConnections()
        {
            Assert.AreEqual(0, this.connectionPool.ActiveConnections);
            Assert.AreEqual(0, this.connectionPool.AvailableConnections);
        }

        [Test]
        public async Task When_2ConnectionsWereBorrowed_Should_Have2ActiveConnectionsAndNoAvailableConnections()
        {
            await this.connectionPool.Pop();
            await this.connectionPool.Pop();

            Assert.AreEqual(2, this.connectionPool.ActiveConnections);
            Assert.AreEqual(0, this.connectionPool.AvailableConnections);
        }

        [Test]
        public async Task When_2ConnectionsWereBorrowedAndReturned_Should_Have2ActiveConnectionsAnd2AvailableConnections()
        {
            IConnection connection1 = await this.connectionPool.Pop();
            IConnection connection2 = await this.connectionPool.Pop();

            this.connectionPool.Push(connection1);
            this.connectionPool.Push(connection2);

            Assert.AreEqual(2, this.connectionPool.ActiveConnections);
            Assert.AreEqual(2, this.connectionPool.AvailableConnections);
        }

        [Test]
        public async Task When_1ConnectionWasBorrewedAndReturnedManyTimes_Should_UseTheSameObject()
        {
            IConnection connection1 = await this.connectionPool.Pop();
            this.connectionPool.Push(connection1);

            IConnection connection2 = await this.connectionPool.Pop();
            this.connectionPool.Push(connection2);

            Assert.AreEqual(1, this.connectionPool.ActiveConnections);
            Assert.AreEqual(1, this.connectionPool.AvailableConnections);
            Assert.AreSame(connection1, connection2);
        }

        [Test]
        public async Task When_50NewConnectionsAtTheSameTime_Should_Have50ActiveConnections()
        {
            List<Task> tasks = new List<Task>(50);

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(this.connectionPool.CreateConnection());
            }

            await Task.WhenAll(tasks);

            Assert.AreEqual(50, this.connectionPool.ActiveConnections);
        }
    }
}
