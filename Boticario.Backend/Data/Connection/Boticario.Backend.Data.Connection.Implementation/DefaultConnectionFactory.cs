using Boticario.Backend.Data.Database;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection.Implementation
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IDatabase database;

        public DefaultConnectionFactory(IDatabase database)
        {
            this.database = database;
        }

        public async Task<IConnection> Create()
        {
            return await Task.Run<IConnection>(() =>
            {
                return new DefaultConnection(this.database);
            });
        }
    }
}
