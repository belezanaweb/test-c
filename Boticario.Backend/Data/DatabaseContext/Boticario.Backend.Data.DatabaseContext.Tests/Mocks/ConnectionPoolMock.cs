using Boticario.Backend.Data.Connection;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests.Mocks
{
    internal class ConnectionPoolMock : IConnectionPool
    {
        public async Task<IConnection> Pop()
        {
            return await Task.Run(() =>
            {
                return new ConnectionMock();
            });
        }

        public void Push(IConnection connection)
        {
        }
    }
}
