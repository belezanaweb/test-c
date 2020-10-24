using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Implementation
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        public async Task<IConnection> Create()
        {
            return await Task.Run<IConnection>(() =>
            {
                return new DefaultConnection();
            });
        }
    }
}
