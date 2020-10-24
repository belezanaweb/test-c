using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Tests.Mocks
{
    internal class ConnectionFactoryMock : IConnectionFactory
    {
        public async Task<IConnection> Create()
        {
            return await Task.Run<IConnection>(() =>
            {
                return new ConnectionMock();
            });
        }
    }
}
