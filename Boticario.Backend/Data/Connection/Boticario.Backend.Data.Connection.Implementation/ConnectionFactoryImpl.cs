using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Implementation
{
    public class ConnectionFactoryImpl : IConnectionFactory
    {
        public async Task<IConnection> Create()
        {
            return await Task.Run<IConnection>(() =>
            {
                return new ConnectionImpl();
            });
        }
    }
}
