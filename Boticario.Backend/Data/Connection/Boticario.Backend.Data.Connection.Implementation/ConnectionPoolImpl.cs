using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Implementation
{
    public class ConnectionPoolImpl : IConnectionPool
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly ConcurrentQueue<IConnection> connectionQueue;
        private long activeConnections;

        public ConnectionPoolImpl(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
            this.connectionQueue = new ConcurrentQueue<IConnection>();
            this.activeConnections = 0;
        }

        public async Task<IConnection> Pop()
        {
            if (this.connectionQueue.TryDequeue(out IConnection existingRedisConnection))
            {
                return existingRedisConnection;
            }
            else
            {
                return await this.CreateConnection();
            }
        }

        public void Push(IConnection connection)
        {
            this.connectionQueue.Enqueue(connection);
        }

        public async Task<IConnection> CreateConnection()
        {
            IConnection newInstance = await this.connectionFactory.Create();

            Interlocked.Increment(ref this.activeConnections);

            return newInstance;
        }

        public long ActiveConnections
        {
            get
            {
                return Interlocked.Read(ref this.activeConnections);
            }
        }

        public long AvailableConnections
        {
            get { return this.connectionQueue.Count; }
        }
    }
}
