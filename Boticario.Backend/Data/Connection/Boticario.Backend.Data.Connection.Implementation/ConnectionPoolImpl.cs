using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Boticario.Backend.Data.Connection.Implementation
{
    public class ConnectionPoolImpl : IConnectionPool
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly ConcurrentQueue<IConnection> connectionQueue;
        private int activeConnections;

        public ConnectionPoolImpl(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
            this.connectionQueue = new ConcurrentQueue<IConnection>();
            this.activeConnections = 0;
        }

        public IConnection Pop()
        {
            if (this.connectionQueue.TryDequeue(out IConnection existingRedisConnection))
            {
                return existingRedisConnection;
            }
            else
            {
                return this.CreateConnection();
            }
        }

        public void Push(IConnection connection)
        {
            this.connectionQueue.Enqueue(connection);
        }

        private IConnection CreateConnection()
        {
            IConnection newInstance = this.connectionFactory.Create();

            Interlocked.Increment(ref this.activeConnections);

            return newInstance;
        }

        public int ActiveConnections
        {
            get
            {
                return this.activeConnections;
            }
        }

        public int AvailableConnections
        {
            get { return this.connectionQueue.Count; }
        }
    }
}
